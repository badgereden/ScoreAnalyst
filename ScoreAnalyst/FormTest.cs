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
            Report report = new Report(Global.GradeId, Global.CurrentGrade);
            var science = new string[] { "语文", "数学", "英语","物理","化学","生物","总分"};
            var arts= new string[] { "语文", "数学", "英语", "政治", "历史", "地理", "总分" };
            report.ReportSectionByPositionValid("d:\\理科-实验班分段.xls", 1, "17,18,19",science, 30, "60", true);
            report.ReportSectionByPositionValid("d:\\文科-实验班分段.xls", 2, "20,21", arts, 20, "40", true);


        }
    }
}
