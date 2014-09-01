/*
 * 由SharpDevelop创建。
 * 作者： 刘保恩
 * 日期: 2011/11/21
 * 时间: 18:51
 * 主要功能:定义要使用的扩展方法.
 * 
 */
using System.Text;
using System.Data;
using System.Xml;


namespace ScoreAnalyst
{
    //扩展类
    public static class Extended
    {
		/// <summary>
		/// 将DataRow对象,转化为用,分割开的带有''的字符串.
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
        public static string ToValueString(this DataRow dataRow)
        {
            if (dataRow == null)
                return string.Empty;

            
            int columnCount = dataRow.ItemArray.Length;
            if (columnCount == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            
            for (int c = 0; c < columnCount; c++)
            {
                sb.AppendFormat("'{0}',", dataRow[c].ToString());
            }
            return sb.ToString(0, sb.Length - 1);
        }
        /// <summary>
        /// 获取表格的字段列表,其中字段名使用""包围起来(专门针对Postgresql).
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetFieldNames(this DataTable dt)
        {
            if (dt == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat("\"{0}\",", dc.ColumnName);
            }

            return sb.ToString(0, sb.Length - 1);
        }
        /// <summary>
        /// 将DataTable转化为INSERT语句
        /// </summary>
        /// <param name="dt">待转换的表格</param>
        /// <param name="destinationTableName">目标表的名字</param>
        /// <returns></returns>
        public static string[] ToSQLStringArray(this DataTable dt,string destinationTableName)
        {
            string fields = dt.GetFieldNames();
            if (fields == null || fields.Length == 0)
                return null;

            string[] sql = new string[dt.Rows.Count];
            for(int i=0;i<dt.Rows.Count;i++)
            {
                sql[i] = string.Format("INSERT INTO {0}({1}) VALUES({2});", destinationTableName, fields, dt.Rows[i].ToValueString());
            
            }

            return sql;
        }
        /// <summary>
        /// 将DataTable转化为SQL语句
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="targetTableName">目标表格的名字</param>
        /// <returns></returns>
        public static string ToSqlString(this DataTable dt, string targetTableName,string quoteString="",bool useCompleteFormat=false)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO {0} (", targetTableName.QuoteName(quoteString));
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(col.ColumnName.QuoteName(quoteString));
                sb.Append(',');
            }
            //删除最后一个逗号
            sb.Remove(sb.Length - 1, 1);

            sb.Append(") VALUES");

            string sqlHeader = sb.ToString();

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("(");
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    switch (dt.Columns[c].DataType.Name)
                    {
                        case "String":
                        case "DataTime":
                        case "Char":
                        case "TimeSpan": 
                       {
                                sb.AppendFormat("'{0}',", dt.Rows[r][c].ToString());
                                break;
                        }
                        
                        default:
                            {
                                sb.AppendFormat("{0},", dt.Rows[r][c].ToString());
                                break;
                            }
                    
                    }


                }
                    //删除最后的一个多余的逗号
                    sb.Remove(sb.Length - 1, 1);
                    //添加右括号和逗号
                    if (useCompleteFormat)
                    {
                        sb.Append(");");
                        //如果要换行显示,则用下面这一句
                        //sb.Append(");\r\n");
                        sb.Append(sqlHeader);
                    }
                    else
                    {
                        sb.Append(" ),");
                        //如果要换行显示,则用下面这句
                        //sb.Append(" ),\r\n");
                    }
            }
            if (useCompleteFormat)
            {
                sb.Remove(sb.Length - sqlHeader.Length - 1, sqlHeader.Length + 1);
                sb.Append(';');
                return sb.ToString();
            }
            else
            {
                sb.Remove(sb.Length - 1, 1);
                sb.Append(';');
                return sb.ToString();
            }
        }
        /// <summary>
        /// 将sql语句拆成数组.
        /// </summary>
        /// <param name="dt">待转化的表格</param>
        /// <param name="targetTableName">目标表的名字</param>
        /// <param name="quoteString">标识符</param>
        /// <returns></returns>
        public static string[] ToSqlStringArray(this DataTable dt, string targetTableName, string quoteString = "")
        {
            return dt.ToSqlString(targetTableName, quoteString, true).Split(';');
        }
        /// <summary>
        /// 将字符串用标识符包围起来.如:列名 -> "列名",
        /// </summary>
        /// <param name="objectName">标识符名字</param>
        /// <param name="quoteString">转义符(必须配对,SQLServer使用[],Postgresql使用"",mysql中使用``)</param>
        /// <returns></returns>
        public static string QuoteName(this string objectName,string quoteString="")
        {

            if (quoteString == null || quoteString.Length == 0)
                return objectName;

            int length=quoteString.Length;

            StringBuilder sb = new StringBuilder();
            if (length == 1 || length %2!=0)
            {
                sb.Append(quoteString);
                sb.Append(objectName);
                sb.Append(quoteString);
                return sb.ToString();
            }
            int half = length / 2;
            for (int i = 0; i < half; i++)
            {
                sb.Append(quoteString[i]);
            }
            sb.Append(objectName);
            for (int i = half; i < length; i++)
            {
                sb.Append(quoteString[i]);
            }

            return quoteString.Substring(0, length / 2) + objectName + quoteString.Substring(length / 2 , length / 2);

        }
        /// <summary>
        /// 将表格转置(行列互换)
        /// </summary>
        /// <param name="dt">待转置的DataTable对象</param>
        /// <param name="ignoreColumn">忽略的列数</param>
        /// <returns></returns>
        public static DataTable Transpose(this DataTable dt,int ignoreColumn=0)
        {
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("ColumnName", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtNew.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
            }
            for (int c = ignoreColumn; c < dt.Columns.Count; c++)
            {
                DataRow drNew = dtNew.NewRow();
                drNew[0] = dt.Columns[c].ColumnName;
                //drNew["ColumnName"] = dt.Columns[c].ColumnName;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drNew[i + 1] = dt.Rows[i][c].ToString();
                }
                dtNew.Rows.Add(drNew);
            }
            return dtNew;
        
        }
        /// <summary>
        /// 从指定节点返回指定属性的Int32值,如果属性不存在则返回缺省值
        /// </summary>
        /// <param name="node">指定节点</param>
        /// <param name="attributeName">属性名</param>
        /// <param name="defaultValue">缺省值</param>
        /// <returns></returns>
        public static int  GetAttributeInt32Value(this XmlNode node,string attributeName,int defaultValue)
        {
            if (node == null)
            {
                return defaultValue;
            }
            int result;
            XmlAttribute xa=node.Attributes[attributeName];
            if ((xa != null) && (int.TryParse(xa.Value, out result)))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 从指定节点返回指定属性的string值,如果属性不存在则返回缺省值
        /// </summary>
        /// <param name="node">指定节点</param>
        /// <param name="attributeName">属性名</param>
        /// <param name="defaultValue">缺省值</param>
        /// <returns></returns>
        public static string GetAttributeStringValue(this XmlNode node, string attributeName, string defaultValue)
        {
            if (node == null)
                return defaultValue;

            XmlAttribute xa = node.Attributes[attributeName];
            if (xa != null)
            {
                return xa.Value;
            }
            return defaultValue;
        }
        /// <summary>
        /// 从指定节点返回指定属性的bool值,如果属性不存在则返回缺省值.
        /// </summary>
        /// <param name="node">指定节点</param>
        /// <param name="attributeName">属性名</param>
        /// <param name="defaultValue">缺省值</param>
        /// <returns></returns>
        public static bool GetAttributeBoolValue(this XmlNode node, string attributeName, bool defaultValue)
        {
            if (node == null)
            {
                return defaultValue;
            }
            bool result;
            XmlAttribute xa = node.Attributes[attributeName];
            if ((xa != null) && (bool.TryParse(xa.Value, out result)))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 从指定节点返回指定属性的double值,如果指定的属性不存在则返回缺省值.
        /// </summary>
        /// <param name="node">指定节点</param>
        /// <param name="attributeName">属性名</param>
        /// <param name="defaultValue">缺省值</param>
        /// <returns></returns>
        public static double GetAttributeDoubleValue(this XmlNode node, string attributeName, double defaultValue)
        {
            if (node == null)
            {
                return defaultValue;
            }
            double result;
            XmlAttribute xa = node.Attributes[attributeName];
            if ((xa != null) && (double.TryParse(xa.Value, out result)))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }
       

    }

   

}
