namespace LaserMakerCodeTransfer
{
    partial class LZM_TESTForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.InitTESTbutton = new System.Windows.Forms.Button();
            this.ChangeStringbutton = new System.Windows.Forms.Button();
            this.PrintTESTbutton = new System.Windows.Forms.Button();
            this.NowStatebox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InputStringBox = new System.Windows.Forms.TextBox();
            this.InputStringLabel = new System.Windows.Forms.Label();
            this.InitTESTResultLabel = new System.Windows.Forms.Label();
            this.ChangeStringTESTResultLabel = new System.Windows.Forms.Label();
            this.PrintTESTResultLabel = new System.Windows.Forms.Label();
            this.FormExitButton = new System.Windows.Forms.Button();
            this.LZM_Comm1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NowStateLabel = new System.Windows.Forms.Label();
            this.SettingPrintStringLabel = new System.Windows.Forms.Label();
            this.ErrorClearButton = new System.Windows.Forms.Button();
            this.NowStatebox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InitTESTbutton
            // 
            this.InitTESTbutton.Location = new System.Drawing.Point(12, 78);
            this.InitTESTbutton.Name = "InitTESTbutton";
            this.InitTESTbutton.Size = new System.Drawing.Size(199, 54);
            this.InitTESTbutton.TabIndex = 1;
            this.InitTESTbutton.Text = "InitializeTEST";
            this.InitTESTbutton.UseVisualStyleBackColor = true;
            this.InitTESTbutton.Click += new System.EventHandler(this.InitTESTbutton_Click);
            // 
            // ChangeStringbutton
            // 
            this.ChangeStringbutton.Location = new System.Drawing.Point(12, 152);
            this.ChangeStringbutton.Name = "ChangeStringbutton";
            this.ChangeStringbutton.Size = new System.Drawing.Size(199, 54);
            this.ChangeStringbutton.TabIndex = 2;
            this.ChangeStringbutton.Text = "StringChangeTEST";
            this.ChangeStringbutton.UseVisualStyleBackColor = true;
            this.ChangeStringbutton.Click += new System.EventHandler(this.ChangeStringbutton_Click);
            // 
            // PrintTESTbutton
            // 
            this.PrintTESTbutton.Location = new System.Drawing.Point(12, 361);
            this.PrintTESTbutton.Name = "PrintTESTbutton";
            this.PrintTESTbutton.Size = new System.Drawing.Size(199, 54);
            this.PrintTESTbutton.TabIndex = 3;
            this.PrintTESTbutton.Text = "LazerPrintTEST";
            this.PrintTESTbutton.UseVisualStyleBackColor = true;
            this.PrintTESTbutton.Click += new System.EventHandler(this.PrintTESTbutton_Click);
            // 
            // NowStatebox
            // 
            this.NowStatebox.Controls.Add(this.NowStateLabel);
            this.NowStatebox.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NowStatebox.Location = new System.Drawing.Point(12, 12);
            this.NowStatebox.Name = "NowStatebox";
            this.NowStatebox.Size = new System.Drawing.Size(405, 60);
            this.NowStatebox.TabIndex = 4;
            this.NowStatebox.TabStop = false;
            this.NowStatebox.Text = "Now State";
            this.NowStatebox.Enter += new System.EventHandler(this.NowStatebox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pass/NG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pass/NG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pass/NG";
            // 
            // InputStringBox
            // 
            this.InputStringBox.Location = new System.Drawing.Point(152, 234);
            this.InputStringBox.Name = "InputStringBox";
            this.InputStringBox.Size = new System.Drawing.Size(287, 22);
            this.InputStringBox.TabIndex = 8;
            this.InputStringBox.TextChanged += new System.EventHandler(this.InputStringBox_TextChanged);
            // 
            // InputStringLabel
            // 
            this.InputStringLabel.AutoSize = true;
            this.InputStringLabel.Location = new System.Drawing.Point(12, 237);
            this.InputStringLabel.Name = "InputStringLabel";
            this.InputStringLabel.Size = new System.Drawing.Size(134, 15);
            this.InputStringLabel.TabIndex = 9;
            this.InputStringLabel.Text = "Change String Input";
            // 
            // InitTESTResultLabel
            // 
            this.InitTESTResultLabel.AutoSize = true;
            this.InitTESTResultLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.InitTESTResultLabel.ForeColor = System.Drawing.Color.Lime;
            this.InitTESTResultLabel.Location = new System.Drawing.Point(343, 88);
            this.InitTESTResultLabel.Name = "InitTESTResultLabel";
            this.InitTESTResultLabel.Size = new System.Drawing.Size(0, 28);
            this.InitTESTResultLabel.TabIndex = 10;
            // 
            // ChangeStringTESTResultLabel
            // 
            this.ChangeStringTESTResultLabel.AutoSize = true;
            this.ChangeStringTESTResultLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChangeStringTESTResultLabel.ForeColor = System.Drawing.Color.Lime;
            this.ChangeStringTESTResultLabel.Location = new System.Drawing.Point(343, 162);
            this.ChangeStringTESTResultLabel.Name = "ChangeStringTESTResultLabel";
            this.ChangeStringTESTResultLabel.Size = new System.Drawing.Size(0, 28);
            this.ChangeStringTESTResultLabel.TabIndex = 11;
            // 
            // PrintTESTResultLabel
            // 
            this.PrintTESTResultLabel.AutoSize = true;
            this.PrintTESTResultLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintTESTResultLabel.ForeColor = System.Drawing.Color.Lime;
            this.PrintTESTResultLabel.Location = new System.Drawing.Point(343, 371);
            this.PrintTESTResultLabel.Name = "PrintTESTResultLabel";
            this.PrintTESTResultLabel.Size = new System.Drawing.Size(0, 28);
            this.PrintTESTResultLabel.TabIndex = 12;
            // 
            // FormExitButton
            // 
            this.FormExitButton.Location = new System.Drawing.Point(621, 371);
            this.FormExitButton.Name = "FormExitButton";
            this.FormExitButton.Size = new System.Drawing.Size(119, 44);
            this.FormExitButton.TabIndex = 13;
            this.FormExitButton.Text = "End";
            this.FormExitButton.UseVisualStyleBackColor = true;
            this.FormExitButton.Click += new System.EventHandler(this.FormExitButton_Click);
            // 
            // LZM_Comm1
            // 
            this.LZM_Comm1.BaudRate = 38400;
            this.LZM_Comm1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.LZM_Comm1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SettingPrintStringLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 60);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting Print String";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // NowStateLabel
            // 
            this.NowStateLabel.AutoSize = true;
            this.NowStateLabel.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NowStateLabel.Location = new System.Drawing.Point(68, 18);
            this.NowStateLabel.Name = "NowStateLabel";
            this.NowStateLabel.Size = new System.Drawing.Size(0, 28);
            this.NowStateLabel.TabIndex = 14;
            this.NowStateLabel.Click += new System.EventHandler(this.NowStateLabel_Click);
            // 
            // SettingPrintStringLabel
            // 
            this.SettingPrintStringLabel.AutoSize = true;
            this.SettingPrintStringLabel.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SettingPrintStringLabel.Location = new System.Drawing.Point(65, 18);
            this.SettingPrintStringLabel.Name = "SettingPrintStringLabel";
            this.SettingPrintStringLabel.Size = new System.Drawing.Size(0, 28);
            this.SettingPrintStringLabel.TabIndex = 15;
            // 
            // ErrorClearButton
            // 
            this.ErrorClearButton.Location = new System.Drawing.Point(486, 20);
            this.ErrorClearButton.Name = "ErrorClearButton";
            this.ErrorClearButton.Size = new System.Drawing.Size(199, 54);
            this.ErrorClearButton.TabIndex = 14;
            this.ErrorClearButton.Text = "Error Clear";
            this.ErrorClearButton.UseVisualStyleBackColor = true;
            this.ErrorClearButton.Click += new System.EventHandler(this.ErrorClearButton_Click);
            // 
            // LZM_TESTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 427);
            this.Controls.Add(this.ErrorClearButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FormExitButton);
            this.Controls.Add(this.PrintTESTResultLabel);
            this.Controls.Add(this.ChangeStringTESTResultLabel);
            this.Controls.Add(this.InitTESTResultLabel);
            this.Controls.Add(this.InputStringLabel);
            this.Controls.Add(this.InputStringBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NowStatebox);
            this.Controls.Add(this.PrintTESTbutton);
            this.Controls.Add(this.ChangeStringbutton);
            this.Controls.Add(this.InitTESTbutton);
            this.Name = "LZM_TESTForm";
            this.Text = "LZM_TESTForm";
            this.Load += new System.EventHandler(this.LZM_TESTForm_Load);
            this.NowStatebox.ResumeLayout(false);
            this.NowStatebox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InitTESTbutton;
        private System.Windows.Forms.Button ChangeStringbutton;
        private System.Windows.Forms.Button PrintTESTbutton;
        private System.Windows.Forms.GroupBox NowStatebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputStringBox;
        private System.Windows.Forms.Label InputStringLabel;
        private System.Windows.Forms.Label InitTESTResultLabel;
        private System.Windows.Forms.Label ChangeStringTESTResultLabel;
        private System.Windows.Forms.Label PrintTESTResultLabel;
        private System.Windows.Forms.Button FormExitButton;
        public System.IO.Ports.SerialPort LZM_Comm1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label NowStateLabel;
        public System.Windows.Forms.Label SettingPrintStringLabel;
        private System.Windows.Forms.Button ErrorClearButton;
    }
}