using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ScoreAnalyst
{
    public partial class FormReportScoreByClass : Form
    {
        Action<int> updateProgress;
        private bool finish = false;
        //Task task = null;
        public FormReportScoreByClass()
        {
            InitializeComponent();
            this.progressBar1.Maximum = 170;
            updateProgress = new Action<int>(DelegateUpdateProgress);
            //task = new Task(report);
            //task.ContinueWith(finished);
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".xls";
            sfd.Filter = "Excel文件|*.xls";
            sfd.CreatePrompt = false;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = sfd.FileName;
            }
            sfd.Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (finish)
            {
                this.Close();
                return;
            }
            if (tbFileName.Text.Length == 0)
            {
                MessageBox.Show("请选择输出文件位置!");
                return;
            }
            btnStart.Enabled = false;
            btnCancle.Enabled = false;
            if (this.chkIndivision.Checked)
            {
                ReportIndivision();
            }
            else
            {
                Report();
            }
            btnStart.Enabled = true;
            btnStart.Text = "完成(&F)";
            finish = true;
        }

        /// <summary>
        /// 分班级输出
        /// </summary>
        private void ReportIndivision()
        {
            ExcelWriter ew = new ExcelWriter();
            DataTable dt = null, dtClass = null;
            progressBar1.Maximum = 300;
            foreach (XWorkbook wb in Global.CurrentGrade.WorkbookList)
            {
                //StaticQueryHelper.Initialize(wb.SubjectType);
                dtClass = StaticQueryHelper.ExecuteQuery(string.Format("select distinct(班级) as 班级  from \"class\" where 类型={0} order by 班级", wb.SubjectType));
                foreach (DataRow dr in dtClass.Rows)
                {
                    dt = StaticQueryHelper.ExecuteQuery(string.Format("select  * from {0} where 班级={1}", getTableName(wb.SubjectType),dr[0].ToString()));
                    ew.CreateSheet(dr[0].ToString());
                    ew.WriteHeader(0, 0, dt);
                    ew.Write(1, 0, dt);
                    ew.CreateFreezePane(2, 1);
                    updateProgress(10);
                    Application.DoEvents();
                }
            }
            ew.SaveAs(tbFileName.Text);
            updateProgress(10);
            Application.DoEvents();
        }

        /// <summary>
        /// 不分班级输出
        /// </summary>
        private void Report()
        {
            ExcelWriter ew = new ExcelWriter();
            DataTable dt = null;//, dtClass = null;
            progressBar1.Maximum = 110;
            foreach (XWorkbook wb in Global.CurrentGrade.WorkbookList)
            {
                //StaticQueryHelper.Initialize(wb.SubjectType);
                ew.CreateSheet(getSubjectName(wb.SubjectType));
                dt = StaticQueryHelper.ExecuteQuery(string.Format("select * from {0};", getTableName(wb.SubjectType)));
                ew.WriteHeader(0, 0, dt);
                ew.Write(1, 0, dt);
                //ew.SetColumnWidth(0, 10);
                //ew.SetColumnWidth(1, 6);
                ew.CreateFreezePane(2, 0);

                updateProgress(50);
                Application.DoEvents();
            }
            ew.SaveAs(tbFileName.Text);
            dt.Dispose();
            updateProgress(10);
            Application.DoEvents();
        
        }
        /// <summary>
        /// 返回学科类别名称
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <returns></returns>
        private string getSubjectName(int subjectType)
        {
            string result = null;
            switch (subjectType)
            {
                case 1:
                    result = "理科";
                    break;
                case 2:
                    result = "文科";
                    break;
                case 9:
                    result = "综合";
                    break;
            }
            return result;
        }

        /// <summary>
        ///根据要查询的学科类别返回数据库中的表格名字
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <returns></returns>
        private string getTableName(int subjectType)
        {
            string table = null;
            switch (subjectType)
            { 
                case 1:
                    table = "science_score";
                    break;
                case 2:
                    table = "arts_score";
                    break;
                default:
                    table = "science_score";
                    break;
            }
            return table;
        }

        private void DelegateUpdateProgress(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>((int v) => {
                    progressBar1.Increment(v);
                }));
            }
            else
            {
                progressBar1.Increment(value);
            }
        }



        private void btnCancle_Click(object sender, EventArgs e)
        {

        }


       
    }
}
