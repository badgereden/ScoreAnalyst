namespace ScoreAnalyst
{
    partial class FormWelcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbGrade = new System.Windows.Forms.ComboBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbGrade);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(64, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "年级:";
            // 
            // cbGrade
            // 
            this.cbGrade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbGrade.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbGrade.FormattingEnabled = true;
            this.cbGrade.Location = new System.Drawing.Point(141, 49);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(217, 27);
            this.cbGrade.TabIndex = 0;
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(114, 174);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 2;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnEnter.Location = new System.Drawing.Point(295, 174);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "确定(&E)";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // FormSelectGrade
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(462, 209);
            this.ControlBox = false;
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSelectGrade";
            this.Text = "选择年级";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSelectGrade_FormClosing);
            this.Load += new System.EventHandler(this.FormSelectGrade_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGrade;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnEnter;
    }
}