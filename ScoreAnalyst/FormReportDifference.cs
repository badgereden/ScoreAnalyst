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
    public partial class FormReportDifference : FormReport
    {
        public FormReportDifference()
        {
            InitializeComponent();
        }
        public override void CustomInitializeComponent()
        {
            base.CustomInitializeComponent();
            //自定义.
            CheckBox chbValid_entry = new CheckBox();
            chbValid_entry.Text = "有效入围";
            chbValid_entry.Visible = true;
            chbValid_entry.Left = gbOption.Left + 10;
            chbValid_entry.Top = gbOption.Top + 10;
            this.gbOption.Controls.Add(chbValid_entry);



        }

    }
}
