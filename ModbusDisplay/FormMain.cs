using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ZedGraph;
using ZylSoft.Serial;
using EasyModbus;

//\ /\\ /\\\ /\\\\ /\\\\\ /\\\\\\ /\\\\\\\ /\\\\\\\\ /\\\\\\\\\ /\\\\\\\\\ /
namespace ModbusDisplay
{
    public partial class Form1 : Form
    {


        public static ModbusClient mb = new ModbusClient();

        bool SerialTry = false;
        bool SerialReconn = false;
        string SelectedPort = null;
        public static int start_file_cnt = 0;

        BackgroundWorker bgwFormRefresh;
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public Form1()
        {
            InitializeComponent();
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public void Form1_Load(object sender, EventArgs e)
        {
            //CheckForIllegalCrossThreadCalls = false;


            bgwFormRefresh = new BackgroundWorker();

            bgwFormRefresh.DoWork += new DoWorkEventHandler(bgwFormRefresh_DoWork);

            bgwFormRefresh.RunWorkerAsync();

            this.FormClosed += ((FormClosedEventHandler)
                delegate (object senderr, FormClosedEventArgs ee)
                {
                    bgwFormRefresh.WorkerSupportsCancellation = true;

                    bgwFormRefresh.CancelAsync();

                    mb.Disconnect();

                });
            PortRefresh();

            linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(
                (
                delegate (object senderr, LinkLabelLinkClickedEventArgs ee)
                {
                    System.Diagnostics.Process.Start("http://www.hasankara.info");
                })
                );

            cboxParity.Items.Add(SerialParityBits.None);
            cboxParity.Items.Add(SerialParityBits.Even);
            cboxParity.Items.Add(SerialParityBits.Mark);
            cboxParity.Items.Add(SerialParityBits.Odd);
            cboxParity.Items.Add(SerialParityBits.Space);
            cboxParity.SelectedItem = SerialParityBits.None;

            cboxStop.Items.Add(SerialStopBits.Sb1Bit);
            cboxStop.Items.Add(SerialStopBits.Sb1_5Bits);
            cboxStop.Items.Add(SerialStopBits.Sb2Bits);
            cboxStop.SelectedItem = SerialStopBits.Sb1Bit;

        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        private void PortRefresh()
        {
            String[] ports = ZylSoft.Serial.SerialPort.GetExistingCommPortNames();

            this.BeginInvoke((MethodInvoker)delegate
            {
                lstPorts.Items.Clear();
                foreach (String i in ports)
                {
                    lstPorts.Items.Add(i);
                }

                lstPorts.SetSelected(lstPorts.Items.Count - 1, true);

                lstPorts.Items.Add("Double Click Refresh");
            });
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        private void bgwFormRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            //Thread.CurrentThread.Name = "__OtherScrnRefresh";

            while (true)
            {
                Thread.Sleep(200);// periyodunda diger goruntuleme aygitlari icin yapar

                if (((BackgroundWorker)sender).CancellationPending == true)
                {
                    e.Cancel = true;
                    break; ;
                }

                if (SerialTry)
                {
                    if (!mb.Connected)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            mb.Port = SelectedPort;
                            mb.Baudrate = (int)numBaud.Value;
                            mb.Parity = (SerialParityBits)cboxParity.SelectedItem;
                            mb.StopBits = (SerialStopBits)cboxStop.SelectedItem;
                            mb.ConnectionTimeout = 500;
                            mb.ReturnTimeout = (int)numMbTout.Value;
                            mb.Connect();
                        });
                    }
                    else if (SerialReconn)
                    {
                        SerialReconn = false;
                        mb.Disconnect();
                    }
                }
                else
                {
                    if (mb.Connected)
                    {

                        mb.Disconnect();
                    }

                }



                this.BeginInvoke((MethodInvoker)delegate
                {
                    // SeriPort durum buton rengi yenileme

                    if (mb.Connected)
                    {
                        BtnConnect.BackColor = Color.LimeGreen;
                    }
                    else if (SerialTry)
                    {
                        BtnConnect.BackColor = Color.Yellow;
                    }
                    else
                    {
                        BtnConnect.BackColor = Color.OrangeRed;
                    }


                });

            }
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (SerialTry)
            {

                SerialTry = false;
            }
            else
            {
                SerialTry = true;
            }
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /



        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        private void btnDisplayOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Table|*.xml";
            myDialog.Multiselect = true;
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
                foreach (String file in myDialog.FileNames)
                {
                    Thread nFormThread = new Thread(NewFormGraph);
                    nFormThread.SetApartmentState(ApartmentState.STA);
                    nFormThread.Name = "_GraphThread";

                    nFormThread.Start(file);
                }
            }
           

        }

        private void btnDisplayNew_Click(object sender, EventArgs e)
        {
            Thread nFormThread = new Thread(NewFormGraph);
            nFormThread.SetApartmentState(ApartmentState.STA);
            nFormThread.Name = "_GraphThread";

            string myFile = Application.StartupPath + "\\start_file_new.xml";

            nFormThread.Start(myFile);
        }

        public void NewFormGraph(object e)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormGraph myForm = new FormGraph();
            myForm.graphFile = (string)e;

            this.FormClosing += ((FormClosingEventHandler)
                delegate (object senderr, FormClosingEventArgs ee)
                {
                    if (myForm.Text != "")
                    {
                        myForm.Invoke((MethodInvoker)delegate
                        {
                            myForm.Close();
                        });
                    }
                });
            Application.Run(myForm);
        }
        ////_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        private void numBaud_ValueChanged(object sender, EventArgs e)
        {
            SerialReconn = true;
        }

        private void lstPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialReconn = true;
            this.BeginInvoke((MethodInvoker)delegate
            {
                string port = (string)lstPorts.SelectedItem;
                if (port != null && port.IndexOf("COM", 0) >= 0)
                {
                    SelectedPort = port;
                }
            });
        }


        private void lstPorts_DoubleClick(object sender, EventArgs e)
        {
            PortRefresh();
        }




        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /


    }


}