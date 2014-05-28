using System;
using System.Windows.Forms;

namespace ScoreAnalyst
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //选择年级后,再进入主界面.
            FormWelcome fsg = new FormWelcome();
            if (fsg.ShowDialog() == DialogResult.Yes)
            {
                Application.Run(new FormMain());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
