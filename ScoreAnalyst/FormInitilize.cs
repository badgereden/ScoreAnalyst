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
        private bool finish = false;
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
            if (finish)
            {
                this.Close();
                return;
            }
            else
            {
                bool delete_ignore = chbIgnore.Checked;


                if (chbUpdateID.Checked)
                {
                    int rows = StaticQueryHelper.UpdateIgnoreID();
                    MessageBox.Show(string.Format("自动匹配{0}名不计考核学生考号", rows));
                }


                foreach (XSubjectGroup sg in Global.CurrentGrade.Database.Initialize.SubjectGroupList)
                {
                    StaticQueryHelper.Initialize(sg.SubjectType, sg.SubjectList, sg.TotalScoreExpression, delete_ignore);
                }

                if (chbTarget.Checked)
                {
                    StaticQueryHelper.Adjust();
                }

                MessageBox.Show("初始化成功");
                this.btnEnter.Text = "完成";
                finish = true;
            }
        }
    }
}
