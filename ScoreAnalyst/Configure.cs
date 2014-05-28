/*
 * 创建日期: 2011/11/22
 * 时间: 21:49
 * 作者:刘保恩
 * 最后修改时间:2013/4/7
 * 功能描述:读取配置文件的类.
 * 
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace ScoreAnalyst
{
	public sealed class SAConfigureReader:IDisposable
    {
        private XmlDocument doc = null;     //XmlDocument
        private bool disposed = false;          //Dispose模式标志位

        //构造函数
        public SAConfigureReader(string fileName)
        {
            doc = new XmlDocument();
            doc.Load(fileName);
        }
        //返回年级列表->填充年级列表选择框
        public List<MyListItem<int>> GetGradeList()
        {
            string grade_path = "/scoreAnalyst/grades/grade";
            List<MyListItem<int>> grades = new List<MyListItem<int>>(5);
            XmlNodeList xnl = doc.SelectNodes(grade_path);
            foreach (XmlNode n in xnl)
            {
                grades.Add(new MyListItem<int>(n.GetAttributeStringValue("name", "暂无"), n.GetAttributeInt32Value("id", 0)));
            }
            return grades;
        }

        //返回指定年级节点
        public XmlNode GetGradeNode(int gradeId)
        {
            string grade_path = string.Format("/scoreAnalyst/grades/grade[@id={0}]", gradeId);
            XmlNode node = doc.SelectSingleNode(grade_path);
            return node;
        }
        //返回默认节点
        public XmlNode GetDefaultNode()
        {
            string default_path = "/scoreAnalyst/default";
            XmlNode node = doc.SelectSingleNode(default_path);
            return node;
        }
        //返回产品信息节点
        public XmlNode GetProductNode()
        {
            string default_path = "/scoreAnalyst/product";
            XmlNode node = doc.SelectSingleNode(default_path);
            return node;
        }
        //返回连接格式化连接字符串
        public string GetConnectionStringFormat(string dbType)
        {
           string cnstr = "/scoreAnalyst/connections/connection[@type=\"{0}\"]";
            string connect_path = string.Format(cnstr, dbType);
            XmlNode node = doc.SelectSingleNode(connect_path);
            return node.GetAttributeStringValue("connectionString", "");
        }
        
    
        #region Dispose模式
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;
            //当disposing为true时,表示是由手动调用的清理程序,需要清理,
            //而系统自动启动的回收程序,disposing 为false,这样可以确保不会对资源清理两次.
            if (disposing)
            { 
                //手动清理托管资源
                doc.RemoveAll();
                doc = null;

            }
            //这里清理非托管资源.



            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SAConfigureReader()
        {
            Dispose(false);
        }
        #endregion
    }

     public sealed class ConfigureFileNotFoundException : System.ApplicationException
    {
        public ConfigureFileNotFoundException(string fileName):base(string.Format("配置文件不存在,配置文件应当在以下位置:{0}",fileName))
        {}
    }

    #region XSheet,XWrokbook等结构体的定义
/*
 *scoreAnalyst->grades->grade...->report->workbook...->sheet...
 *                                                          ->database->schema->table...
 *                       ->default
 *                       ->product
 *                       ->connections->connection...
 * 
 *                          
 * 
 * 
 */
    public struct XSheet
    {
        /// <summary>
        /// 工作表名字
        /// </summary>
        public string SheetName
        {
            get;
            private set;
        }
        /// <summary>
        /// 学科名字
        /// </summary>
        public string Subject
        {
            get;
            private set;
        }
        /// <summary>
        /// 总分
        /// </summary>		
        public int TotalScore
        {
            get;
            private set;
        }
        /// <summary>
        /// 班级统计步长
        /// </summary>
        public int ClassStep
        {
            get;
            private set;
        }
        /// <summary>
        /// 年级分段数
        /// </summary>
        public int ClassCount
        {
            get;
            private set;
        }
        /// <summary>
        /// 年级统计步长
        /// </summary>
        public int GradeStep
        {
            get;
            private set;
        }
        /// <summary>
        /// 年级分段数
        /// </summary>
        public int GradeCount
        {
            get;
            private set;
        }
        /// <summary>
        /// 是否忽略本学科,如果有有此标记,则不会产生输出.
        /// </summary>
        public bool Ignore
        {
            get;
            private set;
        }
        /// <summary>
        /// 是否忽略分析信息,优秀率,及格率,平均分
        /// </summary>
        public bool IgnoreRate
        {
            get;
            private set;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="node">包含XSheet信息的节点</param>
        public XSheet(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }
            SheetName = node.GetAttributeStringValue("sheetName", "");
            Subject = node.GetAttributeStringValue("subject", "");
            TotalScore = node.GetAttributeInt32Value("totalScore", 100);
            ClassStep = node.GetAttributeInt32Value("classStep", 5);
            ClassCount = node.GetAttributeInt32Value("classCount", 12);
            GradeStep = node.GetAttributeInt32Value("gradeStep", 5);
            GradeCount = node.GetAttributeInt32Value("gradeCount", 12);
            Ignore = node.GetAttributeBoolValue("ignore", false);
            IgnoreRate = node.GetAttributeBoolValue("ignoreRate", false);
        }


    }

    public struct XWorkbook
    {
        public string Title
        {
            get;
            private set;
        }
        public int SubjectType
        {
            get;
            private set;
        }
        public string Template
        {
            get;
            private set;
        }
        public string Report
        {
            get;
            private set;
        }
        public List<XSheet> SheetList { get; private set; }
        //public Dictionary<string, XSheet> SheetDic { get; private set; }
        public XWorkbook(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }

            SheetList = new List<XSheet>();
            //SheetDic = new Dictionary<string, XSheet>();
            foreach (XmlNode n in node.SelectNodes("./sheet"))
            {
                //SheetDic.Add(n.GetAttributeStringValue("subject", ""), new XSheet(n));
                SheetList.Add(new XSheet(n));
            }

            Title = node.GetAttributeStringValue("title", "");
            SubjectType = node.GetAttributeInt32Value("subjectType", 1);
            Template = node.GetAttributeStringValue("template", "");
            Report = node.GetAttributeStringValue("report", "");

        }

        public string getSubjectList()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(50);
            foreach (XSheet s in SheetList)
            {
                if (s.Ignore)
                    continue;
                else
                    sb.AppendFormat("{0},", s.Subject);
            }
            return sb.ToString(0, sb.Length - 1);
        }
    }

    public struct XTable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Target { get; private set; }
        public string Fields { get; private set; }
        public XTable(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }
            Id = node.GetAttributeInt32Value("id", 0);
            Name = node.GetAttributeStringValue("name", "");
            Target = node.GetAttributeStringValue("target", "");
            Fields = node.GetAttributeStringValue("fields", "");
        }
    }

    public struct XSchema
    {
        public List<XTable> TableList { get; private set; }
        public XSchema(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }

            TableList = new List<XTable>();
            foreach (XmlNode n in node.SelectNodes("./table"))
            {
                TableList.Add(new XTable(n));
            }

        }
        public List<MyListItem<string>> GetTableListForMyListItem()
        {
            List<MyListItem<string>> tables = new List<MyListItem<string>>(10);
            foreach (XTable t in Global.CurrentGrade.Database.Schema.TableList)
            {
                tables.Add(new MyListItem<string>(t.Name, t.Target));
            }
            return tables;
        }
        public List<MyListItem<XTable>> GetXTableListForMyListItem()
        {
            List<MyListItem<XTable>> tables = new List<MyListItem<XTable>>(10);
            foreach (XTable t in Global.CurrentGrade.Database.Schema.TableList)
            {
                tables.Add(new MyListItem<XTable>(t.Name, t));
            }
            return tables;
        }
    }



    public struct XSubjectGroup
    {
        public int SubjectType { get; private set; }
        public string SubjectList { get; private set; }
        public string TotalScoreExpression { get; private set; }
        public XSubjectGroup(XmlNode node)
            : this()
        {
            if (node == null)
                return;
            SubjectType = node.GetAttributeInt32Value("subjectType", 0);
            SubjectList = node.GetAttributeStringValue("subjectList", "");
            TotalScoreExpression = node.GetAttributeStringValue("totalScoreExpression", "");
        }



    }

    public struct XInitialize
    {
        public List<XSubjectGroup> SubjectGroupList { get; private set; }
        public XInitialize(XmlNode node):this()
        {
            if (node == null)
            {
                return;
            }
            SubjectGroupList = new List<XSubjectGroup>(2);
            foreach (XmlNode n in node.SelectNodes("./subjectGroup"))
            {
                SubjectGroupList.Add(new XSubjectGroup(n));
            }
        }
    }
    
    public struct XDatabase
    {
        public XSchema Schema { get; private set; }
        public XInitialize Initialize { get; private set; }
        public XDatabase(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }

            Schema = new XSchema(node.SelectSingleNode("./schema"));
            Initialize = new XInitialize(node.SelectSingleNode("./initialize"));
        }

    }

    public struct XGrade
    {
        public int Id{get;private set;}
        public string Name{get; private set;}
        public string DatabaseName{get; private set;}
        public bool Target{ get; private set; }
        public List<XWorkbook> WorkbookList { get; private set; }
        public XDatabase Database { get; private set; }
        public XGrade(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }
            Id = node.GetAttributeInt32Value("id", 3);
            Name = node.GetAttributeStringValue("name", "");
            DatabaseName = node.GetAttributeStringValue("database", "");
            Target = node.GetAttributeBoolValue("target", false);
            Database = new XDatabase(node.SelectSingleNode("./database"));
            WorkbookList = new List<XWorkbook>(3);
            foreach (XmlNode n in node.SelectNodes("./report/workbook"))
            {
                WorkbookList.Add(new XWorkbook(n));
            }
        }

    }
    
    public struct XProduct
    {
        public string ProductName { get; private set; }
        public string Company { get; private set; }
        public string Author { get; private set; }
        public string Version { get; private set; }
        public XProduct(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }
            ProductName = node.GetAttributeStringValue("productName", "");
            Company = node.GetAttributeStringValue("company", "");
            Author = node.GetAttributeStringValue("author", "");
            Version = node.GetAttributeStringValue("version", "");
        }
    }

    public struct XDefault
    {
        public int GradeId { get; private set; }
        public string Database { get; private set; }
        public string Excel { get; private set; }
        public XDefault(XmlNode node)
            : this()
        {
            if (node == null)
            {
                return;
            }
            GradeId = node.GetAttributeInt32Value("gradeId", 1);
            Database = node.GetAttributeStringValue("database", "postgres");
            Excel = node.GetAttributeStringValue("excel", "excel8");
        }

    }

#endregion





}
