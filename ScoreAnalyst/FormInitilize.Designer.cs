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
            this.chbIgnore = new System.Windows.Forms.CheckBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.chbUpdateID = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbUpdateID);
            this.groupBox1.Controls.Add(this.chbIgnore);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chbIgnore
            // 
            this.chbIgnore.AutoSize = true;
            this.chbIgnore.Checked = true;
            this.chbIgnore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIgnore.Location = new System.Drawing.Point(22, 65);
            this.chbIgnore.Name = "chbIgnore";
            this.chbIgnore.Size = new System.Drawing.Size(120, 16);
            this.chbIgnore.TabIndex = 0;
            this.chbIgnore.Text = "剔除不计考核学生";
            this.chbIgnore.UseVisualStyleBackColor = true;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(81, 172);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(103, 31);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(320, 172);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 31);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // chbUpdateID
            // 
            this.chbUpdateID.AutoSize = true;
            this.chbUpdateID.Location = new System.Drawing.Point(22, 30);
            this.chbUpdateID.Name = "chbUpdateID";
            this.chbUpdateID.Size = new System.Drawing.Size(168, 16);
            this.chbUpdateID.TabIndex = 1;
            this.chbUpdateID.Text = "自动匹配不计考核学生考号";
            this.chbUpdateID.UseVisualStyleBackColor = true;
            // 
            // FormInitilize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 215);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupBox1);
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
    }
}