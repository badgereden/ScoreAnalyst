namespace ScoreAnalyst
{
    partial class FormReport
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
            this.gbOutputPath = new System.Windows.Forms.GroupBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.gbOption = new System.Windows.Forms.GroupBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.gbOutputPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOutputPath
            // 
            this.gbOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutputPath.Controls.Add(this.btnBrowser);
            this.gbOutputPath.Controls.Add(this.tbFilePath);
            this.gbOutputPath.Location = new System.Drawing.Point(12, 12);
            this.gbOutputPath.Name = "gbOutputPath";
            this.gbOutputPath.Size = new System.Drawing.Size(599, 57);
            this.gbOutputPath.TabIndex = 0;
            this.gbOutputPath.TabStop = false;
            this.gbOutputPath.Text = "输出位置";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(486, 14);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(107, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "浏览(&B)...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(16, 16);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(449, 21);
            this.tbFilePath.TabIndex = 1;
            // 
            // gbOption
            // 
            this.gbOption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOption.Location = new System.Drawing.Point(12, 65);
            this.gbOption.Name = "gbOption";
            this.gbOption.Size = new System.Drawing.Size(599, 148);
            this.gbOption.TabIndex = 1;
            this.gbOption.TabStop = false;
            this.gbOption.Text = "选项";
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancle.Location = new System.Drawing.Point(89, 225);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(101, 23);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Location = new System.Drawing.Point(370, 224);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(107, 24);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "开始(&S)";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 266);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(627, 13);
            this.progressBar.TabIndex = 5;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 279);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.gbOption);
            this.Controls.Add(this.gbOutputPath);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.gbOutputPath.ResumeLayout(false);
            this.gbOutputPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbOutputPath;
        protected System.Windows.Forms.Button btnBrowser;
        protected System.Windows.Forms.TextBox tbFilePath;
        protected System.Windows.Forms.GroupBox gbOption;
        protected System.Windows.Forms.Button btnCancle;
        protected System.Windows.Forms.Button btnEnter;
        protected System.Windows.Forms.ProgressBar progressBar;
    }
}