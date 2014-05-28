namespace ScoreAnalyst
{
    partial class FormGradeTeacherRank
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
            this.rbDifference_0 = new System.Windows.Forms.RadioButton();
            this.rbDifference_1 = new System.Windows.Forms.RadioButton();
            this.chbValid_entry = new System.Windows.Forms.CheckBox();
            this.chbContain_3th_section = new System.Windows.Forms.CheckBox();
            this.gbOutputPath.SuspendLayout();
            this.gbOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOption
            // 
            this.gbOption.Controls.Add(this.chbContain_3th_section);
            this.gbOption.Controls.Add(this.chbValid_entry);
            this.gbOption.Controls.Add(this.rbDifference_1);
            this.gbOption.Controls.Add(this.rbDifference_0);
            // 
            // rbDifference_0
            // 
            this.rbDifference_0.AutoSize = true;
            this.rbDifference_0.Location = new System.Drawing.Point(29, 29);
            this.rbDifference_0.Name = "rbDifference_0";
            this.rbDifference_0.Size = new System.Drawing.Size(47, 16);
            this.rbDifference_0.TabIndex = 0;
            this.rbDifference_0.TabStop = true;
            this.rbDifference_0.Text = "超差";
            this.rbDifference_0.UseVisualStyleBackColor = true;
            // 
            // rbDifference_1
            // 
            this.rbDifference_1.AutoSize = true;
            this.rbDifference_1.Location = new System.Drawing.Point(151, 29);
            this.rbDifference_1.Name = "rbDifference_1";
            this.rbDifference_1.Size = new System.Drawing.Size(59, 16);
            this.rbDifference_1.TabIndex = 1;
            this.rbDifference_1.TabStop = true;
            this.rbDifference_1.Text = "完成率";
            this.rbDifference_1.UseVisualStyleBackColor = true;
            // 
            // chbValid_entry
            // 
            this.chbValid_entry.AutoSize = true;
            this.chbValid_entry.Location = new System.Drawing.Point(29, 67);
            this.chbValid_entry.Name = "chbValid_entry";
            this.chbValid_entry.Size = new System.Drawing.Size(72, 16);
            this.chbValid_entry.TabIndex = 2;
            this.chbValid_entry.Text = "有效入围";
            this.chbValid_entry.UseVisualStyleBackColor = true;
            // 
            // chbContain_3th_section
            // 
            this.chbContain_3th_section.AutoSize = true;
            this.chbContain_3th_section.Location = new System.Drawing.Point(151, 67);
            this.chbContain_3th_section.Name = "chbContain_3th_section";
            this.chbContain_3th_section.Size = new System.Drawing.Size(84, 16);
            this.chbContain_3th_section.TabIndex = 3;
            this.chbContain_3th_section.Text = "有三本指标";
            this.chbContain_3th_section.UseVisualStyleBackColor = true;
            // 
            // FormGradeTeacherRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 279);
            this.Name = "FormGradeTeacherRank";
            this.Text = "Form1";
            this.gbOutputPath.ResumeLayout(false);
            this.gbOutputPath.PerformLayout();
            this.gbOption.ResumeLayout(false);
            this.gbOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbContain_3th_section;
        private System.Windows.Forms.CheckBox chbValid_entry;
        private System.Windows.Forms.RadioButton rbDifference_1;
        private System.Windows.Forms.RadioButton rbDifference_0;
    }
}