﻿namespace ScoreAnalyst
{
    partial class FormBrowserData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.dataGridView1 = new System.Windows.Forms.DataGridView();
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.tsslTableName = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tsslRowsCount = new System.Windows.Forms.ToolStripStatusLabel();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        	this.statusStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// dataGridView1
        	// 
        	this.dataGridView1.AllowUserToAddRows = false;
        	this.dataGridView1.AllowUserToDeleteRows = false;
        	this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView1.Location = new System.Drawing.Point(0, 0);
        	this.dataGridView1.Name = "dataGridView1";
        	this.dataGridView1.ReadOnly = true;
        	this.dataGridView1.RowTemplate.Height = 23;
        	this.dataGridView1.Size = new System.Drawing.Size(861, 359);
        	this.dataGridView1.TabIndex = 0;
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsslTableName,
        	        	        	this.tsslRowsCount});
        	this.statusStrip1.Location = new System.Drawing.Point(0, 362);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(861, 22);
        	this.statusStrip1.TabIndex = 1;
        	this.statusStrip1.Text = "statusStrip1";
        	// 
        	// tsslTableName
        	// 
        	this.tsslTableName.Name = "tsslTableName";
        	this.tsslTableName.Size = new System.Drawing.Size(56, 17);
        	this.tsslTableName.Text = "显示表名";
        	// 
        	// tsslRowsCount
        	// 
        	this.tsslRowsCount.Name = "tsslRowsCount";
        	this.tsslRowsCount.Size = new System.Drawing.Size(80, 17);
        	this.tsslRowsCount.Text = "显示表内行数";
        	// 
        	// FormBrowserData
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(861, 384);
        	this.Controls.Add(this.statusStrip1);
        	this.Controls.Add(this.dataGridView1);
        	this.Name = "FormBrowserData";
        	this.Text = "查看数据";
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        	this.statusStrip1.ResumeLayout(false);
        	this.statusStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripStatusLabel tsslRowsCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslTableName;
        private System.Windows.Forms.StatusStrip statusStrip1;

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
    }
}