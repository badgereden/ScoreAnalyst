namespace ScoreAnalyst
{
    partial class FormNewReport
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbTask = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.ckbMerge = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(-1, 230);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(616, 10);
            this.progressBar1.TabIndex = 1;
            // 
            // lbTask
            // 
            this.lbTask.AutoSize = true;
            this.lbTask.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTask.Location = new System.Drawing.Point(12, 205);
            this.lbTask.Name = "lbTask";
            this.lbTask.Size = new System.Drawing.Size(127, 16);
            this.lbTask.TabIndex = 2;
            this.lbTask.Text = "正在进行的任务";
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(176, 117);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(357, 117);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "开始(&S)";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // ckbMerge
            // 
            this.ckbMerge.AutoSize = true;
            this.ckbMerge.Location = new System.Drawing.Point(27, 57);
            this.ckbMerge.Name = "ckbMerge";
            this.ckbMerge.Size = new System.Drawing.Size(96, 16);
            this.ckbMerge.TabIndex = 5;
            this.ckbMerge.Text = "文理合并输出";
            this.ckbMerge.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "输出位置:";
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(93, 12);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.ReadOnly = true;
            this.tbFolder.Size = new System.Drawing.Size(369, 21);
            this.tbFolder.TabIndex = 7;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(485, 12);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(91, 23);
            this.btnBrowser.TabIndex = 8;
            this.btnBrowser.Text = "浏览(&B)...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFolder);
            this.groupBox1.Controls.Add(this.btnBrowser);
            this.groupBox1.Controls.Add(this.ckbMerge);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 90);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // FormNewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(614, 241);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lbTask);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancle);
            this.Name = "FormNewReport";
            this.Text = "报表向导";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbTask;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.CheckBox ckbMerge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}