
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
    internal class Form1 : System.Windows.Forms.Form
    {
        public System.IO.Ports.SerialPort MSComm1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtChangeProgramNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdProgramNumberChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdTRG;
        private System.Windows.Forms.Button cmdCharTransmit;
        private System.Windows.Forms.TextBox _txtChangeChr_0;
        private System.Windows.Forms.TextBox txtBlockNumber;
        private System.Windows.Forms.TextBox txtProgramNumber;
        private System.Windows.Forms.Button cmdComChange;
        private System.Windows.Forms.Label lblConditionPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox txtDirectCommand;
        private System.Windows.Forms.Button cmdDirectTransmit;
        public System.Windows.Forms.TextBox txtTransmitData;
        public System.Windows.Forms.TextBox txtReceiveData;
        private System.Windows.Forms.Button cmdEnd;
        private System.ComponentModel.IContainer components;

        private void Form1_Load(System.Object eventSender, System.EventArgs eventArgs)
        {

            //通信条件の初期設定
            ComModule.gstrPort = "1";
            ComModule.gstrBaudrate = "38400";
            ComModule.gstrParity = "N";
            ComModule.gstrStopbit = "1";
            ComModule.gstrDelimiter = "13";
            ComModule.gstrHeader = "1";
            ComModule.gstrCheckSumOnOff = "0";

            //this.MSComm1.CommPort = Convert.ToInt16(ComModule.gstrPort);
            //this.MSComm1.Settings = ComModule.gstrBaudrate + "," + ComModule.gstrParity + "," + "8" + "," + ComModule.gstrStopbit;
            //this.MSComm1.InputLen = 0;
            //this.MSComm1.OutBufferSize = 4096;
            //this.MSComm1.InBufferSize = 4096;

            this.MSComm1.PortName = ComModule.gstrPort;
            this.MSComm1.BaudRate = Convert.ToInt32(ComModule.gstrBaudrate);
            this.MSComm1.Parity = System.IO.Ports.Parity.None;
            this.MSComm1.DataBits = 8;
            this.MSComm1.StopBits = System.IO.Ports.StopBits.One;
            this.MSComm1.ReadBufferSize = 4096;
            this.MSComm1.WriteBufferSize = 4096;
        }


        //設定NO.切替ボタンClickイベントプロシージャ
        private void cmdProgramNumberChange_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string strChangePNumber = null;
            int SendJudge = 0;

            //変更する設定NO.
            short intI = 0;

            //数値入力欄文字列確認
            for (intI = 1; intI <= Strings.Len(txtChangeProgramNumber.Text); intI++)
            {
                if (Strings.Asc(Strings.Mid(txtChangeProgramNumber.Text, intI, 1)) > 58)
                {
                    Interaction.MsgBox("半角の数字で入力してください。", MsgBoxStyle.OkOnly);
                    txtChangeProgramNumber.Text = "";
                    return;

                }
                else if (Strings.Asc(Strings.Mid(txtChangeProgramNumber.Text, intI, 1)) < 47)
                {
                    Interaction.MsgBox("半角の数字で入力してください。", MsgBoxStyle.OkOnly);
                    txtChangeProgramNumber.Text = "";
                    return;

                }

            }


            //設定NO.変更
            //各Textboxの入力確認
            if (string.IsNullOrEmpty(txtChangeProgramNumber.Text))
            {
                Interaction.MsgBox("変更する設定NO.を入力してください。", MsgBoxStyle.OkOnly);
            }
            else
            {
                //設定NO.の確定
                strChangePNumber = Convert.ToString(Convert.ToInt16(txtChangeProgramNumber.Text));

                //設定NO.変更コマンド生成
                ComModule.gstrCommand = "GA," + strChangePNumber;

                SendJudge = ComModule.Transmittier();
                //データ送信プロシージャ

                if(SendJudge == -1)
                {
                    MessageBox.Show("Send Error");
                    return;
                }

                ComModule.Receiver();
                //データ受信プロシージャ

                //送信データと受信データの表示
                txtTransmitData.Text = Strings.Mid(ComModule.gstrBuf1, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf1) - Convert.ToInt16(ComModule.gstrHeader));
                //送信データ表示
                txtReceiveData.Text = Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf2) - Convert.ToInt16(ComModule.gstrHeader));
                //受信データ表示

                //エラー処理
                if (ComModule.ErrorSyori() == 0)
                {
                    return;
                }
            }
        }


        //文字列変更送信ボタンClickイベントプロシージャ
        private void cmdCharTransmit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string strPNumber = null;
            //設定NO.
            string strSNumber = null;
            //ブロック番号
            short intI = 0;

            int SendJudge = 0;

            //数値入力欄文字列確認（設定NO.）
            for (intI = 1; intI <= Strings.Len(txtProgramNumber.Text); intI++)
            {
                if (Strings.Asc(Strings.Mid(txtProgramNumber.Text, intI, 1)) > 58)
                {
                    Interaction.MsgBox("半角の数字で入力してください。", MsgBoxStyle.OkOnly);
                    txtProgramNumber.Text = "";
                    return;

                }
                else if (Strings.Asc(Strings.Mid(txtProgramNumber.Text, intI, 1)) < 47)
                {
                    Interaction.MsgBox("半角の数字で入力してください。", MsgBoxStyle.OkOnly);
                    txtProgramNumber.Text = "";
                    return;

                }

            }

            //数値入力欄文字列確認（ブロック番号）
            for (intI = 1; intI <= Strings.Len(txtBlockNumber.Text); intI++)
            {
                if (Strings.Asc(Strings.Mid(txtBlockNumber.Text, intI, 1)) > 58)
                {
                    Interaction.MsgBox("半角の数字で入力してください。", MsgBoxStyle.OkOnly);
                    txtBlockNumber.Text = "";
                    return;

                }
                else if (Strings.Asc(Strings.Mid(txtBlockNumber.Text, intI, 1)) < 47)
                {
                    Interaction.MsgBox("半角の数字で入力してください。", MsgBoxStyle.OkOnly);
                    txtBlockNumber.Text = "";
                    return;

                }

            }

            //文字列の変更
            //各Textboxの入力確認
            //if (string.IsNullOrEmpty(txtChangeChr(0).Text)) {
            if (string.IsNullOrEmpty(_txtChangeChr_0.Text))
            {
                Interaction.MsgBox("変更文字列を入力してください。", MsgBoxStyle.OkOnly);

            }
            else if (string.IsNullOrEmpty(txtProgramNumber.Text))
            {
                Interaction.MsgBox("文字列を変更する設定NO.を入力してください。", MsgBoxStyle.OkOnly);

            }
            else if (string.IsNullOrEmpty(txtBlockNumber.Text))
            {
                Interaction.MsgBox("文字列を変更するブロック番号を入力してください。", MsgBoxStyle.OkOnly);

            }
            else
            {
                //設定NO.の確定
                strPNumber = Convert.ToString(Convert.ToInt16(txtProgramNumber.Text));

                //ブロック番号の確定
                strSNumber = Convert.ToString(Convert.ToInt16(txtBlockNumber.Text));

                //文字列変更コマンド生成
                ComModule.gstrCommand = "C2," + strPNumber + "," + strSNumber + "," + _txtChangeChr_0.Text;

                SendJudge = ComModule.Transmittier();
                //データ送信プロシージャ

                if (SendJudge == -1)
                {
                    MessageBox.Show("Send Error");
                    return;
                }

                ComModule.Receiver();
                //データ受信プロシージャ

                //送信データと受信データの表示
                txtTransmitData.Text = Strings.Mid(ComModule.gstrBuf1, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf1) - Convert.ToInt16(ComModule.gstrHeader));
                //送信データ表示
                txtReceiveData.Text = Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf2) - Convert.ToInt16(ComModule.gstrHeader));
                //受信データ表示

                //エラー処理
                if (ComModule.ErrorSyori() == 0)
                {
                    return;
                }

            }

        }

        //コマンド直接送信ボタンClickイベントプロシージャ
        private void cmdDirectTransmit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string[] strJointText = null;
            //txtDirectCommandテキストボックスから改行を削除するための仮配列
            short intCounter = 0;
            //strJointText配列の個数カウンタ
            int SendJudge = 0;

            //各Textboxの入力確認
            if (string.IsNullOrEmpty(txtDirectCommand.Text))
            {

                Interaction.MsgBox("コマンドを入力してください。", MsgBoxStyle.OkOnly);

            }
            else
            {

                ComModule.gstrCommand = "";
                //コマンドクリア

                //送信コマンド生成
                strJointText = Strings.Split(txtDirectCommand.Text, Constants.vbNewLine);
                //改行コードごとに配列に格納

                //配列を連結してコマンド生成
                for (intCounter = 0; intCounter <= Information.UBound(strJointText); intCounter++)
                {
                    ComModule.gstrCommand = ComModule.gstrCommand + strJointText[intCounter];//strJointText(intCounter);
                }

                SendJudge = ComModule.Transmittier();
                //データ送信プロシージャ

                if (SendJudge == -1)
                {
                    MessageBox.Show("Send Error");
                    return;
                }

                ComModule.Receiver();
                //データ受信プロシージャ

                //送信データと受信データの表示
                txtTransmitData.Text = Strings.Mid(ComModule.gstrBuf1, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf1) - Convert.ToInt16(ComModule.gstrHeader));
                //送信データ表示
                txtReceiveData.Text = Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf2) - Convert.ToInt16(ComModule.gstrHeader));
                //受信データ表示

                //エラー処理
                if (ComModule.ErrorSyori() == 0)
                {
                    return;
                }

            }

        }


        //通信条件切替ボタンClickイベントプロシージャ
        private void cmdComChange_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            //通信条件設定Formの表示
            //frmComProtocol.ShowDialog();
            frmComProtocol fc = new frmComProtocol();
            fc.TopLevel = false;
            this.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();
            //fc.ShowDialog();
            //Application.Run(fc);
        }


        //終了ボタンClickプロシージャ
        private void cmdEnd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            //通信ポートの確認とClose
            //if (this.MSComm1.PortOpen == true) {
            //	this.MSComm1.PortOpen = false;
            //}
            if (this.MSComm1.IsOpen == true)
            {
                this.MSComm1.Close();
            }

            System.Environment.Exit(0);

        }

        //印字開始ボタンClickプロシージャ
        private void cmdTRG_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            Byte bKeyProtectFlag = 0;
            int SendJudge = 0;

            do
            {
                System.Windows.Forms.Application.DoEvents();

                //レディー状態要求
                ComModule.gstrCommand = "RE";

                SendJudge = ComModule.Transmittier();
                //データ送信プロシージャ

                if (SendJudge == -1)
                {
                    MessageBox.Show("Send Error");
                    return;
                }

                ComModule.Receiver();

                //送信データと受信データの表示
                txtTransmitData.Text = Strings.Mid(ComModule.gstrBuf1, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf1) - Convert.ToInt16(ComModule.gstrHeader));
                txtReceiveData.Text = Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf2) - Convert.ToInt16(ComModule.gstrHeader));

                //エラー処理
                if (ComModule.ErrorSyori() == 0)
                {
                    return;
                }

                switch (Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader) + 5, 1))
                {
                    case "1":
                        //エラー発生

                        Interaction.MsgBox("エラーが発生しているため印字できません", MsgBoxStyle.OkOnly);
                        lblConditionPanel.Text = "印字中止";
                        //状態表示Labelへの表示
                        KeyReset();
                        //キープロテクト解除
                        //return;
                        bKeyProtectFlag = 1;


                        break;

                    case "2":
                        //エラー発生

                        lblConditionPanel.Text = "展開中";
                        //状態表示Labelへの表示
                        break;

                }
                if (bKeyProtectFlag == 1)
                {
                    return;
                }

            } while (!(Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader) + 5, 1) == "0"));

            lblConditionPanel.Text = "印字可能";
            //状態表示Labelへの表示


            //印字開始入力
            ComModule.gstrCommand = "TX";

            SendJudge = ComModule.Transmittier();
            //データ送信プロシージャ

            if (SendJudge == -1)
            {
                MessageBox.Show("Send Error");
                return;
            }

            lblConditionPanel.Text = "印字開始";
            //状態表示Labelへの表示
            KeyProtect();
            //キープロテクト

            ComModule.Receiver();
            //データ受信プロシージャ

            //送信データと受信データの表示
            txtTransmitData.Text = Strings.Mid(ComModule.gstrBuf1, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf1) - Convert.ToInt16(ComModule.gstrHeader));
            txtReceiveData.Text = Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf2) - Convert.ToInt16(ComModule.gstrHeader));

            if (Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader) + 3, 1) == "0")
            {
                lblConditionPanel.Text = "印字完了";
                //状態表示Labelへの表示
                KeyReset();
                //キープロテクト解除

                //エラー処理
            }
            else if (ComModule.ErrorSyori() == 0)
            {


                Interaction.MsgBox("", MsgBoxStyle.OkOnly);
                return;

            }

        }


        //キープロテクトプロシージャ
        private void KeyProtect()
        {

            cmdTRG.Enabled = false;
            cmdComChange.Enabled = false;
            cmdEnd.Enabled = false;
            cmdCharTransmit.Enabled = false;
            cmdDirectTransmit.Enabled = false;
            cmdProgramNumberChange.Enabled = false;

        }

        //キープロテクト解除プロシージャ
        private void KeyReset()
        {

            cmdTRG.Enabled = true;
            cmdComChange.Enabled = true;
            cmdEnd.Enabled = true;
            cmdCharTransmit.Enabled = true;
            cmdDirectTransmit.Enabled = true;
            cmdProgramNumberChange.Enabled = true;

        }
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MSComm1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdProgramNumberChange = new System.Windows.Forms.Button();
            this.txtChangeProgramNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblConditionPanel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTRG = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdCharTransmit = new System.Windows.Forms.Button();
            this._txtChangeChr_0 = new System.Windows.Forms.TextBox();
            this.txtBlockNumber = new System.Windows.Forms.TextBox();
            this.txtProgramNumber = new System.Windows.Forms.TextBox();
            this.cmdComChange = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdDirectTransmit = new System.Windows.Forms.Button();
            this.txtDirectCommand = new System.Windows.Forms.TextBox();
            this.txtTransmitData = new System.Windows.Forms.TextBox();
            this.txtReceiveData = new System.Windows.Forms.TextBox();
            this.cmdEnd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MSComm1
            // 
            this.MSComm1.DtrEnable = true;
            this.MSComm1.ReadBufferSize = 1024;
            this.MSComm1.WriteBufferSize = 512;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdProgramNumberChange);
            this.groupBox1.Controls.Add(this.txtChangeProgramNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定No. 変更";
            // 
            // cmdProgramNumberChange
            // 
            this.cmdProgramNumberChange.Location = new System.Drawing.Point(125, 30);
            this.cmdProgramNumberChange.Name = "cmdProgramNumberChange";
            this.cmdProgramNumberChange.Size = new System.Drawing.Size(135, 23);
            this.cmdProgramNumberChange.TabIndex = 1;
            this.cmdProgramNumberChange.Text = "設定No.　変更";
            this.cmdProgramNumberChange.UseVisualStyleBackColor = true;
            this.cmdProgramNumberChange.Click += new System.EventHandler(this.cmdProgramNumberChange_Click);
            // 
            // txtChangeProgramNumber
            // 
            this.txtChangeProgramNumber.Location = new System.Drawing.Point(6, 31);
            this.txtChangeProgramNumber.Name = "txtChangeProgramNumber";
            this.txtChangeProgramNumber.Size = new System.Drawing.Size(76, 22);
            this.txtChangeProgramNumber.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblConditionPanel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmdTRG);
            this.groupBox2.Location = new System.Drawing.Point(487, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "印字";
            // 
            // lblConditionPanel
            // 
            this.lblConditionPanel.BackColor = System.Drawing.SystemColors.Window;
            this.lblConditionPanel.Location = new System.Drawing.Point(71, 97);
            this.lblConditionPanel.Name = "lblConditionPanel";
            this.lblConditionPanel.Size = new System.Drawing.Size(150, 25);
            this.lblConditionPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "印字状態表示";
            // 
            // cmdTRG
            // 
            this.cmdTRG.Location = new System.Drawing.Point(74, 21);
            this.cmdTRG.Name = "cmdTRG";
            this.cmdTRG.Size = new System.Drawing.Size(121, 28);
            this.cmdTRG.TabIndex = 0;
            this.cmdTRG.Text = "印字開始信号";
            this.cmdTRG.UseVisualStyleBackColor = true;
            this.cmdTRG.Click += new System.EventHandler(this.cmdTRG_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdCharTransmit);
            this.groupBox3.Controls.Add(this._txtChangeChr_0);
            this.groupBox3.Controls.Add(this.txtBlockNumber);
            this.groupBox3.Controls.Add(this.txtProgramNumber);
            this.groupBox3.Location = new System.Drawing.Point(12, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 127);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文字列変更";
            // 
            // cmdCharTransmit
            // 
            this.cmdCharTransmit.Location = new System.Drawing.Point(336, 79);
            this.cmdCharTransmit.Name = "cmdCharTransmit";
            this.cmdCharTransmit.Size = new System.Drawing.Size(68, 22);
            this.cmdCharTransmit.TabIndex = 2;
            this.cmdCharTransmit.Text = "送信";
            this.cmdCharTransmit.UseVisualStyleBackColor = true;
            this.cmdCharTransmit.Click += new System.EventHandler(this.cmdCharTransmit_Click);
            // 
            // _txtChangeChr_0
            // 
            this._txtChangeChr_0.Location = new System.Drawing.Point(50, 79);
            this._txtChangeChr_0.Name = "_txtChangeChr_0";
            this._txtChangeChr_0.Size = new System.Drawing.Size(265, 22);
            this._txtChangeChr_0.TabIndex = 2;
            // 
            // txtBlockNumber
            // 
            this.txtBlockNumber.Location = new System.Drawing.Point(215, 34);
            this.txtBlockNumber.Name = "txtBlockNumber";
            this.txtBlockNumber.Size = new System.Drawing.Size(100, 22);
            this.txtBlockNumber.TabIndex = 1;
            // 
            // txtProgramNumber
            // 
            this.txtProgramNumber.Location = new System.Drawing.Point(50, 35);
            this.txtProgramNumber.Name = "txtProgramNumber";
            this.txtProgramNumber.Size = new System.Drawing.Size(100, 22);
            this.txtProgramNumber.TabIndex = 0;
            // 
            // cmdComChange
            // 
            this.cmdComChange.Location = new System.Drawing.Point(561, 167);
            this.cmdComChange.Name = "cmdComChange";
            this.cmdComChange.Size = new System.Drawing.Size(121, 48);
            this.cmdComChange.TabIndex = 1;
            this.cmdComChange.Text = "通信設定";
            this.cmdComChange.UseVisualStyleBackColor = true;
            this.cmdComChange.Click += new System.EventHandler(this.cmdComChange_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdDirectTransmit);
            this.groupBox4.Controls.Add(this.txtDirectCommand);
            this.groupBox4.Location = new System.Drawing.Point(12, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(754, 171);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "コマンド直接送信";
            // 
            // cmdDirectTransmit
            // 
            this.cmdDirectTransmit.Location = new System.Drawing.Point(595, 129);
            this.cmdDirectTransmit.Name = "cmdDirectTransmit";
            this.cmdDirectTransmit.Size = new System.Drawing.Size(140, 36);
            this.cmdDirectTransmit.TabIndex = 9;
            this.cmdDirectTransmit.Text = "送信";
            this.cmdDirectTransmit.UseVisualStyleBackColor = true;
            this.cmdDirectTransmit.Click += new System.EventHandler(this.cmdDirectTransmit_Click);
            // 
            // txtDirectCommand
            // 
            this.txtDirectCommand.AcceptsReturn = true;
            this.txtDirectCommand.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDirectCommand.Location = new System.Drawing.Point(50, 21);
            this.txtDirectCommand.MaxLength = 4091;
            this.txtDirectCommand.Multiline = true;
            this.txtDirectCommand.Name = "txtDirectCommand";
            this.txtDirectCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDirectCommand.Size = new System.Drawing.Size(672, 102);
            this.txtDirectCommand.TabIndex = 8;
            // 
            // txtTransmitData
            // 
            this.txtTransmitData.AcceptsReturn = true;
            this.txtTransmitData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTransmitData.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTransmitData.Location = new System.Drawing.Point(62, 429);
            this.txtTransmitData.MaxLength = 4091;
            this.txtTransmitData.Multiline = true;
            this.txtTransmitData.Name = "txtTransmitData";
            this.txtTransmitData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTransmitData.Size = new System.Drawing.Size(672, 102);
            this.txtTransmitData.TabIndex = 9;
            // 
            // txtReceiveData
            // 
            this.txtReceiveData.AcceptsReturn = true;
            this.txtReceiveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtReceiveData.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtReceiveData.Location = new System.Drawing.Point(62, 546);
            this.txtReceiveData.MaxLength = 4091;
            this.txtReceiveData.Multiline = true;
            this.txtReceiveData.Name = "txtReceiveData";
            this.txtReceiveData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiveData.Size = new System.Drawing.Size(672, 102);
            this.txtReceiveData.TabIndex = 10;
            // 
            // cmdEnd
            // 
            this.cmdEnd.Location = new System.Drawing.Point(607, 673);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(127, 38);
            this.cmdEnd.TabIndex = 10;
            this.cmdEnd.Text = "終了";
            this.cmdEnd.UseVisualStyleBackColor = true;
            this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(778, 723);
            this.Controls.Add(this.cmdEnd);
            this.Controls.Add(this.txtReceiveData);
            this.Controls.Add(this.txtTransmitData);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmdComChange);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Keyence LaserMaker ｻﾝﾌﾟﾙﾌﾟﾛｸﾞﾗﾑ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}