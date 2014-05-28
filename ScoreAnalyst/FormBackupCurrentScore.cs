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
    public partial class FormBackupCurrentScore : Form
    {
        private bool finished = false;
        public FormBackupCurrentScore()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (finished)
            {
                this.Close();
                return;
            }
                

            btnBackup.Enabled = false;
            backupCurrentScore();
            btnBackup.Text = "完成(&F)";
            btnBackup.Enabled = true;
            finished = true;
        }

        private void backupCurrentScore()
        {
            string examName = tbExamName.Text.Trim();
            if (examName.Length == 0)
                return;

            int rows = StaticQueryHelper.BackupCurrentScore(examName, this.dateTimePicker1.Value);
            MessageBox.Show(string.Format("已将当前学生成绩备份,记录数量为:{0}", rows), "备份完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }



    }
}
