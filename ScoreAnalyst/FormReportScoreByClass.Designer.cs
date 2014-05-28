namespace ScoreAnalyst
{
    partial class FormReportScoreByClass
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
            this.btnCancle = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkIndivision = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输出文件位置";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(134, 22);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(213, 21);
            this.tbFileName.TabIndex = 1;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(368, 20);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(95, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "浏览(&B)...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(317, 82);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(125, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始(&S)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(174, 82);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(81, 23);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-1, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(492, 10);
            this.progressBar1.TabIndex = 5;
            // 
            // chkIndivision
            // 
            this.chkIndivision.AutoSize = true;
            this.chkIndivision.Checked = true;
            this.chkIndivision.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndivision.Location = new System.Drawing.Point(38, 86);
            this.chkIndivision.Name = "chkIndivision";
            this.chkIndivision.Size = new System.Drawing.Size(60, 16);
            this.chkIndivision.TabIndex = 6;
            this.chkIndivision.Text = "分班级";
            this.chkIndivision.UseVisualStyleBackColor = true;
            // 
            // FormReportScoreByClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(490, 130);
            this.Controls.Add(this.chkIndivision);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReportScoreByClass";
            this.Text = "FormReportScoreByClass";
            //this.Load += new System.EventHandler(this.FormReportScoreByClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkIndivision;
    }
}