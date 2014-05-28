namespace ScoreAnalyst
{
    partial class FormGradeDifference
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chbContain_composite = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.chkbTranspose = new System.Windows.Forms.CheckBox();
            this.rdbDifference0 = new System.Windows.Forms.RadioButton();
            this.rdbDifference1 = new System.Windows.Forms.RadioButton();
            this.chbContain_3th_section = new System.Windows.Forms.CheckBox();
            this.chbValid_entry = new System.Windows.Forms.CheckBox();
            this.chbScore = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输出文件位置";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(117, 19);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(279, 21);
            this.tbFileName.TabIndex = 1;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(426, 17);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(105, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "浏览(&B)...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(426, 68);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始生成(&S)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chbContain_composite
            // 
            this.chbContain_composite.AutoSize = true;
            this.chbContain_composite.Checked = true;
            this.chbContain_composite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbContain_composite.Location = new System.Drawing.Point(238, 90);
            this.chbContain_composite.Name = "chbContain_composite";
            this.chbContain_composite.Size = new System.Drawing.Size(96, 16);
            this.chbContain_composite.TabIndex = 6;
            this.chbContain_composite.Text = "生成文综理综";
            this.chbContain_composite.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 168);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(535, 16);
            // 
            // chkbTranspose
            // 
            this.chkbTranspose.AutoSize = true;
            this.chkbTranspose.Checked = true;
            this.chkbTranspose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbTranspose.Location = new System.Drawing.Point(26, 129);
            this.chkbTranspose.Name = "chkbTranspose";
            this.chkbTranspose.Size = new System.Drawing.Size(48, 16);
            this.chkbTranspose.TabIndex = 8;
            this.chkbTranspose.Text = "转置";
            this.chkbTranspose.UseVisualStyleBackColor = true;
            // 
            // rdbDifference0
            // 
            this.rdbDifference0.AutoSize = true;
            this.rdbDifference0.Checked = true;
            this.rdbDifference0.Location = new System.Drawing.Point(26, 59);
            this.rdbDifference0.Name = "rdbDifference0";
            this.rdbDifference0.Size = new System.Drawing.Size(47, 16);
            this.rdbDifference0.TabIndex = 9;
            this.rdbDifference0.TabStop = true;
            this.rdbDifference0.Text = "超差";
            this.rdbDifference0.UseVisualStyleBackColor = true;
            // 
            // rdbDifference1
            // 
            this.rdbDifference1.AutoSize = true;
            this.rdbDifference1.Location = new System.Drawing.Point(93, 59);
            this.rdbDifference1.Name = "rdbDifference1";
            this.rdbDifference1.Size = new System.Drawing.Size(59, 16);
            this.rdbDifference1.TabIndex = 10;
            this.rdbDifference1.Text = "完成率";
            this.rdbDifference1.UseVisualStyleBackColor = true;
            // 
            // chbContain_3th_section
            // 
            this.chbContain_3th_section.AutoSize = true;
            this.chbContain_3th_section.Location = new System.Drawing.Point(26, 90);
            this.chbContain_3th_section.Name = "chbContain_3th_section";
            this.chbContain_3th_section.Size = new System.Drawing.Size(84, 16);
            this.chbContain_3th_section.TabIndex = 11;
            this.chbContain_3th_section.Text = "有三本指标";
            this.chbContain_3th_section.UseVisualStyleBackColor = true;
            // 
            // chbValid_entry
            // 
            this.chbValid_entry.AutoSize = true;
            this.chbValid_entry.Location = new System.Drawing.Point(137, 90);
            this.chbValid_entry.Name = "chbValid_entry";
            this.chbValid_entry.Size = new System.Drawing.Size(72, 16);
            this.chbValid_entry.TabIndex = 12;
            this.chbValid_entry.Text = "有效入围";
            this.chbValid_entry.UseVisualStyleBackColor = true;
            // 
            // chbScore
            // 
            this.chbScore.AutoSize = true;
            this.chbScore.Location = new System.Drawing.Point(137, 129);
            this.chbScore.Name = "chbScore";
            this.chbScore.Size = new System.Drawing.Size(84, 16);
            this.chbScore.TabIndex = 13;
            this.chbScore.Text = "分数段计算";
            this.chbScore.UseVisualStyleBackColor = true;
            // 
            // FormGradeDifference
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 190);
            this.Controls.Add(this.chbScore);
            this.Controls.Add(this.chbValid_entry);
            this.Controls.Add(this.chbContain_3th_section);
            this.Controls.Add(this.rdbDifference1);
            this.Controls.Add(this.rdbDifference0);
            this.Controls.Add(this.chkbTranspose);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chbContain_composite);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Name = "FormGradeDifference";
            this.Text = "年级加权超差分析";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chbContain_composite;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.CheckBox chkbTranspose;
        private System.Windows.Forms.RadioButton rdbDifference0;
        private System.Windows.Forms.RadioButton rdbDifference1;
        private System.Windows.Forms.CheckBox chbContain_3th_section;
        private System.Windows.Forms.CheckBox chbValid_entry;
        private System.Windows.Forms.CheckBox chbScore;
    }
}