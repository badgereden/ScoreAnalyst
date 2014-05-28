using System.Windows.Forms;
using System.Data;
using System;

namespace ScoreAnalyst
{
    public partial class FormRestore : Form
    {
        public FormRestore()
        {
            InitializeComponent();
            initialize();
        }
        private void initialize()
        {
            lvExamList.BeginUpdate();
            //增加列头
            lvExamList.Columns.Add("exam_id", "", 28);
            lvExamList.Columns.Add("exam_name", "考试名称",440);
            lvExamList.Columns.Add("exam_date", "考试时间",84);
            //增加列表
            DataTable dt = StaticQueryHelper.ExecuteQuery("select exam_id,exam_name,exam_date::varchar(10) from exam_information order by exam_date");
            foreach(DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(new string[3]{
                    row[0].ToString(),
                    row[1].ToString(),
                    row[2].ToString()
                });
                lvExamList.Items.Add(item);
            }
       

            lvExamList.EndUpdate();
        }

        private void btnCancle_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRestore_Click(object sender, System.EventArgs e)
        {
            if (lvExamList.SelectedItems.Count == 0)
                return;
            int exam_id = Int32.Parse(lvExamList.SelectedItems[0].SubItems[0].Text);
            int rows=StaticQueryHelper.RestoreScore(exam_id);
            MessageBox.Show(string.Format("还原成功,还原的记录数量为:{0}", rows), "还原成功");
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (lvExamList.SelectedItems.Count == 0)
                return;
            ListViewItem item = lvExamList.SelectedItems[0];
            int exam_id = Int32.Parse(item.SubItems[0].Text);
            int rows = StaticQueryHelper.DeleteBackup(exam_id);
            MessageBox.Show(string.Format("删除成功,删除的记录数量为:{0}", rows), "删除成功");
            lvExamList.BeginUpdate();
            item.Remove();
            lvExamList.EndUpdate();
        }



    }
}
