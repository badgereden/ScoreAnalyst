using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ScoreAnalyst
{
    class Report
    {
        int _classID;  //年级ID
        XGrade _xGrade;//配置文件

        public Report(int classID,XGrade xGrade)
        {
            _classID = classID;
            _xGrade = xGrade;
        }

        /// <summary>
        /// 生成竞赛班分段统计报表
        /// </summary>
        /// <param name="fileName">输出文件的名字(带路径全名字)</param>
        /// <param name="subjectType">科目类型:1-理科;2-理科</param>
        /// <param name="subjects">学科名字列表</param>
        /// <param name="totalSection">总分名次</param>
        /// <param name="classList">班级列表</param>
        /// <param name="sectionList">学科名次分段列表</param>
        /// <param name="valid_entry">是否考虑有效入围</param>
        /// <returns>返回受影响的行数</returns>
        public int ReportSectionByPositionValid(string fileName, int totalSection, string classList, string sectionList, bool valid_entry)
        {
            DataTable dt = null;
            ExcelWriter write = new ExcelWriter(fileName);
            int rowIndex=0, columnIndex=0;
            int startColumnIndex = 0;
            int rowCount = 0;
            foreach (XWorkbook wk in _xGrade.WorkbookList)
            {
                write.CreateSheet(wk.Title);
                write.ActiveSheet(wk.Title);

                foreach (XSheet sh in wk.SheetList)
                {
                    dt= StaticQueryHelper.GetSectionByPositionValid(wk.SubjectType, sh.Subject, totalSection, classList, sectionList, valid_entry);
                    rowIndex = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        columnIndex = startColumnIndex * 2;
                        write.Write(rowIndex, columnIndex, row[0].ToString());
                        write.Write(rowIndex, columnIndex+1, row[1].ToString());
                    }

                    startColumnIndex++;
                }
            }
            write.Save();
            if (dt != null)
            {
                dt.Dispose();
            }
            return rowCount;
        }



    }
}
