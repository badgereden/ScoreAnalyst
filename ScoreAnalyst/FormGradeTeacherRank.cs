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
    public partial class FormGradeTeacherRank : FormReport
    {
        private int difference_type=0;
        private bool valid_entry = false;
        private bool contain_3th_section = false;

        public FormGradeTeacherRank()
        {
            InitializeComponent();
        }
        public override void Report()
        {
            if (rbDifference_0.Checked)
            {
                difference_type = 0;
            }
            if (rbDifference_1.Checked)
            {
                difference_type = 1;
            }

            if (chbValid_entry.Checked)
            {
                valid_entry = true;
            }
            if (chbContain_3th_section.Checked)
            {
                contain_3th_section = true;
            }
            ExcelWriter ew = new ExcelWriter();
            ew.CreateSheet("教师超差排序");

            DataTable dt = StaticQueryHelper.GetGradeDifference(difference_type, valid_entry, contain_3th_section);
            progressBar.Increment(50);
            ew.WriteHeader(0, 0, dt);
            progressBar.Increment(10);
            ew.Write(1, 0, dt);
            progressBar.Increment(30);
            ew.SaveAs(tbFilePath.Text);
            progressBar.Increment(10);
            dt.Dispose();


        }


    }
}
