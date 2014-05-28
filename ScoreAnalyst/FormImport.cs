/*
 * 由SharpDevelop创建。
 * 用户： 刘保恩
 * 日期: 2011/11/25
 * 时间: 11:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace ScoreAnalyst
{
	/// <summary>
	/// Description of FormImport.
	/// </summary>
	public partial class FormImport : Form
	{
        //导入完成时触发该事件
        public event ImportCompletedHandler ImportCompleted;
        List<MyListItem<XTable>> tables;
        private bool compeleted = false;

        public FormImport(string txt)
        {
            InitializeComponent();
            InitializeCustomComponent();
            int i=tables.FindIndex((item)=>{return item.DisplayValue == txt;});
            cbTableType.SelectedIndex = i;
        }
		public FormImport()
		{
			InitializeComponent();
			InitializeCustomComponent();
		}
	
		private void InitializeCustomComponent()
		{
			fill_cbTableType();
            this.ImportCompleted+=new ImportCompletedHandler(FormImport_ImportCompleted);
		}
		
		private void fill_cbTableType()
		{
            tables = Global.CurrentGrade.Database.Schema.GetXTableListForMyListItem();
            this.cbTableType.DataSource = tables;
            this.cbTableType.DisplayMember = "DisplayValue";
            this.cbTableType.ValueMember = "InterValue";

            this.cbTableType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbTableType.SelectedIndex = 0;
		}
		
	
		void BtnEnterClick(object sender, EventArgs e)
		{
			if(compeleted)
			{
				this.Close();
				return;
			}
			btnEnter.Enabled=false;
			btnEnter.Text="工作中...";
            XTable selectedTable =(XTable)cbTableType.SelectedValue;
            PostgresBulkCopy bulkCopy = new PostgresBulkCopy(Global.ConnectionString);
            bulkCopy.NotifyAfter = 100;
            bulkCopy.DestinationTableName = selectedTable.Target;
            bulkCopy.RowsCopied += new NpgsqlRowsCopiedEventHandler(bulkCopy_RowsCopied);
            
            int rows=bulkCopy.WriteToServer(tbTablePath.Text, selectedTable.Fields, selectedTable.Target);
            if (this.ImportCompleted != null)
            {
                ImportCompleted(rows);
            }

            bulkCopy.Dispose();
		}




		private void bulkCopy_RowsCopied(object sender,NpgsqlRowsCopiedEventArgs e)
		{
                     pbWorking.Maximum = e.Total;
            		pbWorking.Increment(e.RowsCopied);
		}

        private void FormImport_ImportCompleted(int total)
        {
            btnEnter.Text = "完成(&F)";
            compeleted = true;
            btnEnter.Enabled = true;
            MessageBox.Show(string.Format("成功导入{0}条记录", total), "导入数据成功");
        }
	
		
		void BtnBrowerClick(object sender, EventArgs e)
		{
				OpenFileDialog fd=new OpenFileDialog();
				fd.Filter="Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
				if(fd.ShowDialog()== DialogResult.OK)
				{
					this.tbTablePath.Text=fd.FileName;
				}
                fd.Dispose();
		}
	}
	
    public delegate void ImportCompletedHandler(int total);
   
	
}
