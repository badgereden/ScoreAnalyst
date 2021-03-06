﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ScoreAnalyst
{
    public partial class FormSectionByPositionEx : Form
    {
        private bool finish = false;
    
        public FormSectionByPositionEx()
        {
            InitializeComponent();
            customInitialize();

        }

        private void customInitialize()
        {
            //因为目前学校仅理科班需要分析.所以只加载理科班.
            System.Data.DataTable dt = StaticQueryHelper.ExecuteQuery("select 班级 from \"class\" where 类型=1 order by 班级");
            foreach (DataRow row in dt.Rows)
            {
                clbClassList.Items.Add(row[0].ToString(), false);
            }
            dt.Dispose();
       }




 

        private void FullSelected( CheckedListBox clb, bool selected)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, selected);
            }
        
        }

        private void cbScience_CheckedChanged(object sender, EventArgs e)
        {
            if (cbScienceAll.Checked)
            {
                FullSelected(clbScience, true);

            }
            else
            {
                FullSelected(clbScience, false);
            }
        }

        private void cbArts_CheckedChanged(object sender, EventArgs e)
        {
            if (cbArtsAll.Checked)
            {
                FullSelected(clbArts, true);

            }
            else
            {
                FullSelected(clbArts, false);
            }
        }

        private void cbClass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClassAll.Checked)
            {
                FullSelected(clbClassList, true);
            }
            else
            {
                FullSelected(clbClassList, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.OverwritePrompt = true;
            sfd.CreatePrompt = false;
            sfd.DefaultExt = ".xls";
            sfd.Filter = "Excel文件|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = sfd.FileName;
            }
            sfd.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (finish)
            {
                this.Close();
                return;
            }

            if (this.textBox1.Text.Length == 0)
            {
                MessageBox.Show("请选择输出文件的位置!");
                return;
            }
            if (this.clbScience.CheckedItems.Count == 0 && this.clbArts.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择学科!");
                return;
            }
            if (this.clbClassList.CheckedItems.Count == 0 )
            {
                MessageBox.Show("请选择班级!");
                return;
            }




            //为了简单起见,同步输出
            report();

            finish = true;
            this.button2.Enabled = true;
            this.button2.Text = "完成(&F)";
        }




        private void report()
        {

            //StaticQueryHelper.Initialize(1);
            string classes = getCheckedClassList();
            string sectionList = tbSectionList.Text.Trim();
            bool valid_entry=chbValid_entry.Checked;
            
            List<string> subjects = getSubjects();
            string fileName = this.textBox1.Text;
            DataTable dt = null;
            DataTable dtt = new DataTable();
            string [] classArray = classes.Split(',');
           int class_count=classArray.Length;
            //增加一行班级.
            for (int i = 0; i < classArray.Length; i++)
            {
                dtt.Columns.Add(classArray[i], typeof(string));
            }
            foreach (string subject in subjects)
            {
                dt = StaticQueryHelper.GetSectionByPosition(1, subject, classes,sectionList,valid_entry);

                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        DataRow dr = dtt.NewRow();
                        for (int j = 0; j < class_count; j++)
                        {
                            dr[j] = dt.Rows[j][i].ToString();
                        }
                        dtt.Rows.Add(dr);
                    }
            }
            ExcelWriter ew = new ExcelWriter();
            ew.CreateSheet("竞赛班名次段人数统计");
            ew.WriteHeader(0, 0, dtt);
            ew.Write(1, 0, dtt);
         
            ew.SaveAs(fileName);

        }

        private string getCheckedClassList()
        {
            StringBuilder sb = new StringBuilder(50);
            foreach (object item in clbClassList.CheckedItems)
            {
                sb.AppendFormat("{0},", item.ToString());

            }
            return sb.ToString(0, sb.Length - 1);
        }

        private List<string> getSubjects()
        {
            //string[] subjects = new string[clbScience.CheckedItems.Count];
            List<string> subjects = new List<string>(clbScience.CheckedItems.Count);
            foreach (object item in clbScience.CheckedItems)
            {
                subjects.Add(item.ToString());
            }
            return subjects;
        }

    }
}
