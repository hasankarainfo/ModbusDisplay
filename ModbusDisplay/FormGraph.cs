using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ZedGraph;
using EasyModbus;

namespace ModbusDisplay
{
    public partial class FormGraph : Form
    {
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public string graphFile = null;

        bool StreamGraphEn = false;
        bool ThreadsRunning = true;
        bool mbSendCmd = false;
        DateTime timeFirst;
        long delayActual = 0;

        bool NeedTableRefresh = false;
        byte Identifier = 1;

        DataSet myDataSet = new DataSet("MyDataSet");
        public dgvLib dgv = new dgvLib("MyDataTable", "MyDataTable");

        //int tAxisMaxLen;

        BackgroundWorker bgwGraphMain = new BackgroundWorker();

        Rows[] rows;
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        public partial class Rows
        {
            public int[] reg;

            public LineItem curve;
            public string type;
            public int len;

            public bool Changed;
            public bool mbSend;
            public string ChangeCol;

            public short regAddr;

            public long cntOk;
            public long cntFail;

            public long lastOk;
            public long lastFail;
            public Rows()
            {
                reg = null;
                curve = new LineItem("");
                type = "";
                len = 0;

                Changed = true;
                ChangeCol = null;

                mbSend = false;

                cntOk = 0;
                cntFail = 0;
            }
        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public FormGraph()
        {
            InitializeComponent();
        }


        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public void GraphTableInit()
        {
            myDataSet.Tables.Add(dgv.dt);
            this.splitC2.Panel1.Controls.Add(dgv);

            dgv.Columns["Hex"].Visible = false;
            dgv.Columns["Bin"].Visible = false;



            for (int i = 0; i < 10; i++)
            {
                dgv.defRowAdd();
            }

            dgv.CellValueChanged += new DataGridViewCellEventHandler(dgvGraph_CellValChanged);
            dgv.EditingControlShowing += ((DataGridViewEditingControlShowingEventHandler)
                delegate (object sender, DataGridViewEditingControlShowingEventArgs e)
                {
                    e.Control.KeyPress -= new KeyPressEventHandler(dgvGraphTextBox_KeyPress);
                    e.Control.KeyPress += new KeyPressEventHandler(dgvGraphTextBox_KeyPress);
                });
            dgv.CellClick += ((DataGridViewCellEventHandler)
                delegate (object sender, DataGridViewCellEventArgs e)
                {
                    if (e.ColumnIndex == dgv.Columns["En"].Index)
                    {
                        dgv.chk(e.RowIndex, !dgv.chk(e.RowIndex));
                    }

                });

            dgv.MouseClick += (
                (MouseEventHandler)delegate (object sender, MouseEventArgs e)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                        ContextMenu m = new ContextMenu();
                        m.MenuItems.Add(new MenuItem("Add",
                             (EventHandler)delegate (object sender2, EventArgs e2)
                             {
                                 DataRow myRow = dgv.dt.NewRow();
                                 dgv.dt.Rows.InsertAt(myRow, currentMouseOverRow);
                                 dgv["Len", currentMouseOverRow].ReadOnly = true;
                             }));

                        m.MenuItems.Add(new MenuItem("Delete",
                             (EventHandler)delegate (object sender2, EventArgs e2)
                             {
                                 dgv.Rows.RemoveAt(currentMouseOverRow);

                             }));

                        m.Show(dgv, new Point(e.X, e.Y));

                    }

                });

            dgv.RowsAdded += (
                (DataGridViewRowsAddedEventHandler)delegate (object sender, DataGridViewRowsAddedEventArgs e)
                {
                    NeedTableRefresh = true;
                });
            dgv.RowsRemoved += (
                (DataGridViewRowsRemovedEventHandler)delegate (object sender, DataGridViewRowsRemovedEventArgs e)
                {
                    NeedTableRefresh = true;
                });
        }

        private void FormGraph_Load(object sender, EventArgs e)
        {
            GraphTableInit();

            NeedTableRefresh = true;


            OpenXmlFile(this.graphFile);

            this.FormClosed += ((FormClosedEventHandler)delegate (object sendere, FormClosedEventArgs ee)
            {
                ThreadsRunning = false;
            });
            linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(
              (
              delegate (object senderr, LinkLabelLinkClickedEventArgs ee)
              {
                  System.Diagnostics.Process.Start("http://www.hasankara.info");
              })
              );

            bgwGraphMain.DoWork += new DoWorkEventHandler(bgwGraphMain_DoWork);

            bgwGraphMain.RunWorkerAsync();

            cboxRegOrder.Items.Add(dgvLib.RegisterOrder.LowHigh);
            cboxRegOrder.Items.Add(dgvLib.RegisterOrder.HighLow);
            cboxRegOrder.SelectedIndex = 0;

        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        public double getTime()
        {
            return ((double)(DateTime.Now.Ticks - timeFirst.Ticks) / TimeSpan.TicksPerMillisecond) / 1000;
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /


        private void bgwGraphMain_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dtPer = DateTime.Now;
            DateTime dtLastRead = DateTime.Now;
            DateTime dtReadPer = DateTime.Now;
            int readDelayTime = 0;
            bool refreshVal = false;
            short addrNext = 0;
            int graphSample = 1;
            while (true)
            {

                if (!ThreadsRunning) break;


                if (((BackgroundWorker)sender).CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                /* (NO DELAY) TABLOLAR VE GRAFIK BASTAN YUKLENIR*/
                if (NeedTableRefresh)
                {
                    //this.BeginInvoke((MethodInvoker)delegate
                    //{

                    timeFirst = DateTime.Now;

                    //tAxisMaxLen = (int)numGraphSample.Value;

                    zg1.GraphPane.Title.Text = null;

                    zg1.GraphPane.XAxis.Title.Text = " ";
                    zg1.GraphPane.YAxis.Title.Text = " ";
                    zg1.GraphPane.Chart.Fill.Color = SystemColors.ControlLight;
                    zg1.GraphPane.Fill.Color = SystemColors.ControlLight;
                    //zg1.issh
                    zg1.GraphPane.CurveList.Clear();
                    lock (dgv)
                    {
                        int i = 0;
                        rows = new Rows[dgv.Rows.Count];
                        for (; i < rows.Length; i++)
                        {
                            rows[i] = new Rows();

                            rows[i].curve = zg1.GraphPane.AddCurve(i.ToString(),
                                     null, giveColor(i), SymbolType.None);
                            rows[i].curve.Tag = dgv.getValStr("Type", i);
                            rows[i].curve.Label.IsVisible = false;
                            //rows[i].curve.Line.IsSmooth = true;
                            //rows[i].curve.Line.SmoothTension =(float) 0.5;
                        }

                    }
                    //});

                    NeedTableRefresh = false;
                }


                /*(NO DELAY) DEGISEN SUTUN DEGERI REGE ALINIR*/
                for (int i = 0; i < rows.Length && dgv.isRow(i); i++)
                {
                    if (NeedTableRefresh) break;

                    if (rows[i].ChangeCol != null)
                    {
                        rows[i].reg = dgv.SelToReg(rows[i].ChangeCol, i);
                        rows[i].ChangeCol = null;
                    }
                }

                /* (NO DELAY) SATIR GUNCELLEMELERI*/
                this.BeginInvoke((MethodInvoker)delegate
                {
                    do
                    {
                        if (NeedTableRefresh) break;
                        if (!ThreadsRunning) break;

                        for (int i = 0; i < rows.Length && dgv.isRow(i); i++)
                        {
                            if (!rows[i].Changed) continue;
                            rows[i].Changed = false;
                            /* TABLE REFRESH*/

                            dgv.CellValueChanged -= dgvGraph_CellValChanged;
                            do
                            {
                                if (dgv.chk(i))
                                {
                                    dgv["En", i].Style.BackColor = giveColor(i);
                                }
                                else
                                {
                                    dgv["En", i].Style.BackColor = Color.White;
                                }
                                if (dgv.chk(i) && (string)dgv["Type", i].Value != "U8+U8")
                                {
                                    rows[i].curve.IsVisible = true;
                                }
                                else
                                {
                                    rows[i].curve.IsVisible = false;
                                    rows[i].curve.Label.IsVisible = false;
                                }

                                if ((string)dgv["Type", i].Value == "U8+U8")
                                {
                                    dgv["Len", i].ReadOnly = false;
                                }
                                else
                                {
                                    dgv["Len", i].ReadOnly = true;
                                    dgv["Len", i].Value = 1;
                                }
                                //dtLib.RegToAll(dgv, rows[i].reg, i, regOrder);
                                dgv.RegToAll(rows[i].reg, i);
                            } while (false);
                            dgv.CellValueChanged += new DataGridViewCellEventHandler(dgvGraph_CellValChanged);
                        }

                    } while (false);
                });



                /*  (NO DELAY) MODBUS YAZMA*/
                do
                {
                    addrNext = 0;
                    for (int i = 0; i < rows.Length && dgv.isRow(i); i++)
                    {
                        if (!cbMbAutoSend.Checked) break;
                        if (NeedTableRefresh) break;
                        if (!mbSendCmd) break;

                        long Len = (long)dgv["Len", i].Value;
                        short count = (short)((dgv.typeSizeof(i) / 2) * (int)Len);

                        string AddrStr = dgv.getValStr("Addr", i);
                        short addr;
                        try
                        {
                            if (AddrStr == null || AddrStr == "")
                            {
                                addr = addrNext;
                            }
                            else
                            {
                                if (AddrStr.IndexOf("0x", 0) >= 0)
                                {
                                    addr = Convert.ToInt16(AddrStr, 16);

                                }
                                else
                                {
                                    addr = Convert.ToInt16(AddrStr, 10);
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                        addrNext = (short)(addr + count);

                        if (rows[i].ChangeCol != null)
                        {
                            rows[i].reg = dgv.SelToReg(rows[i].ChangeCol, i);
                            rows[i].ChangeCol = null;
                        }

                        if (rows[i].mbSend && rows[i].reg != null)
                        {
                            bool result;
                            lock (Form1.mb)
                            {
                                result = Form1.mb.WriteMultipleRegisters(Identifier, addr, rows[i].reg);
                            }
                            if (result) rows[i].cntOk++;
                            else rows[i].cntFail++;


                        }
                        rows[i].mbSend = false;
                    }

                } while (false);


                /* (PARAM DELAY) MODBUS OKUMA, GRAFIK GUNCELLEME*/
                long tdiff =  (DateTime.Now.Ticks - dtReadPer.Ticks) / TimeSpan.TicksPerMillisecond;
                if (tdiff > readDelayTime)
                {
                    delayActual = tdiff;
                    dtReadPer = DateTime.Now;
                    do
                    {
                        if (!StreamGraphEn || NeedTableRefresh) break;

                        ////long oldInd = TimLineRead;
                        //if (TimLineRead + 1 < tAxisMaxLen) TimLineRead++;
                        //else TimLineRead = 0;



                        addrNext = 0;
                        for (int i = 0; i < rows.Length && dgv.isRow(i); i++)
                        {
                            if (!StreamGraphEn || NeedTableRefresh) break;

                            long Len = dgv.getLen(i);
                            short count = (short)((dgv.typeSizeof(i) / 2) * (int)Len);

                            string AddrStr = dgv.getValStr("Addr", i);
                            short addr;
                            try
                            {
                                if (AddrStr == null || AddrStr == "")
                                {
                                    addr = addrNext;
                                }
                                else
                                {
                                    if (AddrStr.IndexOf("0x", 0) >= 0)
                                    {
                                        addr = Convert.ToInt16(AddrStr, 16);

                                    }
                                    else
                                    {
                                        addr = Convert.ToInt16(AddrStr, 10);
                                    }
                                }
                            }
                            catch
                            {
                                continue;
                            }
                            addrNext = (short)(addr + count);

                            if (!dgv.chk(i)) continue;
                            if (rows[i].ChangeCol != null) continue;

                            lock (Form1.mb)
                            {
                                rows[i].reg = Form1.mb.ReadHoldingRegisters(Identifier, addr, count);
                                if (refreshVal)
                                    rows[i].Changed = true;
                            }
                            if (rows[i].reg == null)
                            {
                                rows[i].cntFail++;
                            }
                            else
                            {
                                rows[i].cntOk++;
                            }

                            /*UPDATE CURVE VALUE*/
                            do
                            {
                                int pcount = rows[i].curve.Points.Count;
                                if (pcount > 1)
                                {
                                    while (true)
                                    {
                                        pcount = rows[i].curve.Points.Count;
                                        double timeDiff = rows[i].curve.Points[pcount - 1].X - rows[i].curve.Points[0].X;
                                        if (timeDiff < graphSample) break;
                                        rows[i].curve.RemovePoint(0);

                                    }

                                }

                                double time = getTime();
                                double yValue = 0;
                                if (rows[i].curve != null && rows[i].reg != null && !NeedTableRefresh)
                                {
                                    yValue = dgv.typValCnv(dgv.RegToLong(rows[i].reg, i), i);
                                }

                                PointPair myPoint = new PointPair(time, yValue);
                                rows[i].curve.AddPoint(myPoint);
                            } while (false);

                        }/*for*/
                        refreshVal = false;
                    } while (false);

                }
                else
                {
                    Thread.Sleep(1);
                }



                /* (100 MS DELAY) GORSEL GUNECLLEME*/
                if ((DateTime.Now.Ticks - dtPer.Ticks) > TimeSpan.TicksPerMillisecond * 100)
                {
                    dtPer = DateTime.Now;

                    refreshVal = true;

                    zg1.AxisChange();
                    zg1.Invalidate();
                    zg1.AutoScaleMode = AutoScaleMode.Font;


                    this.BeginInvoke((MethodInvoker)delegate
                    {


                        label3.Text = "Delay(ms):" + delayActual.ToString();
                        graphSample = (int)numTime.Value;
                        readDelayTime = (int)numDelay.Value;
                        long okTotal = 0;
                        long failTotal = 0;

                        /* Adres hucre yesil yada kirmizi renk atamasi yapilir*/
                        int vote = 0;
                        for (int i = 0; i < rows.Length && dgv.isRow(i); i++)
                        {
                            if (!ThreadsRunning) break;
                            if (NeedTableRefresh) break;
                            long okTime = (rows[i].cntOk - rows[i].lastOk);
                            long failTime = (rows[i].cntFail - rows[i].lastFail);
                            okTotal += rows[i].lastOk;
                            failTotal += rows[i].lastFail;

                            Color addrColor;
                            if (okTime == 0 && failTime == 0)
                            {
                                addrColor = Color.White;
                            }
                            else
                            {
                                if (okTime > failTime)
                                {
                                    addrColor = Color.LimeGreen;
                                }
                                else
                                {
                                    addrColor = Color.IndianRed;
                                }

                            }
                            dgv["Addr", i].Style.BackColor = addrColor;

                            if (okTime > 0) vote++;

                            rows[i].lastOk = rows[i].cntOk;
                            rows[i].lastFail = rows[i].cntFail;
                        }

                        /*OK VE FAIL LABEL GUNCELLEME*/
                        {
                            lblOk.Text = "O.K: " + okTotal.ToString();
                            lblFail.Text = "Fail: " + failTotal.ToString();
                        }


                        {/*Graph Stream Buton rengi yenileme*/
                            if (StreamGraphEn)
                            {
                                if (vote > 0) { btnStreamEn.BackColor = Color.LimeGreen; }
                                else { btnStreamEn.BackColor = Color.Yellow; }
                            }
                            else btnStreamEn.BackColor = Color.OrangeRed;
                        }
                    });

                }


            }

        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /


        private void dgvGraph_CellValChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (rows.Length <= row) return;

            if (col == dgv.Rows[row].Cells["En"].ColumnIndex)
            {
                rows[row].Changed = true;
            }
            else if (col == dgv.Columns["Addr"].Index)
            {
                rows[row].Changed = true;
            }
            else if (col == dgv.Columns["Type"].Index)
            {
                rows[row].Changed = true;
            }
            else if (col == dgv.Columns["Len"].Index)
            {
                rows[row].Changed = true;

            }
            else if (col == dgv.Columns["Value"].Index)
            {
                rows[row].ChangeCol = "Value";
                rows[row].Changed = true;
                rows[row].mbSend = true;
                mbSendCmd = true;
            }
            else if (col == dgv.Columns["Hex"].Index)
            {
                rows[row].ChangeCol = "Hex";
                rows[row].Changed = true;
                rows[row].mbSend = true;
                mbSendCmd = true;
            }
            else if (col == dgv.Columns["Bin"].Index)
            {
                rows[row].ChangeCol = "Bin";
                rows[row].Changed = true;
                rows[row].mbSend = true;
                mbSendCmd = true;
            }
            else if (col == dgv.Columns["Ascii"].Index)
            {
                rows[row].ChangeCol = "Ascii";
                rows[row].Changed = true;
                rows[row].mbSend = true;
                mbSendCmd = true;
            }

        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        private void dgvGraphTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int col = dgv.CurrentCell.ColumnIndex;

            if (col == dgv.Columns["Addr"].Index)
            {
                e.Handled = true;

                if (
                   IsHex(e.KeyChar) ||
                   (e.KeyChar == (char)Keys.Back) ||
                   (e.KeyChar == 3) ||
                   (e.KeyChar == 22) ||
                   (e.KeyChar == 'x')
                   )
                    e.Handled = false;

            }
            else if (col == dgv.Columns["Value"].Index)
            {
                e.Handled = true;
                if (
                   IsHex(e.KeyChar) ||
                   (e.KeyChar == (char)Keys.Back) ||
                   (e.KeyChar == 3) ||
                   (e.KeyChar == 22) ||
                   (e.KeyChar == 'x') ||
                   (e.KeyChar == '-') ||
                   (e.KeyChar == ',')
                   )
                    e.Handled = false;
            }
            else if (col == dgv.Columns["Hex"].Index)
            {
                e.Handled = true;
                if (
                   IsHex(e.KeyChar) ||
                   (e.KeyChar == (char)Keys.Back) ||
                   (e.KeyChar == 3) ||
                   (e.KeyChar == 22) ||
                   (e.KeyChar == 'x') ||
                   (e.KeyChar == '-')
                   )
                    e.Handled = false;
            }
            else if (col == dgv.Columns["Bin"].Index

               )
            {
                e.Handled = true;

                if (('0' <= e.KeyChar && e.KeyChar <= '1') ||
                     (e.KeyChar == (char)Keys.Back) ||
                     (e.KeyChar == 3) ||
                     (e.KeyChar == 22) ||
                     (e.KeyChar == 'x') ||
                     (e.KeyChar == '-')
                   )
                    e.Handled = false;
            }
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        private void btnStreamEn_Click(object sender, EventArgs e)
        { StreamGraphEn = !StreamGraphEn; }
        private void chkGraphRecEnAddrUpd_CheckedChanged(object sender, EventArgs e)
        {

        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        Color[] myColorList = new Color[] {
             Color.Red, Color.Green,Color.Blue,
            Color.Black, Color.Turquoise, Color.Orange,
            Color.GreenYellow,Color.DarkRed,Color.Brown,
            Color.Cyan,Color.DarkOrange,Color.DarkRed,
        };
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public Color giveColor(int i)
        {
            return myColorList[i % (myColorList.Length - 1)];
        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /


        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public static bool IsHex(char c)
        {
            return (c >= '0' && c <= '9') ||
                     (c >= 'a' && c <= 'f') ||
                     (c >= 'A' && c <= 'F');
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Table|*.xml";

            DialogResult result = DialogResult.None;
            Thread dialogThread = new Thread((delegate ()
            {
                result = myDialog.ShowDialog();

            }));
            dialogThread.SetApartmentState(ApartmentState.STA);
            dialogThread.Start();
            while (result == DialogResult.None) Thread.Sleep(100);

            if (result == DialogResult.OK)
            {
                myDataSet.WriteXml(myDialog.FileName);
            }


        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        private bool OpenXmlFile(string file)
        {
            if (File.Exists(file))
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    lock (myDataSet)
                    {
                        myDataSet.Clear();
                        myDataSet.ReadXml(file);
                    }
                    NeedTableRefresh = true;
                });
                return true;
            }
            else return false;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Table|*.xml";

            DialogResult result = DialogResult.None;
            Thread dialogThread = new Thread((delegate ()
            {
                result = myDialog.ShowDialog();

            }));
            dialogThread.SetApartmentState(ApartmentState.STA);
            dialogThread.Start();
            while (result == DialogResult.None) Thread.Sleep(100);

            if (result == DialogResult.OK)
            {
                OpenXmlFile(myDialog.FileName);
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //NeedTableRefresh = true;
        }

        private void numAddr_ValueChanged(object sender, EventArgs e)
        {
            Identifier = (byte)numAddr.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.regOrder = (dgvLib.RegisterOrder)cboxRegOrder.SelectedItem;
        }
        private void cbGraphEn_CheckedChanged(object sender, EventArgs e)
        {


            if (cbGraphEn.Checked)
            {
                zg1.Visible = true;
                splitC2.SplitterDistance = splitC2.Size.Width * 1 / 3;
            }
            else
            {
                zg1.Visible = false;
                splitC2.SplitterDistance = splitC2.Size.Width;
            }
        }

        private void cbHexEn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHexEn.Checked)
            {
                dgv.Columns["Hex"].Visible = true;
            }
            else
            {
                dgv.Columns["Hex"].Visible = false;
            }
        }

        private void cbBinEn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBinEn.Checked)
            {
                dgv.Columns["Bin"].Visible = true;
            }
            else
            {
                dgv.Columns["Bin"].Visible = false;
            }
        }

        private void cbAsciiEn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAsciiEn.Checked)
            {
                dgv.Columns["Ascii"].Visible = true;
            }
            else
            {
                dgv.Columns["Ascii"].Visible = false;
            }
        }


        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
    }
}
