using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

namespace ScoreAnalyst
{

    /// <summary>
    /// 该类同时负责根据用户选择的年级,加载配置文件.
    /// </summary>
    public sealed partial  class FormWelcome : Form
    {
        SAConfigureReader cr = null;
        

        public FormWelcome()
        {
            InitializeComponent();
            cr = new SAConfigureReader(Global.ConfigFile);
            Global.Default = new XDefault(cr.GetDefaultNode());
            Global.Product = new XProduct(cr.GetProductNode());
        }

        private void FormSelectGrade_Load(object sender, EventArgs e)
        {
            List<MyListItem<int>> itemlist = cr.GetGradeList();
            cbGrade.DataSource = itemlist;
            cbGrade.DisplayMember = "DisplayValue";
            cbGrade.ValueMember = "InterValue";
            cbGrade.SelectedValue= Global.Default.GradeId;

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            
            //设置当前的年级.
            Global.GradeId = (int)cbGrade.SelectedValue;
            //加载当前年级节点
            Global.CurrentGrade = new XGrade(cr.GetGradeNode(Global.GradeId));
            //获得数据库连接字符串的格式化字符串
            Global.ConnectionString = string.Format(cr.GetConnectionStringFormat(Global.Default.Database), Global.CurrentGrade.DatabaseName);
            //获得Excel的连接字符串格式
            Global.ExcelConnectionStringFormat = cr.GetConnectionStringFormat(Global.Default.Excel);
            this.Close();
        }




        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSelectGrade_FormClosing(object sender, FormClosingEventArgs e)
        {
            cr.Dispose();
            //e.Cancel = false;
        }


       


    }
}
