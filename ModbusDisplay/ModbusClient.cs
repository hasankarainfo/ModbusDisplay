/*
Copyright (c) 2018-2020 Rossmann-Engineering
Permission is hereby granted, free of charge, 
to any person obtaining a copy of this software
and associated documentation files (the "Software"),
to deal in the Software without restriction, 
including without limitation the rights to use, 
copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit 
persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission 
notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

using System.IO;
using ZylSoft.Serial;

namespace EasyModbus
{
    /// <summary>
    /// Implements a ModbusClient.
    /// </summary>
    public partial class ModbusClient
    {
        public enum RegisterOrder { LowHigh = 0, HighLow = 1 };

        private byte[] crc = new byte[2];
        private byte functionCode;
        private byte[] startingAddress = new byte[2];
        private byte[] quantity = new byte[2];

        private int baudRate = 9600;
        private int connectTimeout = 1000;
        public int ReturnTimeout = 1000;
        public byte[] receiveData;
        public byte[] sendData;
        private SerialPort serialport;
        private SerialParityBits parity = SerialParityBits.Even;
        private SerialStopBits stopBits = SerialStopBits.Sb1Bit;
        //private bool connected = false;
        public int NumberOfRetries { get; set; } = 3;
        private int countRetries = 0;

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public ModbusClient()
        {
            this.serialport = new SerialPort();
        }

        /// <summary>
        /// Establish connection to Master device in case of Modbus TCP. Opens COM-Port in case of Modbus RTU
        /// </summary>
        public void Connect()
        {
            if (serialport != null)
            {
                if (!serialport.IsConnected())
                {
                    serialport.AutoReceive = false;
                    serialport.Port = SerialCommPort.Custom;
                    serialport.BaudRate = SerialBaudRate.Custom;
                    serialport.CustomBaudRate = (uint)baudRate;

                    serialport.DataWidth = SerialDataWidth.Dw8Bits;
                    serialport.ParityBits = parity;
                    serialport.StopBits = stopBits;

                    serialport.HardwareFlowControl = SerialHardwareFlowControl.None;
                    serialport.SoftwareFlowControl = SerialSoftwareFlowControl.None;

                    serialport.WriteTotalTimeoutConstant = 10000;
                    serialport.InputBuffer = 0x4000;// maximum 0x4000
                    serialport.OutputBuffer = 0x10000;

                    serialport.DiscardNulls = false;
                    serialport.EnableDtrOnOpen = false;
                    serialport.EnableRtsOnOpen = false;

                    //serialport.ReadTotalTimeoutConstant = (uint)connectTimeout;
                    //serialport.Open();
                    serialport.Open();

                    serialport.ClearInputBuffer();
                    serialport.ClearOutputBuffer();

                }

                return;
            }

        }



        /// <summary>
        /// Calculates the CRC16 for Modbus-RTU
        /// </summary>
        /// <param name="data">Byte buffer to send</param>
        /// <param name="numberOfBytes">Number of bytes to calculate CRC</param>
        /// <param name="startByte">First byte in buffer to start calculating CRC</param>
        public static UInt16 calculateCRC(byte[] data, UInt16 numberOfBytes, int startByte)
        {
            byte[] auchCRCHi = {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40
            };

            byte[] auchCRCLo = {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4,
            0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD,
            0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7,
            0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE,
            0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2,
            0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB,
            0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
            0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88,
            0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80,
            0x40
            };
            UInt16 usDataLen = numberOfBytes;
            byte uchCRCHi = 0xFF;
            byte uchCRCLo = 0xFF;
            int i = 0;
            int uIndex;
            while (usDataLen > 0)
            {
                usDataLen--;
                if ((i + startByte) < data.Length)
                {
                    uIndex = uchCRCLo ^ data[i + startByte];
                    uchCRCLo = (byte)(uchCRCHi ^ auchCRCHi[uIndex]);
                    uchCRCHi = auchCRCLo[uIndex];
                }
                i++;
            }
            return (UInt16)((UInt16)uchCRCHi << 8 | uchCRCLo);
        }


        private byte[] DataRead(int bytesToRead)
        {
            //readBuffer = new byte[256];
            int numbytes = 0;
            long ticksWait = TimeSpan.TicksPerMillisecond * ReturnTimeout;//((40*10000000) / this.baudRate);

            DateTime dateTimeLastRead = DateTime.Now;
            numbytes = serialport.GetAvailableInputBufferSize();
            while (numbytes < bytesToRead)
            {
                numbytes = serialport.GetAvailableInputBufferSize();
                System.Threading.Thread.Sleep(1);
                if ((DateTime.Now.Ticks - dateTimeLastRead.Ticks) > ticksWait)
                    break;
            }


            //byte[] rxbytearray = new byte[numbytes];
            byte[] rxbytearray = serialport.ReadBuffer(); // (rxbytearray, 0, numbytes);
            if (rxbytearray == null || rxbytearray.Length < bytesToRead)
            {
                return null;
            }
            receiveData = new byte[rxbytearray.Length];
            Array.Copy(rxbytearray, 0, receiveData, 0, rxbytearray.Length);
            return rxbytearray;
        }


        /// <summary>
        /// Read Holding Registers from Master device (FC3).
        /// </summary>
        /// <param name="startingAddress">First holding register to be read</param>
        /// <param name="quantity">Number of holding registers to be read</param>
        /// <returns>Int Array which contains the holding registers</returns>
        public int[] ReadHoldingRegisters(byte unitIdentifier, int startingAddress, int quantity)
        {
            if (serialport != null)
                if (!serialport.IsConnected())
                {
                    return null;
                }

            if (startingAddress > 65535 | quantity > 125)
            {
                return null;
            }
            int[] response;
            this.functionCode = 0x03;
            this.startingAddress = BitConverter.GetBytes(startingAddress);
            this.quantity = BitConverter.GetBytes(quantity);
            
            Byte[] data = new byte[]{
                            unitIdentifier,
                            this.functionCode,
                            this.startingAddress[1],
                            this.startingAddress[0],
                            this.quantity[1],
                            this.quantity[0],
                            this.crc[0],
                            this.crc[1]
            };
            crc = BitConverter.GetBytes(calculateCRC(data, 6, 0));
            data[6] = crc[0];
            data[7] = crc[1];
            if (serialport != null)
            {
                int bytesToRead = 5 + 2 * quantity;

                serialport.ClearInputBuffer();
                serialport.SendByteArray(data);
                data = DataRead(bytesToRead);

            }
            if (data == null || data[1] == 0x83 )
            {
                return null;
            }
            int len = data[2];
            if (len > data.Length - 4)
            {
                return null;
            }

            if (serialport != null)
            {
               
                crc = BitConverter.GetBytes(calculateCRC(data, (ushort)(len + 3), 0));
                if (crc[0] != data[len + 3] ||
                    crc[1] != data[len + 4] ||
                    data[0] != unitIdentifier)
                {
                    if (NumberOfRetries <= countRetries)
                    {
                        return null;
                    }
                    else
                    {
                        countRetries++;
                        return ReadHoldingRegisters(unitIdentifier, startingAddress, quantity);
                    }
                }
            }
            response = new int[quantity];
            for (int i = 0; i < quantity; i++)
            {
                byte lowByte;
                byte highByte;
                highByte = data[3 + i * 2];
                lowByte = data[3 + i * 2 + 1];

                data[3 + i * 2] = lowByte;
                data[3 + i * 2 + 1] = highByte;

                response[i] = BitConverter.ToInt16(data, (3 + i * 2));
            }
            return (response);
        }



        /// <summary>
        /// Write multiple registers to Master device (FC16).
        /// </summary>
        /// <param name="startingAddress">First register to be written</param>
        /// <param name="values">register Values to be written</param>
        public bool WriteMultipleRegisters(byte unitIdentifier, int startingAddress, int[] values)
        {

            byte byteCount = (byte)(values.Length * 2);
            byte[] quantityOfOutputs = BitConverter.GetBytes((int)values.Length);
            if (serialport != null)
                if (!serialport.IsConnected())
                {
                    return false;
                }

            this.functionCode = 0x10;
            this.startingAddress = BitConverter.GetBytes(startingAddress);

            Byte[] data = new byte[7 + 2 + values.Length * 2];
            data[0] = unitIdentifier;
            data[1] = this.functionCode;
            data[2] = this.startingAddress[1];
            data[3] = this.startingAddress[0];
            data[4] = quantityOfOutputs[1];
            data[5] = quantityOfOutputs[0];
            data[6] = byteCount;
            for (int i = 0; i < values.Length; i++)
            {
                byte[] singleRegisterValue = BitConverter.GetBytes((int)values[i]);
                data[7 + i * 2] = singleRegisterValue[1];
                data[8 + i * 2] = singleRegisterValue[0];
            }
            crc = BitConverter.GetBytes(calculateCRC(data, (ushort)(data.Length - 2), 0));
            data[data.Length - 2] = crc[0];
            data[data.Length - 1] = crc[1];
            if (serialport != null)
            {
                int bytesToRead = 8;

                serialport.ClearInputBuffer();
                serialport.SendByteArray(data);

                data = DataRead(bytesToRead);
                if (data == null)
                {
                    return false;
                }


                crc = BitConverter.GetBytes(calculateCRC(data, 6, 0));
                if ((crc[0] != data[6] | crc[1] != data[7]))
                {
                    if (NumberOfRetries <= countRetries)
                    {
                        return false;

                    }
                    else
                    {
                        countRetries++;
                        return WriteMultipleRegisters(unitIdentifier, startingAddress, values);
                    }
                }
            }

            if (data[1] == 0x90 ||
               data[0] != unitIdentifier)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Close connection to Master Device.
        /// </summary>
        public void Disconnect()
        {
            if (serialport != null)
            {
                if (serialport.IsConnected())
                    serialport.Close();
                return;
            }

        }

        /// <summary>
        /// Destructor - Close connection to Master Device.
        /// </summary>
		~ModbusClient()
        {
            if (serialport != null)
            {
                if (serialport.IsConnected())
                    serialport.Close();
                return;
            }

        }

        /// <summary>
        /// Returns "TRUE" if Client is connected to Server and "FALSE" if not. In case of Modbus RTU returns if COM-Port is opened
        /// </summary>
		public bool Connected
        {
            get
            {
                if (serialport != null)
                {
                    return (serialport.IsConnected());
                }

                return false;

            }
        }


        /// <summary>
        /// Gets or Sets the Baudrate for serial connection (Default = 9600)
        /// </summary>
        public int Baudrate
        {
            get
            {
                return baudRate;
            }
            set
            {
                baudRate = value;
            }
        }

        /// <summary>
        /// Gets or Sets the of Parity in case of serial connection
        /// </summary>
        public SerialParityBits Parity
        {
            get
            {
                if (serialport != null)
                    return parity;
                else
                    return SerialParityBits.Even;
            }
            set
            {
                if (serialport != null)
                    parity = value;
            }
        }


        /// <summary>
        /// Gets or Sets the number of stopbits in case of serial connection
        /// </summary>
        public SerialStopBits StopBits
        {
            get
            {
                if (serialport != null)
                    return stopBits;
                else
                    return SerialStopBits.Sb1Bit;
            }
            set
            {
                if (serialport != null)
                    stopBits = value;
            }
        }

        /// <summary>
        /// Gets or Sets the connection Timeout in case of ModbusTCP connection
        /// </summary>
        public int ConnectionTimeout
        {
            get
            {
                return connectTimeout;
            }
            set
            {
                connectTimeout = value;
            }
        }

        /// <summary>
        /// Gets or Sets the serial Port
        /// </summary>
        public string Port
        {
            get
            {

                return serialport.CustomPortName;
            }
            set
            {
                this.serialport.CustomPortName = value;
            }
        }



    }
}
