/*
 * 由SharpDevelop创建。
 * 作者： 刘保恩
 * 日期: 2011/11/22
 * 时间: 16:05
 * 功能: ExcelWriter-Excel写入器,可以向指定工作表中写入指定内容.
 *           ExcelReader-Excel读取器,完成所有读取操作,目前只支持从第一个工作表读取数据.
 * 
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using NPOI.HPSF;
//using NPOI.POIFS;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections.Generic;

namespace ScoreAnalyst
{

	/// <summary>
	/// Excel写入器
	/// </summary>
	public sealed class ExcelWriter 
	{
		private const int MAX_ROW = 65535;		//最大行数
		private const int MAX_COLUMN = 255;		//最大列数
		private IWorkbook currentWorkbook;		//当前活动工作薄,需要清理
		private ISheet currentSheet;			//当前活动工作表,需要清理
		private ICell currentCell;				//当前活动单元格,不需要清理
		private string _fileName;           //创建时指定的文件名字
        private ICellStyle _csPercents = null;  
        private IDataFormat _dataFormat = null;
        private ICellStyle _csAlignCenter = null;
        private IFont _fontH1Songti = null;
        private IFont _fontH2Songti = null;
        private ICellStyle _csPrecision2 = null;
        private ICellStyle _csH1 = null;
        private ICellStyle _csH2 = null;


        private IDataFormat DataFormat
        {
            get {
                if (_dataFormat == null)
                {
                    _dataFormat = currentWorkbook.CreateDataFormat();
                }
                return _dataFormat;
            }
        }

        private ICellStyle CSAlignCenter
        {
            get
            {
                if (_csAlignCenter == null)
                {
                    _csAlignCenter = currentWorkbook.CreateCellStyle();
                    _csAlignCenter.Alignment = HorizontalAlignment.CENTER;
                }
                return _csAlignCenter;
            }
        }
        private IFont FontH1Songti { get {
            if (_fontH1Songti == null)
            {
                _fontH1Songti = currentWorkbook.CreateFont();
                _fontH1Songti.FontName = "宋体";
                _fontH1Songti.FontHeightInPoints = 20;
                _fontH1Songti.Boldweight = (int)FontBoldWeight.BOLD;
            }
            return _fontH1Songti;
        
        } }
        private IFont FontH2Songti
        {
            get {
                if (_fontH2Songti == null)
                {
                    _fontH2Songti = currentWorkbook.CreateFont();
                    _fontH2Songti.FontName = "宋体";
                    _fontH2Songti.FontHeightInPoints = 10;
                }
                return _fontH2Songti;
            }
        }

        private ICellStyle CSH1
        {
            get {
                if (_csH1 == null)
                {
                    _csH1 = currentWorkbook.CreateCellStyle();
                    _csH1.SetFont(FontH1Songti);
                    _csH1.Alignment = HorizontalAlignment.CENTER;
                }
                return _csH1;
            }
        }
        private ICellStyle CSH2
        {
            get {
                if (_csH2 == null)
                {
                    _csH2 = currentWorkbook.CreateCellStyle();
                    _csH2.SetFont(FontH2Songti);
                    _csH2.Alignment = HorizontalAlignment.CENTER;
                }
                return _csH2;
            }
        }
        private ICellStyle CSPercents
        {
            get
            {
                if (_csPercents == null)
                {
                    _csPercents = currentWorkbook.CreateCellStyle();
                    _csPercents.DataFormat = DataFormat.GetFormat("0.00%");
                    _csPercents.SetFont(FontH2Songti);
                }
                return _csPercents;
            }
        }
        private ICellStyle CSPrecision2
        {
            get
            {
                if (_csPrecision2 == null)
                {
                    _csPrecision2 = currentWorkbook.CreateCellStyle();
                    _csPrecision2.DataFormat = DataFormat.GetFormat("0.00");
                    _csPrecision2.SetFont(FontH2Songti);
                }
                return _csPrecision2;
            }
        }

	
		
		/// <summary>
		/// 返回当前活动工作表,如果没有工作表,则创建一个.
		/// </summary>
		public ISheet CurrentSheet
		{
			get
			{
				return currentSheet != null ? currentSheet :( currentWorkbook.NumberOfSheets > 0 ? currentWorkbook.GetSheetAt(0) : currentWorkbook.CreateSheet());
			}
		}
		/// <summary>
		/// 构造函数,不指定文件名,自动创建一个.
		/// </summary>
		public ExcelWriter()
		{
			currentWorkbook = new HSSFWorkbook();
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = Global.Product.Company;
            (currentWorkbook as HSSFWorkbook).DocumentSummaryInformation = dsi;
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Author = Global.Product.Author;
            si.LastAuthor = Global.Product.Author;
            si.ApplicationName = Global.Product.ProductName;
            (currentWorkbook as HSSFWorkbook).SummaryInformation = si;
		}
		
		/// <summary>
		/// 构造函数,指定文件名,如果指定文件存在,则打开,如果不存在,则创建.
		/// </summary>
		/// <param name="fileName">指定文件名</param>
		public ExcelWriter(string fileName)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				_fileName = fileName;
				currentWorkbook = new HSSFWorkbook(fs);
				fs.Close();
			}
			


		}
		/// <summary>
		/// 另存为...
		/// </summary>
		/// <param name="fileName">如果文件存在,则打开修改.如果不存在,则创建之.</param>
		public void SaveAs(string fileName)
		{
			if (fileName == string.Empty)
				return;
			
			using (FileStream fs = new FileStream(fileName, FileMode.Create,FileAccess.Write))
			{
				currentWorkbook.Write(fs);
				fs.Close();
			}
			
		}
        /// <summary>
        /// 保存Excel文件,创建时指定过FileName才能使用此方法.
        /// </summary>
		public void Save()
		{
			SaveAs(_fileName);
		}

        public void Close()
        {
            Save();
        }

		/// <summary>
		/// 设置活动工作表
		/// </summary>
		/// <param name="index">工作表的索引</param>
		public void ActiveSheet(int index)
		{
			ISheet sheet = currentWorkbook.GetSheetAt(index);
			if (sheet == null)
				sheet = currentWorkbook.CreateSheet();

			currentSheet = sheet;
			currentCell = this[0, 0];
		}
		/// <summary>
		/// 设置活动工作表
		/// </summary>
		/// <param name="sheetName">工作表的名字</param>
		public void ActiveSheet(string sheetName)
		{
			ISheet sheet = currentWorkbook.GetSheet(sheetName);
			if (sheet == null)
				sheet = currentWorkbook.CreateSheet(sheetName);

			currentSheet = sheet;
			currentCell = this[0, 0];
		}
		/// <summary>
		/// 创建工作表,创建成功后,自动作为当前活动工作表.
		/// </summary>
		/// <param name="sheetName">工作表的名字</param>
		/// <resutns>返回创建的工作表</resutns>
		public void  CreateSheet(string sheetName)
		{
			currentSheet= currentWorkbook.CreateSheet(sheetName);
		}
		/// <summary>
		/// 创建工作表,不指定工作表名字,则系统自动生成一个.创建工作表后,自动设置为活动工作表
		/// </summary>
		/// <returns>返回创建的工作表</returns>
		public void CreateSheet()
		{
			currentSheet=currentWorkbook.CreateSheet();
		}

		/// <summary>
		/// 索引器,返回指定行号的行
		/// </summary>
		/// <param name="row">行号</param>
		/// <returns></returns>
		public IRow this[int row]
		{
			get
			{
				if (row < 0 || row > MAX_ROW)
					return null;

				IRow _row = CurrentSheet.GetRow(row);

				if (_row != null)
					return _row;
				else
					return CurrentSheet.CreateRow(row);
				
			}
			set
			{
				if(!(row<0||row>MAX_ROW))
					this[row] = value;
			}
			
		}
		/// <summary>
		/// 索引器,返回指定行号和列号的单元格
		/// </summary>
		/// <param name="row">行号</param>
		/// <param name="column">列号</param>
		/// <returns></returns>
		public ICell this[int row, int column]
		{
			get
			{
				if (this[row]==null)
					return null;
				if (column < 0 || column > MAX_COLUMN)
					return null;

				ICell cell = this[row].GetCell(column);

				if (cell != null)
					return cell;
				else
					return this[row].CreateCell(column);
			}

			set
			{
				if (this[row] != null && column>0 && column<=MAX_COLUMN)
				{
					this[row, column] = value;
				}
			}
			
		}

		/// <summary>
		/// 从指定单元格(以此单元格为起始)开始写入一个表格的内容,并将currentCell置为最后写入的单元格.
		/// </summary>
		/// <param name="startRow">起始单元格行号(从零开始)</param>
		/// <param name="startColumn">起始单元格列号(从零开始)</param>
		/// <param name="table">待写入的表</param>
		/// <param name="ignoreColumnCount">忽略的列的数目(从左边开始计算)</param>
		/// <returns>成功写入的单元格的数目</returns>
		public int Write(int startRow, int startColumn, DataTable table, int ignoreColumnCount=0)
		{
			int rowCount, columnCount;
			rowCount = table.Rows.Count;
			columnCount = table.Columns.Count;
			if (startRow < 0 || startRow > MAX_ROW || startRow + rowCount > MAX_ROW)
				return 0;
			if (startColumn < 0 || startColumn > MAX_COLUMN || startColumn + columnCount > MAX_COLUMN)
				return 0;


			for (int r = 0; r < rowCount; r++)
			{
				for (int c = 0; c < columnCount - ignoreColumnCount; c++)
				{
					//遇到NULL直接跳过,否则写入的为0.
					if (table.Rows[r][c + ignoreColumnCount] == DBNull.Value)
					{
						continue;
					}
					//否者根据列的类型,分别写入
					switch (table.Columns[c + ignoreColumnCount].DataType.Name)
					{
						case "String":
							{
								Write(startRow + r, startColumn + c, table.Rows[r][c + ignoreColumnCount].ToString());
								break;
							}
						case "Decimal":
							{
								Write(startRow + r, startColumn + c, (decimal)table.Rows[r][c + ignoreColumnCount]);
								break;
							}
						case "Double":
							{
								Write(startRow + r, startColumn + c, (double)table.Rows[r][c + ignoreColumnCount]);
								break;
							}
						case "Int32":
						case "Int64":
							{
								Write(startRow + r, startColumn + c, double.Parse(table.Rows[r][c + ignoreColumnCount].ToString()));
								break;
							}

						default:
							{
								Write(startRow + r, startColumn + c, table.Rows[r][c + ignoreColumnCount].ToString());
								break;
							}
					}

				}
			}
			//return this[startRow + table.Rows.Count, startColumn + table.Columns.Count];
			currentCell = this[startRow + table.Rows.Count, startColumn + table.Columns.Count];
			return table.Rows.Count * (table.Columns.Count - ignoreColumnCount);
		}
		/// <summary>
		/// 从指定单元格(以此单元格为起始)开始写入一个表格的内容,并将currentCell置为最后写入的单元格.
		/// </summary>
		/// <param name="startRow">起始单元格行号(从零开始)</param>
		/// <param name="startColumn">起始单元格列号(从零开始)</param>
		/// <param name="table">待写入的表</param>
		/// <returns>成功写入的单元格的数目</returns>
		public int Write(int startRow, int startColumn, DataTable table)
		{
			return Write(startRow, startColumn, table, 0);
		}

        public int Write(int startRow, int startColumn, DataTable table, int ignoreColumnCount=0,bool writeHeader=false)
        {
            if (writeHeader)
            {
                WriteHeader(startRow, startColumn, table, ignoreColumnCount);
            }
            Write(startRow + 1, startColumn, table, ignoreColumnCount);
            return (table.Rows.Count + 1) * table.Columns.Count;
        }

		/// <summary>
		/// 在指定单元格写入内容
		/// </summary>
		/// <param name="row">行号(从零开始)</param>
		/// <param name="column">列号(从零开始)</param>
		/// <param name="cellValue">待写入的内容(string类型)</param>
		/// <returns>写入成功返回1,否者返回0</returns>
		public int Write(int row, int column, string cellValue)
		{

			try
			{
				this[row, column].SetCellValue(cellValue);
			}
			catch
			{
				//如果写入失败,返回0;
				return 0;
			}
			currentCell=this[row, column];
			return 1;
		}
		/// <summary>
		/// 在指定单元格写入内容
		/// </summary>
		/// <param name="row">行号(从零开始)</param>
		/// <param name="column">列号(从零开始)</param>
		/// <param name="cellValue">待写入的内容(double类型)</param>
		///  <returns>写入成功返回1,否者返回0</returns>
		public int Write(int row, int column, double cellValue)
		{
			try
			{
				this[row, column].SetCellValue(cellValue);
			}
			catch
			{
				//如果写入失败,返回0;
				return 0;
			}
			currentCell = this[row, column];
			return 1;
		}
		/// <summary>
		/// 在指定单元格写入内容
		/// </summary>
		/// <param name="row">行号(从零开始)</param>
		/// <param name="column">列号(从零开始)</param>
		/// <param name="cellValue">待写入的内容(decimal类型)</param>
		/// <returns>写入成功返回1,否者返回0</returns>
		public int  Write(int row, int column, decimal cellValue)
		{
			return Write(row, column, cellValue.ToString());
		}


		/// <summary>
		/// 写入公式
		/// </summary>
		/// <param name="row">行号(从零开始)</param>
		/// <param name="column">列号(从零开始)</param>
		/// <param name="formulaValue">公式</param>
		/// <returns>成功写入的单元格数,成功返回1,失败返回0</returns>
		public int WriteFormula(int row, int column, string formulaValue)
		{
			try
			{
				this[row, column].CellFormula = formulaValue;
			}
			catch
			{
				return 0;
				
			}
			currentCell = this[row, column];
			return 1;
		}

		/// <summary>
		/// 写入表格的列名
		/// </summary>
		/// <param name="startRow">起始单元格行号(从零开始)</param>
		/// <param name="startColumn">起始单元格列号(从零开始)</param>
		/// <param name="table">待写入的表</param>
		/// <param name="ignoreColumnCount">忽略的列的数目(从左边开始计算)</param>
		public int WriteHeader(int startRow, int startColumn, DataTable table, int ignoreColumnCount=0)
		{
			if (startRow < 0 || startRow > MAX_ROW)
				return 0;
			if (startColumn < 0 || startColumn > MAX_COLUMN ||startColumn+table.Columns.Count>MAX_COLUMN)
				return 0;

			for (int i = 0; i < table.Columns.Count - ignoreColumnCount; i++)
			{
				Write(startRow, startColumn + i, table.Columns[i + ignoreColumnCount].ColumnName);
			}

			return table.Columns.Count - ignoreColumnCount;
		}
		
		/// <summary>
		/// 合并指定区域的单元格
		/// </summary>
		/// <param name="firstRow">第一个单元格的行号</param>
        /// <param name="firstColumn">最后一个单元格的行号</param>
        /// <param name="lastRow">第一个单元格的列号</param>
		/// <param name="lastColumn">最后一个单元格的列号</param>
        public void MergeCells(int firstRow, int firstColumn, int lastRow, int lastColumn)
        {
            currentSheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(firstRow, lastRow, firstColumn, lastColumn));
        }

        /// <summary>
        /// 根据列号获得其列的名字
        /// </summary>
        /// <param name="column">列号(从零开始)</param>
        /// <returns>列的名字</returns>
        private string GetColumnNameByIndex(int column)
        {
            if (column < 0)
                throw new OverflowException("列号必须为非负整数!");
            if (column > MAX_COLUMN)
                throw new OverflowException("列最大不能超过255!");
            if (column < 26)
                return Chr(column + 65).ToString();
            else
                return Chr(column / 26 + 64).ToString() + Chr(column % 26 + 65).ToString();
        }
        /// <summary>
        /// 根据单元格坐标获得其名字
        /// </summary>
        /// <param name="row">单元格行号(从零开始)</param>
        /// <param name="column">单元格列号(从零开始)</param>
        /// <returns>单元格的名字</returns>
        public string GetCellNameByPosition(int row, int column)
        {
            return GetColumnNameByIndex(column) + (row + 1).ToString();
        }
        public string GetCellNameByPosition(CellPosition p)
        {
            return GetColumnNameByIndex(p.Column) + p.Row.ToString();
        }
        /// <summary>
        /// 根据单元格名字获得列名字
        /// </summary>
        /// <param name="columnName">列名称</param>
        /// <returns>列号(从零开始)</returns>
        public int GetColumnIndexByName(string columnName)
        {
            string s = columnName.ToUpper();
            if (s == string.Empty)
            {
                throw new OverflowException("列名为空");
            }
            if (s.Length == 1)
            {
                return Asc(s[0]) - 65;
            }
            else if (s.Length == 2)
            {
                int result = (Asc(s[0]) - 64) * 26 + Asc(s[1]) - 65;
                if (result > MAX_COLUMN)
                {
                    throw new OverflowException("列名的最大值为IV");
                }
                return result;
            }
            else
            {
                throw new OverflowException("请检查你输入的列名!");
                //return -1;
            }

        }
        /// <summary>
        /// 根据单元格名字获取单元格的坐标
        /// </summary>
        /// <param name="CellName">单元格名字</param>
        /// <returns>单元格的坐标(CellPosition)</returns>
        public CellPosition GetCellPositionByName(string CellName)
        {
            string s = CellName.ToUpper();
            int row, column;
            if (isNumber(s[1]))
            {
                column = GetColumnIndexByName(s[0].ToString());
                if (!Int32.TryParse(s.Substring(1), out row))
                    return new CellPosition(-1, -1);
                else
                    return new CellPosition(row - 1, column);
            }
            else
            {
                column = GetColumnIndexByName(s.Substring(0, 2));
                if (!Int32.TryParse(s.Substring(2), out row))
                    return new CellPosition(-1, -1);
                else
                    return new CellPosition(row - 1, column);

            }



        }
        /// <summary>
        /// 字符转ascii码
        /// </summary>
        /// <param name="character">待转换的字符</param>
        /// <returns>ASCII码值</returns>
        private int Asc(char character)
        {
            return Convert.ToInt32(character);
        }
        /// <summary>
        /// ascii码转字符
        /// </summary>
        /// <param name="asciiCode">待转换的ascii码</param>
        /// <returns>转换后的字符</returns>
        private char Chr(int asciiCode)
        {
            return Convert.ToChar(asciiCode);
        }
        /// <summary>
        /// 判断一个字符是否为数字(0-9)
        /// </summary>
        /// <param name="c">待检测的字符</param>
        /// <returns>检测结果,是否为数字</returns>
        private bool isNumber(char c)
        {
            return (c >= '0' && c <= '9');
        }

        /// <summary>
        /// 设置单元格格式为百分数,宋体,11号
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void SetCellPercents(int row, int column)
        {
            //this[row, column].CellStyle = this.CSPercents;
            this[row, column].CellStyle = CSPercents;
        }

        /// <summary>
        /// 设置单元格格式为小数,两位小数,宋体,11号
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void SetCellPrecision2(int row, int column)
        {
            this[row, column].CellStyle = CSPrecision2;
        }
        
        public void SetCenter(int row, int column)
        {
            this[row, column].CellStyle = this.CSAlignCenter;
        }

        public void SetH1Center(int row, int column)
        {
            this[row].Height = 24* 20;
            currentCell = this[row, column];
            currentCell.CellStyle = CSH1;
            currentCell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        }

        public void SetH2(int row, int column)
        {
            this[row, column].CellStyle = CSH2;
        }

        public void CreateFreezePane(int colSplit, int rowSplit, int leftmostColumn, int topRow)
        {
            currentSheet.CreateFreezePane(colSplit, rowSplit, leftmostColumn, topRow);
        }
        /// <summary>
        /// 冻结窗体
        /// </summary>
        /// <param name="colSplit">被冻结的列数</param>
        /// <param name="rowSplit">被冻结的行数</param>
        public void CreateFreezePane(int colSplit, int rowSplit)
        {
            currentSheet.CreateFreezePane(colSplit, rowSplit);
        }

        public void SetColumnWidth(int columnIndex,int width)
        {
            currentSheet.SetColumnWidth(columnIndex, width * 256);
        }

        public void SetColumnAutoSize(int columnIndex)
        {
            currentSheet.AutoSizeColumn(columnIndex);
        }




	}

    /// <summary>
    /// 使用NPOI实现的读取算法
    /// 避免生成表格造成内存占用过高的问题
    /// </summary>
    public sealed class ExcelReader
    {
        IWorkbook _workbook;
        ISheet _sheet;
        public ExcelReader(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                _workbook = new HSSFWorkbook(fs);
            }

        }
        public void ActiveSheet(int index)
        {
            _sheet = _workbook.GetSheetAt(0);
            // _workbook.SetActiveSheet(0);
        }
        private Dictionary<string, int> GetHeaders()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>(16);
            //_sheet = _workbook.GetSheetAt(index);
            IRow row = _sheet.GetRow(0);
            System.Collections.IEnumerator cell = row.GetEnumerator();
            ICell ic;
            int i = 0;
            while (cell.MoveNext())
            {
                ic = (cell.Current as ICell);
                dic.Add(ic.ToString(), i);
                i++;
            }
            return dic;
        }
        private string ContainFields(Dictionary<string, int> header, string[] arrayFields)
        {
            foreach (string s in arrayFields)
            {
                if (!header.ContainsKey(s))
                {
                    return s;
                }
            }
            return null;

        }
        private int[] GetFiledsIndex(Dictionary<string, int> header, string[] arrayFields)
        {
            int len = arrayFields.Length;
            int[] _indexs = new int[len];
            for (int i = 0; i < len; i++)
            {
                _indexs[i] = header[arrayFields[i]];
            }
            return _indexs;
        }
        private string[] getSheetData(string strFields, int[] fieldsIndex, string destTableName)
        {
            int row_count = _sheet.LastRowNum;
            int column_count = fieldsIndex.Length;
            string[] data = new string[row_count];
            //初始值为 列数*8
            StringBuilder sb;

            IRow row;
            ICell cell;
            for (int r = 0; r < row_count; r++)
            {
                sb = new StringBuilder(column_count * 8);
                sb.AppendFormat("INSERT INTO \"{0}\"({1}) VALUES(", destTableName, strFields);
                row = _sheet.GetRow(r + 1);
                for (int c = 0; c < column_count; c++)
                {
                    cell = row.GetCell(fieldsIndex[c]);
                    if (cell == null)
                    {
                        sb.Append("'0',");
                    }
                    else
                    {
                        //data[r, c] = cell.ToString();
                        sb.AppendFormat("'{0}',", cell.ToString());
                    }


                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(");");


                data[r] = sb.ToString();

            }

            return data;
        }
        private string getSheetDataBatch(int[] fieldsIndex)
        {
            int row_count = _sheet.LastRowNum + 1;
            int column_count = fieldsIndex.Length;
            string data;
            //初始值为 列数*8
            StringBuilder sb = new StringBuilder(row_count * column_count * 8);
            IRow row;
            ICell cell;
            for (int r = 1; r < row_count; r++)
            {
                sb.Append('(');
                row = _sheet.GetRow(r);
                for (int c = 0; c < column_count; c++)
                {
                    cell = row.GetCell(fieldsIndex[c]);
                    if (cell == null)
                    {
                        sb.Append("'0',");
                    }
                    else
                    {
                        //data[r, c] = cell.ToString();
                        sb.AppendFormat("'{0}',", cell.ToString());
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("),");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(";");
            data = sb.ToString();
            return data;
        }
        public string[] GetFirstSheetData(string strFields, string destTableName)
        {
            string[] arrayFields = strFields.Split(',');
            string formatFields = QuoteName(strFields);
            ActiveSheet(0);
            Dictionary<string, int> dic = GetHeaders();
            string err_str = ContainFields(dic, arrayFields);
            if (err_str != null)
            {
                throw new ExcelColumnNotFound(string.Format("指定的Excel至少缺少一个指定的字段,字段名为:{0}", err_str));
            }
            int[] indexs = GetFiledsIndex(dic, arrayFields);
            return getSheetData(formatFields, indexs, destTableName);
        }
        public string GetFirstSheetDataBatch(string strFields, string destTableName)
        {
            ActiveSheet(0);
            Dictionary<string, int> dic = GetHeaders();
            string[] arrayFields = strFields.Split(',');
            string formatFields = QuoteName(strFields);
            string err_str = ContainFields(dic, arrayFields);
            if (err_str != null)
            {
                throw new ExcelColumnNotFound(string.Format("指定的Excel至少缺少一个指定的字段,字段名为:{0}", err_str));
            }
            int[] indexs = GetFiledsIndex(dic, arrayFields);
            string res = string.Format("insert into \"{0}\"({1}) values ", destTableName, strFields);
            res += getSheetDataBatch(indexs);
            return res;
        }
        public void Reset()
        {
            //currentRow = 1;
        }

        private string QuoteName(string strFields)
        {
            string result = strFields.Replace(",", "\",\"");
            result = string.Concat("\"", result, "\"");
            return result;
        }


    }



    /// <summary>
    /// 单元格位置
    /// </summary>
    public struct CellPosition
    {
        private const int MAX_ROW = 65535;
        private const int MAX_COLUMN = 255;
        private int _row, _column;

        /// <summary>
        /// 列号
        /// </summary>
        public int Column
        {
            get { return _column; }
            set
            {
                if (value > MAX_COLUMN)
                    _column = MAX_COLUMN;
                else
                    _column = value;
            }
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int Row
        {
            get { return _row; }
            set
            {
                if (value > MAX_ROW)
                    _row = MAX_ROW;
                else
                    _row = value;
            }
        }

        public CellPosition(int row, int column)
            : this()
        {
            _row = row;
            _column = column;
        }
    }

    /// <summary>
    /// 指定列未找到异常
    /// </summary>
    public sealed class ExcelColumnNotFound : ApplicationException
    {
        public ExcelColumnNotFound()
            : base("指定的列未找到")
        { }
        public ExcelColumnNotFound(string message)
            : base(message)
        { }
    }




}
