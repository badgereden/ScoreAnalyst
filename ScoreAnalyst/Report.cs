using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

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
        public int ReportSectionByPositionValid(string fileName, int subjectType, string classList, string[] subjects, int totalSection, string sectionList, bool valid_entry)
        {
            DataTable dt = null;
            HSSFWorkbook workbook= new HSSFWorkbook();
            int rowIndex=0, columnIndex=0;
            int startColumnIndex = 0;
            int rowCount = 0;
            ICell currentCell;
            //这里只取理科的.
            XWorkbook wk = _xGrade.WorkbookList[0];
            workbook.CreateSheet("理科");
            ISheet sheet = workbook.GetSheet("理科");
            sheet.SetActive(true);
            foreach (string sh in subjects)
            {
                dt= StaticQueryHelper.GetSectionByPositionValid(subjectType, sh, totalSection, classList, sectionList, valid_entry);
                rowIndex = 0;
                foreach (DataRow row in dt.Rows)
                {
                    columnIndex = startColumnIndex * 2;
                    currentCell = getSheetCell(sheet, rowIndex, columnIndex);
                    currentCell.SetCellValue(row[1].ToString());
                    currentCell = getSheetCell(sheet, rowIndex, columnIndex+1);
                    currentCell.SetCellValue(row[2].ToString());
                    rowIndex++;
                }

                startColumnIndex++;
            }


            saveAs(workbook, fileName);

            
            if (dt != null)
            {
                dt.Dispose();
            }
            return rowCount;
        }





        private void saveAs(HSSFWorkbook work, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                work.Write(fs);
                fs.Close();
            }

        }
        private IRow getSheetRow(ISheet sh, int rowIndex)
        {
            IRow row = sh.GetRow(rowIndex);
            if (row == null)
            {
                row=sh.CreateRow(rowIndex);
            }
            return row;
        }
        private ICell getCell(IRow row, int columnIndex)
        {
            ICell cell = row.GetCell(columnIndex);
            if (cell == null)
            {
                cell = row.CreateCell(columnIndex);
            }
            return cell;
        }
        private ICell getSheetCell(ISheet sh, int ri, int ci)
        {
            return getCell(getSheetRow(sh, ri), ci);
        }


    }
}
