using System;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace ScoreAnalyst
{
    public partial class FormGradeDifference : Form
    {
        private bool finish = false;
        private Task task;
        public FormGradeDifference()
        {
            InitializeComponent();
            customInitialize();
        }
        private void customInitialize()
        {
            task = new Task(Report);
            task.ContinueWith(finished);
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
                MessageBox.Show("请选择输出文件");
                return;
            }

            
            btnStart.Enabled = false;
            btnStart.Text = "取消(&C)";


            task.Start();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report()
        {
            //StaticQueryHelper.Initialize(1);
            //StaticQueryHelper.Initialize(2);
            ExcelWriter writer = new ExcelWriter();
            int difference_type=0;
            if (rdbDifference1.Checked)
            {
                difference_type = 1;
            }
            bool contain_3th_section = false;
            if (chbContain_3th_section.Checked)
            {
                contain_3th_section = true;
            }

            bool valid_entry = false;
            if (chbValid_entry.Checked)
            {
                valid_entry = true;
            }

            //bool contain_composite = false;
            //if (chbContain_composite.Checked)
            //{
            //    contain_composite = true;
            //}

            DataTable dt2;
            foreach (XWorkbook w in Global.CurrentGrade.WorkbookList)
            {
                try
                {
                    if (chbScore.Checked)
                    {
                        dt2 = StaticQueryHelper.GetAllClassDifferenceEx(w.SubjectType,w.getSubjectList(),difference_type, valid_entry, contain_3th_section);
                    }
                    else
                    {
                        dt2 = StaticQueryHelper.GetAllClassDifference(w.SubjectType,w.getSubjectList(),difference_type, valid_entry, contain_3th_section);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }

                string title=w.SubjectType==1?"理科":"文科";
                writer.CreateSheet(title);
                if (chkbTranspose.Checked)
                {
                    DataTable dtt = dt2.Transpose();
                    writer.Write(0, 0, dtt);
                    dtt.Dispose();
                }
                else
                {
                    writer.WriteHeader(0, 0, dt2);
                    writer.Write(1, 0, dt2);
                }
            }

            writer.SaveAs(tbFileName.Text);
            //dt.Dispose();
            //dt2.Dispose();
            pgIncrease(100);
        }
        private void pgIncrease(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                    {
                        this.toolStripProgressBar1.Increment(value);
                    }));
            }
            else
            {
                this.toolStripProgressBar1.Increment(value);
            }
        }
        private void finished(Task t)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    finish = true;
                    this.btnStart.Text = "完成(&F)";
                    this.btnStart.Enabled = true;
                }));
            }
            else
            {
                finish = true;
                this.btnStart.Text = "完成(&F)";
                this.btnStart.Enabled = true;        
            }

        }



    }
}
