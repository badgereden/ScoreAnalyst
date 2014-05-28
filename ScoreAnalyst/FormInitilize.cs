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
    public partial class FormInitilize : Form
    {
        public FormInitilize()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            bool delete_ignore = chbIgnore.Checked;
            foreach (XSubjectGroup sg in Global.CurrentGrade.Database.Initialize.SubjectGroupList)
            {
                StaticQueryHelper.Initialize(sg.SubjectType, sg.SubjectList, sg.TotalScoreExpression,delete_ignore);
            }
            MessageBox.Show("初始化成功");
        }
    }
}
