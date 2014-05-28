using System;
using System.Windows.Forms;

namespace ScoreAnalyst
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.Text = string.Format("成绩分析::[{0}]",Global.CurrentGrade.Name);
        }

        private void miImportData_Click(object sender, EventArgs e)
        {

            using (FormImport fi = new FormImport())
            {
                fi.ShowDialog();
            }
        }

        
        void MiExitClick(object sender, EventArgs e)
        {
        	this.Close();
        	Application.Exit();
        }

        private void miClearScore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确认要清空所有学生成绩吗?\r\n警告:清除后不可将不可恢复!!", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearData("score", "学生成绩");
            }
            else
            {
                return;
            }
        }

        private void clearData(string target,string alias)
        {

            int rows=StaticQueryHelper.ClearData(target);
            if (rows != 0)
            {
                MessageBox.Show(string.Format("已成功从表[{0}]中删除{1}条记录",alias,rows), "删除成功");
            }
        }

        private void miClearTeachers_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("您确认要清空所有任课教师数据吗?\r\n警告:清除后不可将不可恢复!!", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearData("teachers", "任课教师");
            }
            else
            {
                return;
            }
        }

        private void miClearClassInfo_Click(object sender, EventArgs e)
        {
               
                if (MessageBox.Show("您确认要清空所有班级信息及考核目标数据吗?\r\n警告:清除后不可将不可恢复!!", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                   clearData("class","班级信息及考核目标");
                }
                else
                {
                    return;
                }
        }

        private void miClearIgnore_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("您确认要清空所有不计考核学生名单吗?\r\n警告:清除后不可将不可恢复!!", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearData("ignore","不计考核学生名单");
            }
            else
            {
                return;
            }
        }

        private void miBrowserScore_Click(object sender, EventArgs e)
        {
            using (FormBrowserData fbd = new FormBrowserData("score", "学生成绩"))
            {
                fbd.ShowDialog();
            }
        }

        private void miBrowserTeachers_Click(object sender, EventArgs e)
        {
            using(FormBrowserData fbd = new FormBrowserData("teachers","任课教师一览表"))
            {
                fbd.ShowDialog();
            }
        }

        private void miBrowserClass_Click(object sender, EventArgs e)
        {
            using (FormBrowserData fbd = new FormBrowserData("class", "班级信息及考核指标"))
            {
                fbd.ShowDialog();
            }
        }

        private void miBrowserIgnore_Click(object sender, EventArgs e)
        {
            using (FormBrowserData fbd = new FormBrowserData("ignore", "不计考核学生名单"))
            {
                fbd.ShowDialog();
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            using (AboutBox1 about = new AboutBox1())
            {
                about.ShowDialog();
            }
        }

        private void tsmiGradeStatistics_Click(object sender, EventArgs e)
        {
            using (FormGradeStatistics fgs = new FormGradeStatistics())
            {
                fgs.ShowDialog();
            }
        }

        private void tsmiSection_Click(object sender, EventArgs e)
        {
            using (FormSectionByPosition fsbp = new FormSectionByPosition())
            {
                fsbp.ShowDialog();
            }
        }

        private void tsmiGradeDifference_Click(object sender, EventArgs e)
        {
            using (FormGradeDifference fgd = new FormGradeDifference())
            {
                fgd.ShowDialog();
            }
        }

  

        private void tsmiExportStudentScore_Click(object sender, EventArgs e)
        {
            using (FormReportScoreByClass frsbc = new FormReportScoreByClass())
            {
                frsbc.ShowDialog();
            }
        }

        private void tsmiNewReport_Click(object sender, EventArgs e)
        {
            using (FormNewReport fnr = new FormNewReport())
            {
                fnr.ShowDialog();
            }
        }

        private void tsmiBackupCurrentScore_Click(object sender, EventArgs e)
        {
            using (FormBackupCurrentScore fbcs = new FormBackupCurrentScore())
            {
                fbcs.ShowDialog();
            }


        }

        private void tsmiRestoreScore_Click(object sender, EventArgs e)
        {
            using (FormRestore fr = new FormRestore())
            {
                fr.ShowDialog();
            }
        }

        private void tsmiTest_Click(object sender, EventArgs e)
        {
            using (FormTest ft = new FormTest())
            {
                ft.ShowDialog();
            }
        }

        private void tsmiTeacherRank_Click(object sender, EventArgs e)
        {
            using (FormGradeTeacherRank fgtr = new FormGradeTeacherRank())
            {
                fgtr.ShowDialog();
            }

            
        }

        private void miConfigManager_Click(object sender, EventArgs e)
        {
            using (FormConfigManagerMain fcmm = new FormConfigManagerMain())
            {
                fcmm.ShowDialog();
            }
        }

        private void tsmiClearData_Click(object sender, EventArgs e)
        {
            using(FormClearData fcd=new FormClearData())
            {
                fcd.ShowDialog();
            }
        }

        private void tsmiBrowserDataSelecter_Click(object sender, EventArgs e)
        {
            using (FormBrowseDataSelecter fbds = new FormBrowseDataSelecter())
            {
                fbds.ShowDialog();
            }
        }

        private void tsmiInitialize_Click(object sender, EventArgs e)
        {
            using(FormInitilize fi=new FormInitilize())
            {
                fi.ShowDialog();
            }
        }


        
    }
}
