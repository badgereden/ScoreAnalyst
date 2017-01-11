using System;
using System.Data;
using System.Windows.Forms;

namespace ScoreAnalyst
{

    public partial class FormNewReport : Form
    {
        //是否已经完成的标志位,初时必须为false.
        private bool finish = false;

        public FormNewReport()
        {
            InitializeComponent();
            customInitialize();
        }

        private void customInitialize()
        {
            //计算工作量,并将进度条的最大值设置为工作量大小
            int summary = 0;
            foreach (var w in Global.CurrentGrade.WorkbookList)
            {
                summary += w.SheetList.Count;
            }
            progressBar1.Maximum = summary;

            //如果已经分科,则显示"合并输出"的选项,否者不显示.
            if (Global.CurrentGrade.WorkbookList.Count > 1)
            {
                this.ckbMerge.Visible = true;
            }
            else
            {
                this.ckbMerge.Visible = false;
            }


        }

        private void btnEnter_Click(object sender, EventArgs e)
         {
             if (tbFolder.Text.Length == 0)
             {
                 MessageBox.Show("请选择文件输出的位置!!");
                 return;
             }
             string folder = tbFolder.Text.Trim();
            if (finish)
            {
                this.Close();
                return;
            }
            btnCancle.Enabled = false;
            btnEnter.Enabled = false;
            Report(this.ckbMerge.Checked,folder);
            finish = true;
            btnEnter.Text = "完成(&F)";
            btnEnter.Enabled = true;
        }

        /// <summary>
        /// 各学科独立输出
        /// </summary>
        private void ReportSaparate(string folder)
        {
            foreach (XWorkbook wb in Global.CurrentGrade.WorkbookList)
            {
                ReportWorkbook(wb,folder);
            }
        
        }

        /// <summary>
        /// 输出文科,理科或综合 的成绩报表
        /// </summary>
        /// <param name="wb"></param>
        private void ReportWorkbook( XWorkbook wb,string folder)
        {
            ExcelWriter ew = new ExcelWriter();
            DataTable dt = null;
            int count=0;

            //StaticQueryHelper.Initialize(wb.SubjectType);
            foreach (XSheet sh in wb.SheetList)
            {
                if (sh.Ignore)
                {
                    progressBar1.Increment(1);
                    continue;
                }

                lbTask.Text = string.Format("正在进行的任务:生成{0}报表", sh.Subject);
               // lbTask.Invalidate(lbTask.ClientRectangle);
                //lbTask.Invalidate(lbTask.ClientRectangle);
                Application.DoEvents();
                ew.CreateSheet(sh.Subject);
                //写入标题行
                ew.Write(0, 0, string.Format(wb.Title, sh.Subject));
                ew.MergeCells(0, 0, 0, sh.ClassCount + 9);
                ew.SetH1Center(0, 0);
                
                dt = StaticQueryHelper.GetClassInformation(wb.SubjectType, sh.Subject);
                ew.Write(1, 0, dt,0,true);
                ew.Write(1, 4, StaticQueryHelper.GetClassSectionStatistics(wb.SubjectType, sh.Subject, sh.ClassStep, sh.ClassCount), 1, true);
                //增加一个统计最高分的列
                count=dt.Rows.Count;
                dt.Dispose();

                ew.Write(count + 2, 0, "合计");
                ew.MergeCells(count + 2, 0, count + 2, 1);


                ew.WriteFormula(2 + count, 2, string.Format("SUM(C3:{0})", ew.GetCellNameByPosition(1 + count, 2)));
                ew.WriteFormula(2 + count, 3, string.Format("MAX(D3:{0})", ew.GetCellNameByPosition(1 + count, 3)));
                for(int i=0;i<sh.ClassCount;i++)
                {
                    ew.WriteFormula(2+count,i+4,string.Format("SUM({0}:{1})",ew.GetCellNameByPosition(2,i+4),ew.GetCellNameByPosition(1+count,i+4)));
                }
                
                //合计列中的最后三列需要重新计算
                if (!sh.IgnoreRate)
                {
                    //计算班级优秀率,及格率和平均分
                    ew.Write(1, sh.ClassCount + 4, StaticQueryHelper.GetClassRate(wb.SubjectType, sh.Subject, sh.TotalScore),1,true);
                    //计算年级优秀率,及格率和平均分
                    ew.Write(2 + count, sh.ClassCount + 4, StaticQueryHelper.GetGradeExcellentRate(wb.SubjectType, sh.Subject, sh.TotalScore));
                    ew.Write(2+ count, sh.ClassCount + 5, StaticQueryHelper.GetGradePassRate(wb.SubjectType, sh.Subject, sh.TotalScore));
                    ew.Write(2 + count, sh.ClassCount + 6, StaticQueryHelper.GetGradeAverage(wb.SubjectType, sh.Subject));
                }

                //合计


                ew.SetH1Center(0, 0);

                for (int r = 1; r < count+3; r++)
                {
                    for (int c = 0; c < 7 + sh.ClassCount; c++)
                    {
                        ew.SetH2(r, c);
                    }
                }

                for (int r = 2; r < count+2+ 1; r++)
                {
                    ew.SetCellPercents(r, 4 + sh.ClassCount);
                    ew.SetCellPercents(r, 5 + sh.ClassCount);
                    ew.SetCellPrecision2(r, 6 + sh.ClassCount);
                }
               


                progressBar1.Increment(1);

            }

            ew.SaveAs(folder+"\\"+wb.Report);
            dt.Dispose();
        }

        /// <summary>
        /// 输出报表
        /// </summary>
        /// <param name="merge">是否要合并输出,True:合并输出,文理科在一页中.false:独立输出,文理分开输出</param>
        private void Report(bool merge,string folder)
        {
            if (merge)
            {
                ReportMerge(folder);
            }
            else
            {
                ReportSaparate(folder);
            }
        }
        /// <summary>
        /// 合并输出
        /// </summary>
        private void ReportMerge(string folder)
        {
            ExcelWriter ew = new ExcelWriter();
            bool writed = false;
            int startRow = 0;
            int endRow=0;
            DataTable dt = null;
            int classCount = 0;
            foreach (var wb in Global.CurrentGrade.WorkbookList)
            {
                //StaticQueryHelper.Initialize(wb.SubjectType);
                foreach (var sh in wb.SheetList)
                {
                    lbTask.Text = string.Format("正在进行的任务:{0}", sh.Subject);

                    ew.ActiveSheet(sh.SheetName);
                    if(!writed)
                    {
                        ew.Write(0, 0, string.Format(wb.Title, sh.SheetName)); 
                        ew.MergeCells(0,0,0,sh.ClassCount+9);
                        ew.SetH1Center(0,0);
                    }

                    startRow = ew.CurrentSheet.LastRowNum+1;
                    
                    //写入班级信息
                    dt = StaticQueryHelper.GetClassInformation(wb.SubjectType, sh.Subject);
                    ew.Write(startRow, 0, dt,0,true);
                    classCount = dt.Rows.Count;
                    ew.Write(startRow, 4, StaticQueryHelper.GetClassSectionStatistics(wb.SubjectType, sh.Subject, sh.ClassStep, sh.ClassCount), 1, true);
                    
                    endRow = startRow + classCount + 1;
                    //如果设置为忽略统计信息,则不输出这三列.
                    if (!sh.IgnoreRate)
                    {
                        dt = StaticQueryHelper.GetClassRate(wb.SubjectType, sh.Subject, sh.TotalScore);
                        ew.Write(startRow, 4 + sh.ClassCount, dt, 1, true);
                        //最后一行的最后三列必须从数据库查询计算,而不是使用公式计算.
                        ew.Write(endRow, 4 + sh.ClassCount, StaticQueryHelper.GetGradeExcellentRate(wb.SubjectType, sh.Subject, sh.TotalScore));
                        ew.Write(endRow, 6 + sh.ClassCount, StaticQueryHelper.GetGradePassRate(wb.SubjectType, sh.Subject, sh.TotalScore));
                        ew.Write(endRow, 8 + sh.ClassCount, StaticQueryHelper.GetGradeAverage(wb.SubjectType, sh.Subject));
                    }
                    //合计
                    ew.Write(endRow, 0, "合计");
                    ew.MergeCells(endRow, 0, endRow, 1);
                    ew.SetCenter(endRow,0);

                    //最后一行,写入公式.
                    ew.WriteFormula(endRow, 2, string.Format("SUM({0}:{1})", ew.GetCellNameByPosition(startRow + 1, 2), ew.GetCellNameByPosition(endRow-1, 2)));
                    ew.WriteFormula(endRow, 3, string.Format("MAX({0}:{1})", ew.GetCellNameByPosition(startRow + 1, 3), ew.GetCellNameByPosition(endRow-1, 3)));
                    for (int i = 0; i < sh.ClassCount; i++)
                    {
                        ew.WriteFormula(endRow, 4 + i, string.Format("SUM({0}:{1})", ew.GetCellNameByPosition(startRow + 1, 4+i), ew.GetCellNameByPosition(endRow-1, 4+i)));
                    }

                    //设置格式,所有单元格都设置为宋体,10号
                    for (int r = startRow; r < endRow+1; r++)
                    {
                        for (int c = 0; c < 7 + sh.ClassCount; c++)
                        {
                            ew.SetH2(r, c);
                        }
                    }
                    //最后三列,前两列设置为百分数,宋体,10号.
                    //最后一列设置为小数,两位小数,宋体,10号.
                    for (int r = startRow + 1; r < endRow + 1; r++)
                    {
                        ew.SetCellPercents(r, 4 + sh.ClassCount);
                        ew.SetCellPercents(r, 6 + sh.ClassCount);
                        ew.SetCellPrecision2(r, 8 + sh.ClassCount);
                    }

                    progressBar1.Increment(1);
                    Application.DoEvents();
                }
                writed = true;
            }
            string _fileName = folder + "\\学科分段统计表.xls";
            ew.SaveAs(_fileName);
            dt.Dispose();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
       {
           if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
           {
               this.tbFolder.Text = folderBrowserDialog1.SelectedPath;
           }
        }

  
      

    }
}
