using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace ScoreAnalyst
{
    

    public partial class FormGradeStatistics : Form
    {
        private bool finished = false;
        //private Task task;
        private Action<int> ProgressIncrease;

        //这个字符串数组需要在LoadConfig函数中加载配置.
        //private string[,] items = null;
        private string[] subjectName = new string[10];
        public FormGradeStatistics()
        {
            InitializeComponent();
            customInitialize();
        }
        public void customInitialize()
        {
            //string[] subjectName = new string[10];
            subjectName[0] = "未指定";
            subjectName[1] = "理科";
            subjectName[2] = "文科";
            subjectName[9] = "综合";

            //LoadConfig();
            UpdateListView();
            ProgressIncrease = new Action<int>(
            i =>
            {
                progressBar1.Increment(i);
            }
            );

            //task = new Task(report);
            //task.ContinueWith(Finished);

        }

        private void UpdateListView()
        {
            listView1.BeginUpdate();


            foreach (XWorkbook wb in Global.CurrentGrade.WorkbookList)
            {
                foreach (XSheet sh in wb.SheetList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "";
                    item.SubItems.Add(subjectName[wb.SubjectType]);
                    item.SubItems.Add(sh.Subject);
                    item.SubItems.Add(sh.GradeStep.ToString());
                    item.SubItems.Add(sh.GradeCount.ToString());
                    item.SubItems.Add(sh.TotalScore.ToString());
                    if (sh.Ignore)
                    {
                        item.Checked = false;
                    }
                    else
                    {
                        item.Checked = true;
                    }
                    listView1.Items.Add(item);
                }
            
            
            }
            listView1.EndUpdate();
        }
        

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.CreatePrompt = false;
            sfd.CheckPathExists = false;
            sfd.DefaultExt = "*.xls";
            sfd.Filter = "Excel文件|*.xls";
            sfd.FilterIndex = 0;
            sfd.Title = "输出文件位置";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = sfd.FileName;
            }
            sfd.Dispose();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0)
            {
                MessageBox.Show("请选择输出位置!");
                return;
            }

            if (finished)
            {
                this.Close();
                return;
            }
            btnEnter.Enabled = false;
            btnEnter.Text = "进行中...";

            report();

            btnEnter.Text = "完成";
            finished = true;
            btnEnter.Enabled = true;



        //    try
        //    {
        //        task.Start();
        //    }
        //    catch (AggregateException ae)
        //    {
        //        MessageBox.Show("运算出错\r\n" + ae.Message);
        //    }


        }


        private void report()
        {
            ExcelWriter ew = new ExcelWriter();
            ew.CreateSheet("年级分段累计");
            //int subjectType, step, count, score;
            int startColumn = 0;
            //string subject;
            Dictionary<int, bool> initList = new Dictionary<int, bool>(3);
            initList.Add(1, false);
            initList.Add(2, false);
            initList.Add(9, false);
            DataTable dt = null, dt2 = null;
            int i = 0;
            foreach (XWorkbook wb in Global.CurrentGrade.WorkbookList)
            {
                //StaticQueryHelper.Initialize(wb.SubjectType);
                foreach (XSheet sh in wb.SheetList)
                 {
                     if (sh.Ignore)
                     {
                         continue;
                     }

                     startColumn = 0;
                     ew.Write(i * 3, startColumn, string.Format("{0}-{1}", subjectName[wb.SubjectType], sh.Subject));
                     ew.MergeCells(i * 3, startColumn, i * 3, 6);

                    ew.Write(i * 3 + 1, startColumn, "人数");
                    ew.Write(i * 3 + 2, startColumn, (double)StaticQueryHelper.GetGradeCount(wb.SubjectType));
                    startColumn += 1;

                    ew.Write(i * 3 + 1, startColumn, "最高分");
                    ew.Write(i * 3 + 2, startColumn, StaticQueryHelper.GetGradeMaxScore(wb.SubjectType, sh.Subject));
                    startColumn += 1;

                    ew.Write(i * 3 + 1, startColumn, "平均分");
                    ew.Write(i * 3 + 2, startColumn, StaticQueryHelper.GetGradeAverage(wb.SubjectType, sh.Subject));
                    startColumn += 1;

                    ew.Write(i * 3 + 1, startColumn, "优秀率");
                    ew.Write(i * 3 + 2, startColumn, StaticQueryHelper.GetGradeExcellentRate(wb.SubjectType, sh.Subject, sh.TotalScore));
                    startColumn += 1;

                    ew.Write(i * 3 + 1, startColumn, "及格率");
                    ew.Write(i * 3 + 2, startColumn, StaticQueryHelper.GetGradePassRate(wb.SubjectType, sh.Subject, sh.TotalScore));
                    startColumn += 1;

                    ew.Write(i * 3 + 1, startColumn, "难度系数");
                    ew.Write(i * 3 + 2, startColumn, StaticQueryHelper.GetDegreeOfDifficulty(wb.SubjectType, sh.Subject, sh.TotalScore));
                    startColumn += 1;

                    ew.Write(i * 3 + 1, startColumn, "区分度");
                    ew.Write(i * 3 + 2, startColumn, StaticQueryHelper.GetDegreeOfDifferentiation(wb.SubjectType, sh.Subject, sh.TotalScore));
                    startColumn += 1;

                    //如果年级未设置考核目标,则忽略
                   if (Global.CurrentGrade.Target)
                    {
                        dt2 = StaticQueryHelper.GetSectionScore(wb.SubjectType, sh.Subject);
                        ew.WriteHeader(i * 3 + 1, startColumn, dt2, 0);
                        ew.Write(i * 3 + 2, startColumn, dt2);
                        startColumn += 3;
                    }
                   
                    //分段累计，因为这个统计列数不确定，所以要放在最右侧,可能生成的每一行长度不等.
                    dt = StaticQueryHelper.GetGradeSectionStatistics(wb.SubjectType, sh.Subject, sh.GradeStep, sh.GradeCount);
                    ew.WriteHeader(i * 3 + 1, startColumn, dt, 0);
                    ew.Write(i * 3 + 2, startColumn, dt);
                    

                     i++;
                     progressBar1.Invoke(ProgressIncrease, 10);
                }
                
            }
            ew.SaveAs(this.sfd.FileName);
            //dt.Dispose();
            //dt2.Dispose();
        }

        private void Finished(Task t)
        {
            if (this.InvokeRequired)
            {
               this.Invoke(new Action(
                    ()=>{
                        this.btnEnter.Text = "完成(&F)";
                        this.btnEnter.Enabled = true;
                        this.finished = true;
                    }
             ));
            }
            else
            {
                btnEnter.Text = "完成(&F)";
                btnEnter.Enabled = true;
                finished = true;
            }
        }


    }
}
