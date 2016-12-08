using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserMakerCodeTransfer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //frmComProtocol fc = new frmComProtocol();
            //Application.Run(fc);

            //Form1 f = new Form1();
            LZM_TESTForm f = new LZM_TESTForm();
            
            Application.Run(f);
            
            //Application.Run(new Form1());
        }
    }
}
