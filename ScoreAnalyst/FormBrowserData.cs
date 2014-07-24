using System.Data;
using System.Windows.Forms;

namespace ScoreAnalyst
{

    public partial class FormBrowserData : Form
    {
        private DataTable dt = null;
        private string _targetTableName;
        private string _targetTableAlias;
        public FormBrowserData(string targetTableName,string targetTableAlias)
        {
        	_targetTableName = targetTableName;
        	_targetTableAlias = targetTableAlias;
            InitializeComponent();
            InitializeCustomComponent();
        }
        
        public FormBrowserData(string targetTableName):this(targetTableName,"")
        {  }
		
        
        
        private void InitializeCustomComponent()
        {
            try
            {
                dt = StaticQueryHelper.BrowserData(_targetTableName);
                this.tsslTableName.Text = string.Format("表名:{0}", _targetTableAlias);
                this.tsslRowsCount.Text = string.Format("行数:{0}", dt.Rows.Count);
                this.dataGridView1.DataSource = dt;
                this.dataGridView1.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("postgresql服务未启动!");
            }

        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            //dt.Dispose();
            base.OnFormClosed(e);
        }


    }
}
