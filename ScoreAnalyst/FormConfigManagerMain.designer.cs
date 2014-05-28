namespace ScoreAnalyst
{
    partial class FormConfigManagerMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cmsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cmsItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(25, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Scrollable = false;
            this.treeView1.Size = new System.Drawing.Size(206, 426);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // cmsItem
            // 
            this.cmsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEdit,
            this.cmsRename,
            this.toolStripMenuItem1,
            this.cmsNew,
            this.cmsDelete});
            this.cmsItem.Name = "cmsItem";
            this.cmsItem.Size = new System.Drawing.Size(153, 120);
            this.cmsItem.Opening += new System.ComponentModel.CancelEventHandler(this.cmsItem_Opening);
            // 
            // cmsEdit
            // 
            this.cmsEdit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new System.Drawing.Size(112, 22);
            this.cmsEdit.Text = "编辑";
            this.cmsEdit.Click += new System.EventHandler(this.cmsEdit_Click);
            // 
            // cmsRename
            // 
            this.cmsRename.Name = "cmsRename";
            this.cmsRename.Size = new System.Drawing.Size(112, 22);
            this.cmsRename.Text = "重命名";
            this.cmsRename.Click += new System.EventHandler(this.cmsRename_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // cmsNew
            // 
            this.cmsNew.Name = "cmsNew";
            this.cmsNew.Size = new System.Drawing.Size(112, 22);
            this.cmsNew.Text = "新建";
            this.cmsNew.Click += new System.EventHandler(this.cmsNew_Click);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(112, 22);
            this.cmsDelete.Text = "删除";
            this.cmsDelete.Click += new System.EventHandler(this.cmsDelete_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.ContextMenuStrip = this.cmsItem;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(237, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(371, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // FormConfigManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Name = "FormConfigManagerMain";
            this.Text = "配置管理器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.cmsItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip cmsItem;
        private System.Windows.Forms.ToolStripMenuItem cmsEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsNew;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsRename;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ListView listView1;
    }
}

