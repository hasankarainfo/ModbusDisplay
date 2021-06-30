using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace ModbusDisplay
{
    public class dgvLib : DataGridView
    {
        public DataTable dt;
        public RegisterOrder regOrder = RegisterOrder.LowHigh;

        public enum RegisterOrder { LowHigh = 0, HighLow = 1 };

        public dgvLib(string tableName, string tableNamespace) : base()
        {
            dt = new DataTable(tableName, tableNamespace);
            defInit();
            typeValueCons();
        }



        static DataGridViewComboBoxColumn newTypeColumn()
        {
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Items.AddRange(Types);
            return col;
        }

        public static string[] Types = {"U8+U8","UInt16", "UInt32", "UInt64", "Int16", "Int32", "Int64",
                 "Float","Double"};

        public object[] DefRow = { false, "Row", "UInt16", 1, "", "0", "0", "0", "\0\0" };


        public void defRowAdd()
        {
            dt.Rows.Add(DefRow);

        }

        private void defInit()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            AllowDrop = true;
            AllowUserToOrderColumns = true;
            BackgroundColor = System.Drawing.SystemColors.ControlLight;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            DefaultCellStyle = dataGridViewCellStyle2;
            Dock = System.Windows.Forms.DockStyle.Fill;
            EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            GridColor = System.Drawing.SystemColors.ControlDarkDark;
            ImeMode = System.Windows.Forms.ImeMode.NoControl;
            Location = new System.Drawing.Point(0, 0);
            Name = "dgv";
            RowHeadersWidth = 10;
            RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            Size = new System.Drawing.Size(401, 412);
            TabIndex = 0;

        }
        public void typeValueCons()
        {
            DataColumn ColEn = new DataColumn("En", typeof(bool));
            DataColumn ColName = new DataColumn("Name", typeof(string));
            DataColumn ColType = new DataColumn("Type", typeof(string));
            DataColumn ColLen = new DataColumn("Len", typeof(long));
            DataColumn ColAddr = new DataColumn("Addr", typeof(string));
            DataColumn ColVal = new DataColumn("Value", typeof(string));
            DataColumn ColHex = new DataColumn("Hex", typeof(string));
            DataColumn ColBin = new DataColumn("Bin", typeof(string));
            DataColumn ColAscii = new DataColumn("Ascii", typeof(string));

            DataGridViewCheckBoxColumn dgvCbEn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn dgvTbName = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn dgvCmbType = newTypeColumn();
            NumericUpDownColumn dgvNudLen = new NumericUpDownColumn();
            DataGridViewTextBoxColumn dgvTbAddr = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dgvTbValue = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dgvTbHex = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dgvTbBin = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dgvTbAscii = new DataGridViewTextBoxColumn();



            // datagridview kurulumu yapilir
            dgvCbEn.Width = 26;
            dgvTbName.Width = 120;
            dgvCmbType.Width = 80;
            dgvNudLen.Width = 40;
            dgvTbAddr.Width = 80;
            dgvTbValue.Width = 100;
            dgvTbHex.Width = 100;
            dgvTbBin.Width = 200;
            dgvTbAscii.Width = 200;

            dgvCbEn.TrueValue = true;
            dgvCbEn.FalseValue = false;
            dgvNudLen.ReadOnly = true;


            dgvCbEn.HeaderText = "En";
            dgvTbName.HeaderText = "Name";
            dgvCmbType.HeaderText = "Type";
            dgvNudLen.HeaderText = "Len   ";
            dgvTbAddr.HeaderText = "Addr";
            dgvTbValue.HeaderText = "Value";
            dgvTbHex.HeaderText = "Hexadecimal";
            dgvTbBin.HeaderText = "Binary 1098 7654 3210 9876 5432 1098 7654 3210 ";
            dgvTbAscii.HeaderText = "Ascii";


            dgvCbEn.Name = "En";
            dgvTbName.Name = "Name";
            dgvCmbType.Name = "Type";
            dgvNudLen.Name = "Len";
            dgvTbAddr.Name = "Addr";
            dgvTbValue.Name = "Value";
            dgvTbHex.Name = "Hex";
            dgvTbBin.Name = "Bin";
            dgvTbAscii.Name = "Ascii";

            dgvCbEn.DataPropertyName = "En";
            dgvTbName.DataPropertyName = "Name";
            dgvCmbType.DataPropertyName = "Type";
            dgvNudLen.DataPropertyName = "Len";
            dgvTbAddr.DataPropertyName = "Addr";
            dgvTbValue.DataPropertyName = "Value";
            dgvTbHex.DataPropertyName = "Hex";
            dgvTbBin.DataPropertyName = "Bin";
            dgvTbAscii.DataPropertyName = "Ascii";


            dgvCbEn.DefaultCellStyle.NullValue = false;
            dgvTbName.DefaultCellStyle.NullValue = null;
            dgvCmbType.DefaultCellStyle.NullValue = null;
            dgvNudLen.DefaultCellStyle.NullValue = null;
            dgvTbAddr.DefaultCellStyle.NullValue = null;
            dgvTbValue.DefaultCellStyle.NullValue = null;
            dgvTbHex.DefaultCellStyle.NullValue = null;
            dgvTbBin.DefaultCellStyle.NullValue = null;
            dgvTbAscii.DefaultCellStyle.NullValue = null;


            dgvCbEn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTbName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCmbType.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvNudLen.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTbAddr.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTbValue.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTbHex.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTbBin.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTbAscii.SortMode = DataGridViewColumnSortMode.NotSortable;


            dgvTbBin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            Columns.Clear();
            Columns.Add(dgvCbEn);
            Columns.Add(dgvTbName);
            Columns.Add(dgvCmbType);
            Columns.Add(dgvNudLen);
            Columns.Add(dgvTbAddr);
            Columns.Add(dgvTbValue);
            Columns.Add(dgvTbHex);
            Columns.Add(dgvTbBin);
            Columns.Add(dgvTbAscii);

            //dgv.RowHeadersVisible = true;
            //dgv.RowHeadersWidth = 10;

            // datatable kurulumu yapilir
            ColEn.DefaultValue = false;
            ColName.DefaultValue = "New";
            ColType.DefaultValue = "UInt16";
            ColLen.DefaultValue = 1;
            ColAddr.DefaultValue = "";
            ColVal.DefaultValue = "";
            ColHex.DefaultValue = "";
            ColBin.DefaultValue = "";
            ColAscii.DefaultValue = "\0\0";

            ColEn.AllowDBNull = true;
            ColName.AllowDBNull = true;
            ColType.AllowDBNull = true;
            ColLen.AllowDBNull = false;
            ColAddr.AllowDBNull = true;
            ColVal.AllowDBNull = true;
            ColHex.AllowDBNull = true;
            ColBin.AllowDBNull = true;
            ColAscii.AllowDBNull = true;

            dt.Columns.Add(ColEn);
            dt.Columns.Add(ColName);
            dt.Columns.Add(ColType);
            dt.Columns.Add(ColLen);
            dt.Columns.Add(ColAddr);
            dt.Columns.Add(ColVal);
            dt.Columns.Add(ColHex);
            dt.Columns.Add(ColBin);
            dt.Columns.Add(ColAscii);

            DataSource = dt;


        }


        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public void RegToAll(int[] reg, int row)
        {
            if (isRow(row) && reg != null && reg.Length != 0)
            { // row mevcut


                string[] myStr = new string[4];
                string type = (string)this["Type", row].Value;
                int len = typeSizeof(row);

                if (type == "U8+U8")
                {
                    byte[] bytes = new byte[reg.Length * 2];

                    for (int i = 0; i < reg.Length; i++)
                    {
                        byte[] cnv = BitConverter.GetBytes((UInt16)reg[i]);
                        bytes[i * 2 + 0] = cnv[0];
                        bytes[i * 2 + 1] = cnv[1];
                    }

                    string hexstr = "";
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        hexstr += Convert.ToString(bytes[i], 16).PadLeft(len * 1, '0') + " ";
                    }

                    this["Value", row].Value = "-";
                    this["Hex", row].Value = hexstr;
                    this["Bin", row].Value = "-";
                    string stringValue = Encoding.ASCII.GetString(bytes);
                    int val = stringValue.IndexOf("\0");
                    stringValue = stringValue.Substring(0, val);
                    this["Ascii", row].Value = stringValue;
                }
                else
                {
                    ulong valHex = RegToLong(reg, row);
                    valHex = longLimiter(valHex, type);
                    myStr[0] = typStrCnv(valHex, type);

                    myStr[1] = Convert.ToString((long)valHex, 16).PadLeft(len * 2, '0');
                    myStr[1] = StrSpacer(myStr[1], 2);
                    myStr[2] = Convert.ToString((long)valHex, 2).PadLeft(len * 8, '0');
                    myStr[2] = StrSpacer(myStr[2], 4);
                    myStr[3] = Encoding.UTF8.GetString(BitConverter.GetBytes(valHex));

                    this["Value", row].Value = myStr[0];
                    this["Hex", row].Value = myStr[1];
                    this["Bin", row].Value = myStr[2];
                    this["Ascii", row].Value = myStr[3];
                }
            }
        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public int[] SelToReg(string Sel, int row)
        {
            int[] valReg = null;
            try
            {
                if (isRow(row))
                { // row mevcut
                    string ValueStr = "";
                    long len = (long)this["Len", row].Value;
                    string TypeStr = (string)this["Type", row].Value;
                    int count = (typeSizeof(row) / 2) * (int)len;
                    int valBase = 0;
                    byte[] bytes = null;
                    ulong valHex = 0;

                    valReg = new int[count];

                    switch (Sel)
                    {
                        case "Value":
                            if (this["Value", row].Value != null)
                            {
                                ValueStr = StrExtr((string)this["Value", row].Value);
                                valBase = 10;
                            }
                            break;
                        case "Hex":
                            if (this["Hex", row].Value != null)
                            {
                                ValueStr = StrExtr((string)this["Hex", row].Value);
                                valBase = 16;
                            }
                            break;

                        case "Bin":
                            if (this["Bin", row].Value != null)
                            {
                                ValueStr = StrExtr((string)this["Bin", row].Value);
                                valBase = 2;
                            }
                            break;

                        case "Ascii":
                            if (this["Ascii", row].Value != null)
                            {
                                ValueStr = ((string)this["Ascii", row].Value);
                                valBase = 256;
                            }
                            break;
                    }

                    //reg = TypeConverter.ValueToRegister(valStr, TypeStr, baseVal, regOrder);
                    switch (TypeStr)
                    {
                        case ("U8+U8"):
                            if (valBase == 16)
                            {
                                bytes = new byte[count * 2];
                                for (int i = 0; i < count * 2 && i < ValueStr.Length / 2; i++)
                                {
                                    string myStr = ValueStr.Substring(i * 2, 2);
                                    bytes[i] = Convert.ToByte(myStr, valBase);
                                }
                            }
                            else if (valBase == 256)
                            {
                                /*Ascii*/
                                bytes = Encoding.ASCII.GetBytes(ValueStr);
                                Array.Resize(ref bytes, count * 2);
                            }

                            break;

                        case ("Int16"):
                            valHex = (ulong)Convert.ToInt16(ValueStr, valBase);
                            bytes = BitConverter.GetBytes(valHex);
                            break;
                        case ("UInt16"):
                            valHex = (ulong)Convert.ToUInt16(ValueStr, valBase);
                            bytes = BitConverter.GetBytes(valHex);
                            break;

                        case ("Int32"):
                            valHex = (ulong)Convert.ToInt32(ValueStr, valBase);
                            bytes = BitConverter.GetBytes(valHex);
                            break;
                        case ("UInt32"):
                            valHex = (ulong)Convert.ToUInt32(ValueStr, valBase);
                            bytes = BitConverter.GetBytes(valHex);
                            break;

                        case ("Int64"):
                            valHex = (ulong)Convert.ToInt64(ValueStr, valBase);
                            bytes = BitConverter.GetBytes(valHex);
                            break;
                        case ("UInt64"):
                            valHex = (ulong)Convert.ToUInt64(ValueStr, valBase);
                            bytes = BitConverter.GetBytes(valHex);
                            break;

                        case ("Float"):
                            //valHex = (ulong)Convert.ToSingle(ValueStr);
                            valHex = f2ext(Convert.ToSingle(ValueStr));
                            bytes = BitConverter.GetBytes(valHex);
                            break;
                        case ("Double"):
                            valHex = dbl2ext(Convert.ToDouble(ValueStr));
                            bytes = BitConverter.GetBytes(valHex);
                            break;

                        default: break;
                    }


                    for (int i = 0; i < count; i++)
                    {
                        if (regOrder == RegisterOrder.LowHigh)
                        {
                            valReg[i] = bytes[i * 2] + 256 * bytes[i * 2 + 1];
                        }
                        else
                        {
                            valReg[count - i - 1] = bytes[i * 2] + 256 * bytes[i * 2 + 1];
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            return valReg;
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        public ulong RegToLong(int[] rec, int row)
        {
            ulong longVal = 0;
            if (rec == null) return longVal;

            int len = typeSizeof(row);
            int count = len / 2;
            if (rec.Length < count) return longVal;

            byte[] bytes = new byte[8];
            for (int i = 0; i < count; i++)
            {
                byte[] grn;
                if (regOrder == RegisterOrder.LowHigh)
                    grn = BitConverter.GetBytes(rec[i]);
                else grn = BitConverter.GetBytes(rec[count - i - 1]);

                bytes[i * 2 + 0] = grn[0];
                bytes[i * 2 + 1] = grn[1];
            }
            longVal = BitConverter.ToUInt64(bytes, 0);

            return longVal;
        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        static unsafe public ulong f2ext(float val)
        { return (*((ulong*)&val)); }
        static unsafe public ulong dbl2ext(double val)
        { return (*((ulong*)&val)); }

        static unsafe public float ext2f(ulong val)
        { return (*((float*)&val)); }
        static unsafe public double ext2dbl(ulong val)
        { return (*((double*)&val)); }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public double typValCnv(ulong val, int  row)
        {
            double myVal = 0;
            string type = getValStr("Type",row);
            switch (type)
            {
                case ("Int16"): myVal = (short)val; break;
                case ("Int32"): myVal = (int)val; break;
                case ("Int64"): myVal = (long)val; break;

                case ("U8+U8"): myVal = (byte)val; break;
                case ("UInt16"): myVal = (ushort)val; break;
                case ("UInt32"): myVal = (uint)val; break;
                case ("UInt64"): myVal = (val); break;

                case ("Float"): myVal = (ext2f(val)); break;

                case ("Double"): myVal = (ext2dbl(val)); break;

                default: break;
            }
            return myVal;
        }
        public static string typStrCnv(ulong val, string type)
        {
            string myStr = "0";
            try
            {
                switch (type)
                {
                    case ("Int16"): myStr = Convert.ToString((short)val, 10); break;
                    case ("Int32"): myStr = Convert.ToString((int)val, 10); break;
                    case ("Int64"): myStr = Convert.ToString((long)val, 10); break;

                    case ("U8+U8"): myStr = Convert.ToString((byte)val, 10); break;
                    case ("UInt16"): myStr = Convert.ToString((ushort)val, 10); break;
                    case ("UInt32"): myStr = Convert.ToString((uint)val, 10); break;
                    case ("UInt64"): myStr = Convert.ToString(val); break;

                    case ("Float"): myStr = Convert.ToString(Convert.ToSingle(ext2f(val))); break;

                    case ("Double"): myStr = Convert.ToString(Convert.ToDouble(ext2dbl(val))); break;

                    default: break;
                }
            }
            catch { }
            return myStr;
        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        public static ulong longLimiter(ulong val, string type)
        {
            ulong valHex = 0;
            try
            {
                switch (type)
                {
                    case ("Int16"): valHex = (ushort)val; break;
                    case ("Int32"): valHex = (uint)val; break;
                    case ("Int64"): valHex = (ulong)val; break;

                    case ("U8+U8"): valHex = (byte)val; break;
                    case ("UInt16"): valHex = (ushort)val; break;
                    case ("UInt32"): valHex = (uint)val; break;
                    case ("UInt64"): valHex = (ulong)val; break;

                    case ("Float"): valHex = (uint)(val); break;
                    case ("Double"): valHex = (ulong)(val); break;

                    default: break;
                }
            }
            catch { }
            return valHex;
        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public bool chk(int row)
        {
            //lock (this)
            {
                if (isRow(row)) if (Rows[row].Cells["En"].Value != DBNull.Value)
                        return (bool)Rows[row].Cells["En"].Value;
            }
            return false;
        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public void chk(int row, bool val)
        {
            //lock (this)
            {
                if (isRow(row)) Rows[row].Cells["En"].Value = val;
            }

        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public bool isRow(int row)
        {
            return (-1 < row && (row + 1) < Rows.Count);

        }

        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /
        public string getValStr(string col, int row)
        {
            //lock (this)
            {
               
                if (isRow(row))
                    if (Rows[row].Cells[col].Value != DBNull.Value)
                        return (string)Rows[row].Cells[col].Value;
            }

            return null;
        }

        public long getLen( int row)
        {
            //lock (this)
            {
                if (isRow(row))
                    if (Rows[row].Cells["Len"].Value != DBNull.Value)
                        return (long)Rows[row].Cells["Len"].Value;
            }

            return 1;
        }
        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /

        public static string StrExtr(string str)
        {
            try
            {
                if (str == null)
                    return "0";// || str == ""
                return str.Replace(" ", "").Replace("0x", "");
            }
            catch
            {
                return "0";
            }
        }
        public static string StrSpacer(string str, int dig)
        {
            string myStr = "";
            try
            {

                for (int i = 0; i < str.Length / dig; i++) myStr += str.Substring(i * dig, dig) + " ";
            }
            catch { }
            return myStr;
        }


        //_ /__ /___ /____ /_____ /______ /_______ /________ /_________ /__________ /



        public byte typeSizeof(int row)
        {
            byte valRtn = 0;
            string TypeStr = getValStr("Type", row);
            try
            {
                switch (TypeStr)
                {
                    case ("U8+U8"): valRtn = 2; break;

                    case ("Int16"):
                    case ("UInt16"): valRtn = 2; break;

                    case ("Int32"):
                    case ("UInt32"):
                    case ("Float"):
                        valRtn = 4; break;

                    case ("Int64"):
                    case ("UInt64"):

                    case ("Double"): valRtn = 8; break;

                    default: valRtn = 0; break;
                }
            }
            catch { }
            return valRtn;
        }

    }

    public class NumericUpDownColumn : DataGridViewColumn
    {
        public NumericUpDownColumn()
            : base(new NumericUpDownCell())
        {
        }

        public NumericUpDownColumn(decimal min, decimal max)
    : base(new NumericUpDownCell(min, max))
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell)))
                {
                    throw new InvalidCastException("Must be a NumericUpDownCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class NumericUpDownCell : DataGridViewTextBoxCell
    {
        private readonly decimal min;
        private readonly decimal max;

        public NumericUpDownCell()
            : base()
        {
            Style.Format = "F0";
        }
        public NumericUpDownCell(decimal min, decimal max)
            : base()
        {
            this.min = min;
            this.max = max;
            Style.Format = "F0";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericUpDownEditingControl ctl = DataGridView.EditingControl as NumericUpDownEditingControl;
            ctl.Minimum = this.min;
            ctl.Maximum = 100000;
            ctl.Increment = 1;
            ctl.Value = Convert.ToDecimal(this.Value);
        }

        public override Type EditType
        {
            get { return typeof(NumericUpDownEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(Decimal); }
        }

        public override object DefaultNewRowValue
        {
            get { return null; }
        }
    }

    public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        private DataGridView dataGridViewControl;
        private bool valueIsChanged = false;
        private int rowIndexNum;

        public NumericUpDownEditingControl()
            : base()
        {
            this.DecimalPlaces = 0;
        }

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridViewControl; }
            set { dataGridViewControl = value; }
        }

        public object EditingControlFormattedValue
        {
            get { return this.Value.ToString("F0"); }
            set { this.Value = Decimal.Parse(value.ToString()); }
        }
        public int EditingControlRowIndex
        {
            get { return rowIndexNum; }
            set { rowIndexNum = value; }
        }
        public bool EditingControlValueChanged
        {
            get { return valueIsChanged; }
            set { valueIsChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return (keyData == Keys.Left || keyData == Keys.Right ||
                keyData == Keys.Up || keyData == Keys.Down ||
                keyData == Keys.Home || keyData == Keys.End ||
                keyData == Keys.PageDown || keyData == Keys.PageUp);
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Value.ToString();
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        protected override void OnValueChanged(EventArgs e)
        {
            valueIsChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }
}
