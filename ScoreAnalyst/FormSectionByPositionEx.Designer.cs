namespace ScoreAnalyst
{
    partial class FormSectionByPositionEx
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbScienceAll = new System.Windows.Forms.CheckBox();
            this.clbScience = new System.Windows.Forms.CheckedListBox();
            this.cbArtsAll = new System.Windows.Forms.CheckBox();
            this.clbArts = new System.Windows.Forms.CheckedListBox();
            this.clbClassList = new System.Windows.Forms.CheckedListBox();
            this.cbClassAll = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.chbValid_entry = new System.Windows.Forms.CheckBox();
            this.tbSectionList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbScience = new System.Windows.Forms.CheckBox();
            this.cbArts = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输出位置:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(255, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "浏览(&B)...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbScienceAll
            // 
            this.cbScienceAll.AutoSize = true;
            this.cbScienceAll.Location = new System.Drawing.Point(48, 232);
            this.cbScienceAll.Name = "cbScienceAll";
            this.cbScienceAll.Size = new System.Drawing.Size(48, 16);
            this.cbScienceAll.TabIndex = 3;
            this.cbScienceAll.Text = "全选";
            this.cbScienceAll.UseVisualStyleBackColor = true;
            this.cbScienceAll.CheckedChanged += new System.EventHandler(this.cbScience_CheckedChanged);
            // 
            // clbScience
            // 
            this.clbScience.CheckOnClick = true;
            this.clbScience.FormattingEnabled = true;
            this.clbScience.Items.AddRange(new object[] {
            "语文",
            "数学",
            "英语",
            "物理",
            "化学",
            "生物",
            "理综",
            "总分"});
            this.clbScience.Location = new System.Drawing.Point(48, 94);
            this.clbScience.Name = "clbScience";
            this.clbScience.Size = new System.Drawing.Size(62, 132);
            this.clbScience.TabIndex = 4;
            // 
            // cbArtsAll
            // 
            this.cbArtsAll.AutoSize = true;
            this.cbArtsAll.Enabled = false;
            this.cbArtsAll.Location = new System.Drawing.Point(133, 232);
            this.cbArtsAll.Name = "cbArtsAll";
            this.cbArtsAll.Size = new System.Drawing.Size(48, 16);
            this.cbArtsAll.TabIndex = 5;
            this.cbArtsAll.Text = "全选";
            this.cbArtsAll.UseVisualStyleBackColor = true;
            this.cbArtsAll.CheckedChanged += new System.EventHandler(this.cbArts_CheckedChanged);
            // 
            // clbArts
            // 
            this.clbArts.CheckOnClick = true;
            this.clbArts.Enabled = false;
            this.clbArts.FormattingEnabled = true;
            this.clbArts.Items.AddRange(new object[] {
            "语文",
            "数学",
            "英语",
            "政治",
            "历史",
            "地理",
            "文综",
            "总分"});
            this.clbArts.Location = new System.Drawing.Point(133, 94);
            this.clbArts.Name = "clbArts";
            this.clbArts.Size = new System.Drawing.Size(71, 132);
            this.clbArts.TabIndex = 6;
            // 
            // clbClassList
            // 
            this.clbClassList.CheckOnClick = true;
            this.clbClassList.Location = new System.Drawing.Point(228, 94);
            this.clbClassList.Name = "clbClassList";
            this.clbClassList.Size = new System.Drawing.Size(120, 132);
            this.clbClassList.TabIndex = 7;
            // 
            // cbClassAll
            // 
            this.cbClassAll.AutoSize = true;
            this.cbClassAll.Location = new System.Drawing.Point(228, 232);
            this.cbClassAll.Name = "cbClassAll";
            this.cbClassAll.Size = new System.Drawing.Size(48, 16);
            this.cbClassAll.TabIndex = 8;
            this.cbClassAll.Text = "全选";
            this.cbClassAll.UseVisualStyleBackColor = true;
            this.cbClassAll.CheckedChanged += new System.EventHandler(this.cbClass_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(405, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "开始生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chbValid_entry
            // 
            this.chbValid_entry.AutoSize = true;
            this.chbValid_entry.Location = new System.Drawing.Point(405, 146);
            this.chbValid_entry.Name = "chbValid_entry";
            this.chbValid_entry.Size = new System.Drawing.Size(72, 16);
            this.chbValid_entry.TabIndex = 10;
            this.chbValid_entry.Text = "有效入围";
            this.chbValid_entry.UseVisualStyleBackColor = true;
            // 
            // tbSectionList
            // 
            this.tbSectionList.Location = new System.Drawing.Point(405, 94);
            this.tbSectionList.Name = "tbSectionList";
            this.tbSectionList.Size = new System.Drawing.Size(123, 21);
            this.tbSectionList.TabIndex = 11;
            this.tbSectionList.Text = "50,100,200,300,400,500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "统计分段:";
            // 
            // cbScience
            // 
            this.cbScience.AutoSize = true;
            this.cbScience.Location = new System.Drawing.Point(48, 71);
            this.cbScience.Name = "cbScience";
            this.cbScience.Size = new System.Drawing.Size(48, 16);
            this.cbScience.TabIndex = 13;
            this.cbScience.Text = "理科";
            this.cbScience.UseVisualStyleBackColor = true;
            // 
            // cbArts
            // 
            this.cbArts.AutoSize = true;
            this.cbArts.Location = new System.Drawing.Point(133, 71);
            this.cbArts.Name = "cbArts";
            this.cbArts.Size = new System.Drawing.Size(48, 16);
            this.cbArts.TabIndex = 14;
            this.cbArts.Text = "文科";
            this.cbArts.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "班级列表";
            // 
            // FormSectionByPositionEx
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 269);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbArts);
            this.Controls.Add(this.cbScience);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSectionList);
            this.Controls.Add(this.chbValid_entry);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbClassAll);
            this.Controls.Add(this.clbClassList);
            this.Controls.Add(this.clbArts);
            this.Controls.Add(this.cbArtsAll);
            this.Controls.Add(this.clbScience);
            this.Controls.Add(this.cbScienceAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormSectionByPositionEx";
            this.Text = "名次段人数统计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbScienceAll;
        private System.Windows.Forms.CheckedListBox clbScience;
        private System.Windows.Forms.CheckBox cbArtsAll;
        private System.Windows.Forms.CheckedListBox clbArts;
        private System.Windows.Forms.CheckedListBox clbClassList;
        private System.Windows.Forms.CheckBox cbClassAll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chbValid_entry;
        private System.Windows.Forms.TextBox tbSectionList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbScience;
        private System.Windows.Forms.CheckBox cbArts;
        private System.Windows.Forms.Label label3;
    }
}