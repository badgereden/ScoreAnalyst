using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScoreAnalyst
{
    public partial class FormClearData : Form
    {
        public List<MyListItem<string>> tables;
        public FormClearData()
        {
            InitializeComponent();
            customInitialize();
        }

        private void customInitialize()
        {
            tables = Global.CurrentGrade.Database.Schema.GetTableListForMyListItem();
            this.checkedListBox1.DataSource = tables;
            this.checkedListBox1.ValueMember = "InterValue";
            this.checkedListBox1.DisplayMember = "DisplayValue";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                int rows=StaticQueryHelper.ClearData(tables[index].InterValue);
                MessageBox.Show(string.Format("成功清除{0}条记录！", rows));
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }





    }
}
