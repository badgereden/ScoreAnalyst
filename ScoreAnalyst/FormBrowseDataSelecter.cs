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
    public partial class FormBrowseDataSelecter : Form
    {
        public FormBrowseDataSelecter()
        {
            InitializeComponent();
            customInitial();
        }

        private void customInitial()
        {
            listView1.SmallImageList = smallImageList;
            listView1.LargeImageList = largeImageList;
            foreach (XTable t in Global.CurrentGrade.Database.Schema.TableList)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = 0;
                item.Text = t.Name;
                item.ToolTipText = t.Target;
                listView1.Items.Add(item);
            }


        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item=listView1.SelectedItems[0];
            using (FormBrowserData fbd = new FormBrowserData(item.ToolTipText, item.Text))
            {
                fbd.ShowDialog();
            }
        }



        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                ListViewItem item = listView1.SelectedItems[0];
                using (FormImport fi = new FormImport(item.Text))
                {
                    fi.ShowDialog();
                }


            }
        }



 




    }
}
