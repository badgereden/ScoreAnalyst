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
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = StaticQueryHelper.UpdateIgnoreID();
            MessageBox.Show(string.Format("更新学生考号,更新数量为{0}", n),"更新考号成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReport fr = new FormReport();
            fr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormReportDifference frd = new FormReportDifference();
            frd.ShowDialog();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            foreach (XSubjectGroup sg in Global.CurrentGrade.Database.Initialize.SubjectGroupList)
            {
                StaticQueryHelper.Initialize(sg.SubjectType, sg.SubjectList, sg.TotalScoreExpression);
            }
            MessageBox.Show("初始化成功");
        }
    }
}
