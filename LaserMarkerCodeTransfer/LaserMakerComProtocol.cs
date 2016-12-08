
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

// ERROR: Not supported in C#: OptionDeclaration
namespace LaserMakerCodeTransfer
{
    internal class frmComProtocol : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox Frame1;
        private System.Windows.Forms.GroupBox Frame2;
        private System.Windows.Forms.Label label_SumCheck;
        private System.Windows.Forms.Label label_Delimiter;
        private System.Windows.Forms.Label label_Stopbit;
        private System.Windows.Forms.Label label_baudrate;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.ComboBox cboCheckSumOnOff;
        private System.Windows.Forms.ComboBox cboDelimiter;
        private System.Windows.Forms.ComboBox cboStopbit;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboBaudrate;
        private string strPortOld;

        private void frmComProtocol_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            Form1 f = new Form1();
            strPortOld = ComModule.gstrPort;

            //通信ポートの確認とClose
            //if (Form1.MSComm1.PortOpen == true) {
            //	Form1.MSComm1.PortOpen = false;
            //}
            if (f.MSComm1.IsOpen == true)
            {
                f.MSComm1.Open();
            }

            //各パラメータの初期化
            //ポートの初期化
            switch (ComModule.gstrPort)
            {
                case "1":
                    cboPort.Text = "COM1";
                    break;
                case "2":
                    cboPort.Text = "COM2";
                    break;
                case "3":
                    cboPort.Text = "COM3";
                    break;
                case "4":
                    cboPort.Text = "COM4";
                    break;
                case "5":
                    cboPort.Text = "COM5";
                    break;
                case "6":
                    cboPort.Text = "COM6";
                    break;
                case "7":
                    cboPort.Text = "COM7";
                    break;
                case "8":
                    cboPort.Text = "COM8";
                    break;
                case "9":
                    cboPort.Text = "COM9";
                    break;
                case "10":
                    cboPort.Text = "COM10";
                    break;
            }

            //ボーレートの初期化
            switch (ComModule.gstrBaudrate)
            {
                case "38400":
                    cboBaudrate.Text = "38400";
                    break;
                case "19200":
                    cboBaudrate.Text = "19200";
                    break;
                case "9600":
                    cboBaudrate.Text = "9600";
                    break;
                case "4800":
                    cboBaudrate.Text = "4800";
                    break;
                case "2400":
                    cboBaudrate.Text = "2400";
                    break;
            }

            //パリティの初期化
            switch (ComModule.gstrParity)
            {
                case "N":
                    cboParity.Text = "なし";
                    break;
                case "E":
                    cboParity.Text = "偶数";
                    break;
                case "O":
                    cboParity.Text = "奇数";
                    break;
            }

            //ストップビットの初期化
            switch (ComModule.gstrStopbit)
            {
                case "1":
                    cboStopbit.Text = "1bit";
                    break;
                case "2":
                    cboStopbit.Text = "2bit";
                    break;
            }

            //デリミタの初期化
            switch (ComModule.gstrDelimiter)
            {
                case "3":
                    cboDelimiter.Text = "ETX";
                    break;
                case "13":
                    cboDelimiter.Text = "CR";
                    break;
            }

            //チェックサムの初期化
            switch (ComModule.gstrCheckSumOnOff)
            {
                case "0":
                    cboCheckSumOnOff.Text = "なし";
                    break;
                case "1":
                    cboCheckSumOnOff.Text = "あり";
                    break;
            }

        }


        //通信条件の設定
        private void cmdOk_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            Form1 f = new Form1();
            Byte bjdgPrityBits = 0, bjdgStopBits = 0;
            int jdgOpen = 0;

            //ポートの選択
            switch (cboPort.Text)
            {
                case "COM1":
                    ComModule.gstrPort = "1";
                    break;
                case "COM2":
                    ComModule.gstrPort = "2";
                    break;
                case "COM3":
                    ComModule.gstrPort = "3";
                    break;
                case "COM4":
                    ComModule.gstrPort = "4";
                    break;
            }

            //ボーレートの選択
            switch (cboBaudrate.Text)
            {
                case "38400":
                    ComModule.gstrBaudrate = "38400";
                    break;
                case "19200":
                    ComModule.gstrBaudrate = "19200";
                    break;
                case "9600":
                    ComModule.gstrBaudrate = "9600";
                    break;
                case "4800":
                    ComModule.gstrBaudrate = "4800";
                    break;
                case "2400":
                    ComModule.gstrBaudrate = "2400";
                    break;
            }

            //パリティの選択
            switch (cboParity.Text)
            {
                case "なし":
                    ComModule.gstrParity = "N";
                    bjdgPrityBits = 0;

                    break;
                case "偶数":
                    ComModule.gstrParity = "E";
                    bjdgPrityBits = 1;

                    break;
                case "奇数":
                    ComModule.gstrParity = "O";
                    bjdgPrityBits = 2;

                    break;
            }

            //ストップビットの選択
            switch (cboStopbit.Text)
            {
                case "1bit":
                    ComModule.gstrStopbit = "1";
                    bjdgStopBits = 0;

                    break;
                case "2bit":
                    ComModule.gstrStopbit = "2";
                    bjdgStopBits = 1;

                    break;
            }

            //デリミタの選択
            switch (cboDelimiter.Text)
            {
                case "ETX":
                    ComModule.gstrDelimiter = "3";
                    ComModule.gstrHeader = "2";
                    break;
                case "CR":
                    ComModule.gstrDelimiter = "13";
                    ComModule.gstrHeader = "1";
                    break;
            }

            //チェックサムの選択
            switch (cboCheckSumOnOff.Text)
            {
                case "なし":
                    ComModule.gstrCheckSumOnOff = "0";
                    break;
                case "あり":
                    ComModule.gstrCheckSumOnOff = "1";
                    break;
            }

            //通信条件の設定
            // ERROR: Not supported in C#: OnErrorStatement

            //Form1.MSComm1.CommPort = Convert.ToInt16(ComModule.gstrPort);
            //Form1.MSComm1.Settings = ComModule.gstrBaudrate + "," + ComModule.gstrParity + "," + "8" + "," + ComModule.gstrStopbit;
            //Form1.MSComm1.PortOpen = true;

            f.MSComm1.PortName = ComModule.gstrPort;
            f.MSComm1.BaudRate = Convert.ToInt32(ComModule.gstrBaudrate);

            switch (bjdgPrityBits)
            {
                case 0://none
                    f.MSComm1.Parity = System.IO.Ports.Parity.None;
                    break;
                case 1://even
                    f.MSComm1.Parity = System.IO.Ports.Parity.Even;
                    break;
                case 2://odd
                    f.MSComm1.Parity = System.IO.Ports.Parity.Odd;
                    break;
            }

            f.MSComm1.DataBits = 8;

            switch (bjdgStopBits)
            {
                case 0:
                    f.MSComm1.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case 1:
                    f.MSComm1.StopBits = System.IO.Ports.StopBits.Two;
                    break;
            }

            try
            {
                    f.MSComm1.Open();
            }
            catch (UnauthorizedAccessException)
            {
                //MessageBox.Show("Access Error");
                //MessageBox.Show(e.Message);

                jdgOpen = -1;
            }
            catch (ArgumentOutOfRangeException)
            {
                //MessageBox.Show("Out of Range Argument Error");
                //MessageBox.Show(e.Message);

                jdgOpen = -1;
            }
            catch (ArgumentException)
            {
                //MessageBox.Show("Argument Error");
                //MessageBox.Show(e.Message);

                jdgOpen = -1;
            }
            catch (System.IO.IOException)
            {
                //MessageBox.Show("System I/O Error");
                //MessageBox.Show(e.Message);

                jdgOpen = -1;
            }
            catch (InvalidOperationException)
            {
                //MessageBox.Show("InvalidOperation Error");
                //MessageBox.Show(e.Message);

                jdgOpen = -1;
            }
            catch (Exception)
            {
                //MessageBox.Show("Unknown Error");
                //MessageBox.Show(e.Message);

                jdgOpen = -1;
            }

            if(jdgOpen == -1)
            {
                MessageBox.Show("COM Open Fail");
                this.Close();
                return;
            }

            this.Close();
            return;
            //err_Renamed:
            //
            //    ComModule.gstrPort = strPortOld;
            //    //Form1.MSComm1.CommPort = Convert.ToInt16(ComModule.gstrPort);
            //     f.MSComm1.PortName = ComModule.gstrPort;
            //	Interaction.MsgBox("Port Error");
        }


        //キャンセルボタンClickイベントプロシージャ
        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            this.Close();

        }
        public frmComProtocol()
        {
            InitializeComponent();
            Load += frmComProtocol_Load;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.label_SumCheck = new System.Windows.Forms.Label();
            this.label_Delimiter = new System.Windows.Forms.Label();
            this.label_Stopbit = new System.Windows.Forms.Label();
            this.label_baudrate = new System.Windows.Forms.Label();
            this.label_Parity = new System.Windows.Forms.Label();
            this.cboCheckSumOnOff = new System.Windows.Forms.ComboBox();
            this.cboDelimiter = new System.Windows.Forms.ComboBox();
            this.cboStopbit = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.Frame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ポート";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cboPort.Location = new System.Drawing.Point(146, 36);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(114, 23);
            this.cboPort.TabIndex = 1;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(397, 51);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(111, 41);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(397, 125);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(111, 38);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // Frame1
            // 
            this.Frame1.Controls.Add(this.label_SumCheck);
            this.Frame1.Controls.Add(this.label_Delimiter);
            this.Frame1.Controls.Add(this.label_Stopbit);
            this.Frame1.Controls.Add(this.label_baudrate);
            this.Frame1.Controls.Add(this.label_Parity);
            this.Frame1.Controls.Add(this.cboCheckSumOnOff);
            this.Frame1.Controls.Add(this.cboDelimiter);
            this.Frame1.Controls.Add(this.cboStopbit);
            this.Frame1.Controls.Add(this.cboParity);
            this.Frame1.Controls.Add(this.cboBaudrate);
            this.Frame1.Controls.Add(this.label1);
            this.Frame1.Controls.Add(this.cboPort);
            this.Frame1.Location = new System.Drawing.Point(12, 12);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(361, 316);
            this.Frame1.TabIndex = 4;
            this.Frame1.TabStop = false;
            this.Frame1.Text = "通信条件";
            // 
            // label_SumCheck
            // 
            this.label_SumCheck.AutoSize = true;
            this.label_SumCheck.Location = new System.Drawing.Point(60, 258);
            this.label_SumCheck.Name = "label_SumCheck";
            this.label_SumCheck.Size = new System.Drawing.Size(71, 15);
            this.label_SumCheck.TabIndex = 11;
            this.label_SumCheck.Text = "チェックサム";
            // 
            // label_Delimiter
            // 
            this.label_Delimiter.AutoSize = true;
            this.label_Delimiter.Location = new System.Drawing.Point(83, 219);
            this.label_Delimiter.Name = "label_Delimiter";
            this.label_Delimiter.Size = new System.Drawing.Size(47, 15);
            this.label_Delimiter.TabIndex = 10;
            this.label_Delimiter.Text = "デリミタ";
            // 
            // label_Stopbit
            // 
            this.label_Stopbit.AutoSize = true;
            this.label_Stopbit.Location = new System.Drawing.Point(45, 172);
            this.label_Stopbit.Name = "label_Stopbit";
            this.label_Stopbit.Size = new System.Drawing.Size(80, 15);
            this.label_Stopbit.TabIndex = 9;
            this.label_Stopbit.Text = "ストップビット";
            // 
            // label_baudrate
            // 
            this.label_baudrate.AutoSize = true;
            this.label_baudrate.Location = new System.Drawing.Point(60, 91);
            this.label_baudrate.Name = "label_baudrate";
            this.label_baudrate.Size = new System.Drawing.Size(65, 15);
            this.label_baudrate.TabIndex = 8;
            this.label_baudrate.Text = "ボーレート";
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(83, 136);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(47, 15);
            this.label_Parity.TabIndex = 7;
            this.label_Parity.Text = "パリティ";
            // 
            // cboCheckSumOnOff
            // 
            this.cboCheckSumOnOff.FormattingEnabled = true;
            this.cboCheckSumOnOff.Items.AddRange(new object[] {
            "なし",
            "あり"});
            this.cboCheckSumOnOff.Location = new System.Drawing.Point(146, 255);
            this.cboCheckSumOnOff.Name = "cboCheckSumOnOff";
            this.cboCheckSumOnOff.Size = new System.Drawing.Size(114, 23);
            this.cboCheckSumOnOff.TabIndex = 6;
            // 
            // cboDelimiter
            // 
            this.cboDelimiter.FormattingEnabled = true;
            this.cboDelimiter.Items.AddRange(new object[] {
            "ETX",
            "CR"});
            this.cboDelimiter.Location = new System.Drawing.Point(146, 211);
            this.cboDelimiter.Name = "cboDelimiter";
            this.cboDelimiter.Size = new System.Drawing.Size(114, 23);
            this.cboDelimiter.TabIndex = 5;
            // 
            // cboStopbit
            // 
            this.cboStopbit.FormattingEnabled = true;
            this.cboStopbit.Items.AddRange(new object[] {
            "1 bit",
            "2 bit"});
            this.cboStopbit.Location = new System.Drawing.Point(146, 169);
            this.cboStopbit.Name = "cboStopbit";
            this.cboStopbit.Size = new System.Drawing.Size(114, 23);
            this.cboStopbit.TabIndex = 4;
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Items.AddRange(new object[] {
            "なし",
            "偶数",
            "奇数"});
            this.cboParity.Location = new System.Drawing.Point(146, 128);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(114, 23);
            this.cboParity.TabIndex = 3;
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.cboBaudrate.Location = new System.Drawing.Point(146, 83);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(114, 23);
            this.cboBaudrate.TabIndex = 2;
            // 
            // Frame2
            // 
            this.Frame2.Location = new System.Drawing.Point(12, 404);
            this.Frame2.Name = "Frame2";
            this.Frame2.Size = new System.Drawing.Size(361, 164);
            this.Frame2.TabIndex = 5;
            this.Frame2.TabStop = false;
            this.Frame2.Text = "固定条件";
            // 
            // frmComProtocol
            // 
            this.ClientSize = new System.Drawing.Size(520, 580);
            this.Controls.Add(this.Frame2);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmComProtocol";
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
