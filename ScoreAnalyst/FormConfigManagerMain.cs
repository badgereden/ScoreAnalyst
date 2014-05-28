using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace ScoreAnalyst
{
    public partial class FormConfigManagerMain : Form
    {
        private XmlDocument doc;
        private string fileName;
        private bool dirty;
        private ValueChangedEventHandle ValueChandedProcess;
        public FormConfigManagerMain()
        {
            InitializeComponent();
            LoadConfig();
            ValueChandedProcess = new ValueChangedEventHandle(fd_ValueChanded);
            listView1.Height = SystemInformation.WorkingArea.Height-40;
            listView1.Width = (int)(SystemInformation.WorkingArea.Width * 0.78);
            listView1.Left = (int)(SystemInformation.WorkingArea.Width * 0.19 + 20);
            treeView1.Height = SystemInformation.WorkingArea.Height-40;
            treeView1.Width = (int)(SystemInformation.WorkingArea.Width * 0.18);

        }

        public void LoadConfig()
        {
            fileName = "config\\new-config.xml";
            doc = new XmlDocument();
            try
            {
                doc.Load(fileName);
            }
            catch( System.IO.FileNotFoundException e)
            {
                MessageBox.Show(string.Format("指定的文件不存在,文件名为:{0}", e.FileName));
                Application.Exit();
                return;
            }
            treeView1.Nodes.Add(Node2TreeNode(doc.DocumentElement));
            listView1.Columns.Add("属性", 120);
            listView1.Columns.Add("值", listView1.Width - 120);
  
             //treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
        }



        void displayNode(XmlNode node)
        {
            if (node == null)
                return;
            if (node.Attributes == null)
                return;
            if (node.Attributes.Count ==0)
                return;
            listView1.Items.Clear();
            foreach (XmlAttribute a in node.Attributes)
            {
                ListViewItem item = new ListViewItem(new string[] { a.Name, a.Value });
                item.Tag = a;
                listView1.Items.Add(item);
            }
        
        }



        public TreeNode Node2TreeNode(XmlNode xmlnode)
        {
            TreeNode tn = new TreeNode();
            if (!xmlnode.HasChildNodes)
            {
                if (xmlnode.Attributes["caption"] == null)
                {
                    tn.Text = "未命名节点";
                }
                else
                {
                    tn.Text = xmlnode.Attributes["caption"].Value;
                }
                tn.Tag = xmlnode;
              }
            else
            {
                tn.Text = xmlnode.Attributes["caption"].Value;
                tn.Tag = xmlnode;
                foreach (XmlNode n in xmlnode.ChildNodes)
                {
                    tn.Nodes.Add(Node2TreeNode(n));
                }
            }

            return tn;
        
        }

        public string getXPath(XmlNode node,XmlNode root)
        {
            XmlNode cn = node;
            Stack<string> s = new Stack<string>();
            while (cn.ParentNode != root)
            {
                s.Push(string.Format("/{0}", cn.Value));
                cn = cn.ParentNode;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(s.Pop());
            return sb.ToString();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsItem.Show(sender as ListView, new Point(e.X, e.Y));
                
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cmsEdit_Click(null, null);
        }

 
        private void cmsEdit_Click(object sender, EventArgs e)
        {
            cms_Click(ValueChangedType.EDIT);
        }

        void fd_ValueChanded(ValueChangedEventArgs vce)
        {
            switch (vce.ChangedType)
            {
                case ValueChangedType.CREATE:
                    {
                        XmlAttribute xa = doc.CreateAttribute(vce.AttributeName);
                        xa.Value = vce.AttributeValue;
                        XmlNode n = treeView1.SelectedNode.Tag as XmlNode;
                        n.Attributes.Append(xa);
                        dirty = true;
                        break;
                    }
                case ValueChangedType.EDIT:
                    {
                        XmlAttribute xa = listView1.SelectedItems[0].Tag as XmlAttribute;
                        if (xa.Value != vce.AttributeValue)
                        {
                            xa.Value = vce.AttributeValue;
                            dirty = true;
                        }
                        break;
                    }
                case ValueChangedType.RENAME:
                    {
                        XmlAttribute xa = doc.CreateAttribute(vce.AttributeName);
                        xa.Value = vce.AttributeValue;
                        XmlNode n = treeView1.SelectedNode.Tag as XmlNode;
                        n.Attributes.Append(xa);
                        n.Attributes.RemoveNamedItem(vce.OrignalAttributeName);
                        dirty = true;
                        break;
                    }
            }

            if (vce.ChangedType==ValueChangedType.CREATE)
            {
                XmlAttribute xa = doc.CreateAttribute(vce.AttributeName);
                xa.Value = vce.AttributeValue;
                XmlNode n = treeView1.SelectedNode.Tag as XmlNode;
                n.Attributes.Append(xa);
                dirty = true;
            }
            else
            {
                XmlAttribute xa = listView1.SelectedItems[0].Tag as XmlAttribute;
                if (xa.Value != vce.AttributeValue)
                {
                    xa.Value= vce.AttributeValue;
                    dirty = true;
                }
              
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (dirty)
            {
                if (MessageBox.Show("要保存修改的值吗？", "保存修改", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent=true;
                    settings.IndentChars="    ";
                    settings.Encoding = Encoding.UTF8;
                    using(XmlWriter writer=XmlWriter.Create(fileName,settings))
                    {
                        doc.Save(writer);
                    }
                   
                }
            }
        }

        private void cmsNew_Click(object sender, EventArgs e)
        {
            cms_Click(ValueChangedType.CREATE);
        }

        private void cms_Click(ValueChangedType vct)
        {
            FormDialog fd;
            if (vct == ValueChangedType.CREATE)
            {
                fd = new FormDialog(null, null, vct);
            }
            else
            {
                XmlAttribute xa = listView1.SelectedItems[0].Tag as XmlAttribute;
                fd = new FormDialog(xa.Name, xa.Value, vct);
            }
            fd.ValueChanded += ValueChandedProcess;
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                displayNode(treeView1.SelectedNode.Tag as XmlNode);
            }
            fd.ValueChanded -= ValueChandedProcess;
            fd.Dispose();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            XmlAttribute xa = listView1.SelectedItems[0].Tag as XmlAttribute;
            XmlNode node=treeView1.SelectedNode.Tag as XmlNode;
            node.Attributes.Remove(xa);
            dirty = true;
            displayNode(node);
        }

        private void cmsRename_Click(object sender, EventArgs e)
        {
            cms_Click(ValueChangedType.RENAME);
        }
        /// <summary>
        /// 当拖动某项时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.Move);

        }
        /// <summary>
        /// 用鼠标拖动某项至该控件的区域时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
           
        }

        /// <summary>
        /// 拖动时拖着某项置于某行上方时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = listView1.PointToClient(ptScreen);
            ListViewItem item = listView1.GetItemAt(pt.X, pt.Y);
            if (item != null)
                item.Selected = true;
        }

        /// <summary>
        /// 拖动结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = listView1.PointToClient(ptScreen);
            XmlNode node = treeView1.SelectedNode.Tag as XmlNode;
            ListViewItem TargetItem = listView1.GetItemAt(pt.X, pt.Y);//拖动的项将放置于该项之前
            ListViewItem newItem = (ListViewItem)draggedItem.Clone();

            listView1.Items.Insert(TargetItem.Index, newItem);
            node.Attributes.InsertBefore( (newItem.Tag as XmlAttribute),(TargetItem.Tag as XmlAttribute));
            //node.Attributes.Remove(draggedItem.Tag as XmlAttribute);
            listView1.Items.Remove(draggedItem);
            dirty = true;
        }

        private void cmsItem_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                e.Cancel = true;
                return;
            }
            if (listView1.SelectedItems.Count == 0)
            {
                cmsEdit.Enabled = false;
                cmsDelete.Enabled = false;
                cmsRename.Enabled = false;
            }
            else
            {
                cmsEdit.Enabled = true;
                cmsDelete.Enabled = true;
                cmsRename.Enabled = true;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XmlNode node = e.Node.Tag as XmlNode;
            displayNode(node);
        }




    }

   

}
