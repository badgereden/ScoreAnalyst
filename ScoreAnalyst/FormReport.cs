using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScoreAnalyst
{
    public partial class FormReport : Form
    {
        protected bool finish = false;
        public FormReport()
        {
            InitializeComponent();
            CustomInitializeComponent();
        }

        //可以被子类重写
        public virtual void CustomInitializeComponent()
        {   }

        //必须被子类重写
        public virtual void Report() 
        {
            this.progressBar.Increment(100);
        }

        protected virtual void btnBrowser_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd=new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.DefaultExt = ".xls";
                sfd.Filter = "Excel97-2003文件|*.xls";
                sfd.CheckFileExists = false;
                sfd.CreatePrompt = false;
                sfd.OverwritePrompt = false;
                sfd.ShowDialog();
                this.tbFilePath.Text = sfd.FileName;
            }



        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (finish)
            {
                this.Close();
                return;
            }
            if (tbFilePath.TextLength == 0)
            {
                MessageBox.Show("请设置输出的Excel文件位置", "未指明输出文件位置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.btnEnter.Enabled = false;
            Report();
            this.btnEnter.Text = "完成(&F)";
            this.btnEnter.Enabled = true;
            finish = true;
        }




    }
}
