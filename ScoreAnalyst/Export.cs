using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace ScoreAnalyst
{
    /// <summary>
    /// 输出操作需要细化,最少7个函数.
    /// </summary>
    class Export
    {
        private DataTable table;
        private WorkbookInfo[] workbooks;
        private ExcelWriter excelWriter;
        private int taskGroupCount;
        private int taskCount;

        public event TaskProgressChangedHandler TaskProgressChanged;
        //public event TasksCompeletedHandler TasksCompeled;

        public Export()
        {

            SSSConfigurator config = SSSConfigurator.Create();
            XmlNodeList wblist = config.GetWorkbooks();
            workbooks = new WorkbookInfo[wblist.Count];
            for(int i=0;i<wblist.Count;i++)
            {
                workbooks[i] = getWorkbook(wblist[i]);
            }

            taskGroupCount = workbooks.Length;

            foreach (WorkbookInfo w in workbooks)
            {
                taskCount += w.Sheets.Count;
            }

        }
        private WorkbookInfo getWorkbook(XmlNode wbNode)
        {
            WorkbookInfo wb = new WorkbookInfo();
            wb.SubjectType = Int32.Parse(wbNode.Attributes["subjectType"].Value);
            wb.Title = wbNode.Attributes["title"].Value;
            wb.Template = wbNode.Attributes["template"].Value;
            wb.Report = wbNode.Attributes["report"].Value;
            wb.Sheets = new List<SheetInfo>();
            foreach (XmlNode snode in wbNode.ChildNodes)
            {
                wb.Sheets.Add(new SheetInfo(
                    wb,
                    snode.Attributes["subject"].Value,
                    Int32.Parse(snode.Attributes["totalScore"].Value),
                    Int32.Parse(snode.Attributes["statisticsStep"].Value),
                    Int32.Parse(snode.Attributes["statisticsCount"].Value),
                    Int32.Parse(snode.Attributes["type"].Value)
                    )
                   );
            }

            return wb;
        }

        public void Report(XWorkbook wb)
        {
            excelWriter = new ExcelWriter(wb.Template);
            int rowOffset;
            foreach (var sheet in wb.SheetList)
            {
                if (sheet.Ignore)
                {
                    continue;
                }
                excelWriter.ActiveSheet(sheet.Subject);

                //写入标题
                excelWriter.Write(0, 0, string.Format(wb.Title, sheet.Subject));
                //写入班级信息(共4列)
                excelWriter.Write(3, 0, StaticQueryHelper.GetClassInformation(wb.SubjectType, sheet.Subject));
                //获取分段统计
                table = StaticQueryHelper.GetClassSectionStatistics(wb.SubjectType, sheet.Subject,sheet.ClassStep,sheet.ClassCount);
                //写入分段统计表格的题头
                excelWriter.WriteHeader(2, 4, table,1);
                //写入分段统计表(忽略第一列)
                excelWriter.Write(3, 4, table,1);
                //获得分段统计表的列数.
                rowOffset=table.Rows.Count;
                
                // 合并单元格,这个单元格可以不合并,因为合并后不太好复制,但是合并后稍微漂亮点.
                //excelWriter.MergeCells(3 + rowOffset, 3 + rowOffset, 0, 1);

               //增加合计行
                excelWriter.Write(3 + rowOffset, 0, "合计");
                //计算合计行
                excelWriter.WriteFormula(3 + rowOffset, 2, string.Format("SUM({0}:{1})", excelWriter.GetCellNameByPosition(3, 2), excelWriter.GetCellNameByPosition(3 + rowOffset - 1, 2)));
                excelWriter.WriteFormula(3 + rowOffset, 3, string.Format("Max({0}:{1})", excelWriter.GetCellNameByPosition(3, 3), excelWriter.GetCellNameByPosition(3 + rowOffset - 1, 3)));
                for (int i = 4; i <table.Columns.Count + 3; i++)
                {
                    excelWriter.WriteFormula(3 + rowOffset, i, string.Format("SUM({0}:{1})", excelWriter.GetCellNameByPosition(3, i), excelWriter.GetCellNameByPosition(3 + rowOffset - 1, i)));
                }

                //如果类型未1,则增加"优秀率","及格率","平均分" 三列.
                if (!sheet.IgnoreRate)
                {
                    //写入班级的优秀率,及格率和平均分
                    excelWriter.Write(3, 16, StaticQueryHelper.GetClassRate(wb.SubjectType, sheet.Subject, sheet.TotalScore), 1);
                    //写入全年级的优秀率,及格率和平均分.
                    excelWriter.Write(3 + rowOffset, 16, StaticQueryHelper.GetGradeExcellentRate(wb.SubjectType, sheet.Subject, sheet.TotalScore));
                    excelWriter.Write(3 + rowOffset, 17, StaticQueryHelper.GetGradePassRate(wb.SubjectType, sheet.Subject, sheet.TotalScore));
                    excelWriter.Write(3 + rowOffset, 18, StaticQueryHelper.GetGradeAverage(wb.SubjectType, sheet.Subject));
                }

                ////写入一本,二本,三本分数线
                //if (Global.CalculateSection)
                //{
                //    table = StaticQueryHelper.GetSectionScore(wbi.SubjectType, sheet.Subject);
                //    excelWriter.WriteHeader(5 + rowOffset, 0, table, 0);
                //    excelWriter.Write(6 + rowOffset, 0, table);
                //}
               //触发事件
               if (TaskProgressChanged != null)
                {
                    TaskProgressChanged(this, new TaskProgressChandedEventArgs(1,
                    string.Format("生成{0}成绩分析报表...", sheet.Subject), taskCount));
                }


           }
            excelWriter.SaveAs(wb.Report);
            excelWriter.Dispose();
           
            if (Global.Grade.Target)
            {
                #region 写入指标完成情况表
                ExcelWriter excelDif = new ExcelWriter();
                foreach (XSheet sheet in wb.SheetList)
                {
                    string subjectTypeName;
                    switch (wb.SubjectType)
                    {
                        case 1:
                            {
                                subjectTypeName = "理科";
                                break;
                            }
                        case 2:
                            {
                                subjectTypeName = "文科";
                                break;
                            }
                        case 9:
                            {
                                subjectTypeName = "综合";
                                break;
                            }
                        default:
                            {
                                subjectTypeName = "";
                                break;
                            }
                    }
                    //创建一个工作本
                    excelDif.CreateSheet(sheet.Subject);
                    //excelDif.ActiveSheet(sheet.Subject);
                    //写入标题
                    excelDif.Write(0, 0, string.Format("指标完成情况-{0}-{1}", subjectTypeName, sheet.Subject));
                    //合并指定单元格
                    excelDif.MergeCells(0, 0, 0, 12);

                    //读取数据
                    table = StaticQueryHelper.GetClassDifference(wb.SubjectType, sheet.Subject);
                    //写入标题行
                    excelDif.WriteHeader(1, 0, table, 0);
                    //写入表格内容
                    excelDif.Write(2, 0, table, 0);
                    //保存
                    excelDif.SaveAs(string.Format("report\\指标完成情况-{0}.xls", subjectTypeName));

                    
                    //触发TaskProgressChanged事件.
                    if (TaskProgressChanged != null)
                    {
                        TaskProgressChanged(this, new TaskProgressChandedEventArgs(0,
                        string.Format("生成{0}考核目标完成情况表...", sheet.Subject), taskCount));
                    }
                }
                #endregion

                excelDif.Dispose();
            }
        }

        public void ReportAll()
        {
            for (int i = 0; i < Global.Grade.WorkbookList.Count; i++)
            {
                if (TaskProgressChanged != null)
                {
                    TaskProgressChanged(this, new TaskProgressChandedEventArgs(0,
                        string.Format("开始处理第{0}组任务[共{1}组]...", i + 1,taskGroupCount),taskCount));
                }
                //初始化数据库
                StaticQueryHelper.Initialize(workbooks[i].SubjectType);
                Report(Global.Grade.WorkbookList[i]);
            }
                if (TaskProgressChanged != null)
                {
                    TaskProgressChanged(this, new TaskProgressChandedEventArgs(0,
                        string.Format("所有任务[共{0}组{1}项]已处理成功!!!!",taskGroupCount,taskCount),taskCount));
                }

        }



    }

    public delegate void TaskProgressChangedHandler(object sender,TaskProgressChandedEventArgs e);
    public class TaskProgressChandedEventArgs:EventArgs
    {
        public int TotalTaskCount { get; set; }
        public string CurrentTask { get; set; }
        public int Increasement { get; set; }
        public TaskProgressChandedEventArgs(int inc, string task,int total):base()
        {
            Increasement = inc;
            CurrentTask = task;
            TotalTaskCount = total;
        }

    }

   

}


/// <summary>
/// 过程:1.检查任务完成的前提是否都满足
/// 2.分析任务量
/// 3.启动任务,并对已完成任务计数
/// 4.每完成一个任务都要触发事件,已通知订阅者
/// 5.任务完成通知订阅者.
/// </summary>
//public class ExportHelper
//{
//    private bool CheckSuccess;//判断前提条件是否都满足.
//    private int CalculateWorkCount;//分析任务的数量
   


//}