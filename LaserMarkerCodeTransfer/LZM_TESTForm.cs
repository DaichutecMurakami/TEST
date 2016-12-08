using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserMakerCodeTransfer
{
    public partial class LZM_TESTForm : Form
    {
        public LZM_TESTForm()
        {
            InitializeComponent();
            NowStateLabel.Text = StateUpdate();
        }

        public static string StateUpdate()
        {
            int state;

            state = LaserMakerState.LaserMakerMain("CHECK_STATE",null);
            switch(state)
            {
                case 0x00:
                    return "NEED_INITIALIZE";
                case 0x01:
                    return "IDLE";
                case 0x0F:
                    return "INITIALIZING";
                case 0x1F:
                    return "PRINTING";
                case 0x2F:
                    return "STRING_CHANGING";
                default:
                    return "UNKNOWN ERROR";

            }
        }

        private void FormExitButton_Click(object sender, EventArgs e)
        {
            if(this.LZM_Comm1.IsOpen == true)
            {
                this.LZM_Comm1.Close();
            }
            System.Environment.Exit(0);
        }

        private void LZM_Comm1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void LZM_TESTForm_Load(object sender, EventArgs e)
        {

        }

        private void InitTESTbutton_Click(object sender, EventArgs e)
        {
            LaserMakerState.LaserMakerMain("INITSTART",null);
            NowStateLabel.Text = StateUpdate();

            if (StateUpdate() == "IDLE")
            {
                InitTESTResultLabel.ForeColor = Color.Lime;
                InitTESTResultLabel.Text = "PASS";
            }
            else
            {
                InitTESTResultLabel.ForeColor = Color.Red;
                InitTESTResultLabel.Text = "NG";
            }
        }

        private void ChangeStringbutton_Click(object sender, EventArgs e)
        {
            LaserMakerState.LaserMakerMain("CHANGESTRING", InputStringBox.Text);
            SettingPrintStringLabel.Text = InputStringBox.Text;
            NowStateLabel.Text = StateUpdate();

            if (StateUpdate() == "IDLE")
            {
                ChangeStringTESTResultLabel.ForeColor = Color.Lime;
                ChangeStringTESTResultLabel.Text = "PASS";
            }
            else
            {
                ChangeStringTESTResultLabel.ForeColor = Color.Red;
                ChangeStringTESTResultLabel.Text = "NG";
            }
        }

        private void PrintTESTbutton_Click(object sender, EventArgs e)
        {
            LaserMakerState.LaserMakerMain("PRINTSTART", null);
            NowStateLabel.Text = StateUpdate();

            if (StateUpdate() == "IDLE")
            {
                PrintTESTResultLabel.ForeColor = Color.Lime;
                PrintTESTResultLabel.Text = "PASS";
            }
            else
            {
                PrintTESTResultLabel.ForeColor = Color.Red;
                PrintTESTResultLabel.Text = "NG";
            }
        }

        private void NowStatebox_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void InputStringBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NowStateLabel_Click(object sender, EventArgs e)
        {

        }

        private void ErrorClearButton_Click(object sender, EventArgs e)
        {
            LaserMakerState.LaserMakerMain("ERROR_CLR", null);
            NowStateLabel.Text = StateUpdate();

            InitTESTResultLabel.Text = "";
            ChangeStringTESTResultLabel.Text = "";
            PrintTESTResultLabel.Text = "";
        }
    }
}
