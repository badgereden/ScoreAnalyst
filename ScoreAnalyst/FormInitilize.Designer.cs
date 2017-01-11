namespace ScoreAnalyst
{
    partial class FormInitilize
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbUpdateID = new System.Windows.Forms.CheckBox();
            this.chbIgnore = new System.Windows.Forms.CheckBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.chbTarget = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbTarget);
            this.groupBox1.Controls.Add(this.chbUpdateID);
            this.groupBox1.Controls.Add(this.chbIgnore);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(683, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chbUpdateID
            // 
            this.chbUpdateID.AutoSize = true;
            this.chbUpdateID.Location = new System.Drawing.Point(29, 38);
            this.chbUpdateID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbUpdateID.Name = "chbUpdateID";
            this.chbUpdateID.Size = new System.Drawing.Size(209, 19);
            this.chbUpdateID.TabIndex = 1;
            this.chbUpdateID.Text = "自动匹配不计考核学生考号";
            this.chbUpdateID.UseVisualStyleBackColor = true;
            // 
            // chbIgnore
            // 
            this.chbIgnore.AutoSize = true;
            this.chbIgnore.Checked = true;
            this.chbIgnore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIgnore.Location = new System.Drawing.Point(29, 65);
            this.chbIgnore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbIgnore.Name = "chbIgnore";
            this.chbIgnore.Size = new System.Drawing.Size(149, 19);
            this.chbIgnore.TabIndex = 0;
            this.chbIgnore.Text = "剔除不计考核学生";
            this.chbIgnore.UseVisualStyleBackColor = true;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(108, 215);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(137, 39);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(427, 215);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(133, 39);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // chbTarget
            // 
            this.chbTarget.AutoSize = true;
            this.chbTarget.Location = new System.Drawing.Point(29, 91);
            this.chbTarget.Name = "chbTarget";
            this.chbTarget.Size = new System.Drawing.Size(149, 19);
            this.chbTarget.TabIndex = 2;
            this.chbTarget.Text = "调整学生核算班级";
            this.chbTarget.UseVisualStyleBackColor = true;
            // 
            // FormInitilize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 269);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormInitilize";
            this.Text = "初始化";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbIgnore;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.CheckBox chbUpdateID;
        private System.Windows.Forms.CheckBox chbTarget;
    }
}