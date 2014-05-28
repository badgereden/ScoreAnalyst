/*
 * 由SharpDevelop创建。
 * 用户： 刘保恩
 * 日期: 2011/11/25
 * 时间: 11:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace ScoreAnalyst
{
	partial class FormImport
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbWorking = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrower = new System.Windows.Forms.Button();
            this.tbTablePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTableType = new System.Windows.Forms.ComboBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbWorking);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBrower);
            this.groupBox1.Controls.Add(this.tbTablePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbTableType);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pbWorking
            // 
            this.pbWorking.Location = new System.Drawing.Point(115, 98);
            this.pbWorking.Name = "pbWorking";
            this.pbWorking.Size = new System.Drawing.Size(246, 23);
            this.pbWorking.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(37, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "完成进度";
            // 
            // btnBrower
            // 
            this.btnBrower.Location = new System.Drawing.Point(280, 60);
            this.btnBrower.Name = "btnBrower";
            this.btnBrower.Size = new System.Drawing.Size(81, 23);
            this.btnBrower.TabIndex = 4;
            this.btnBrower.Text = "浏览(&B)...";
            this.btnBrower.UseVisualStyleBackColor = true;
            this.btnBrower.Click += new System.EventHandler(this.BtnBrowerClick);
            // 
            // tbTablePath
            // 
            this.tbTablePath.Location = new System.Drawing.Point(115, 62);
            this.tbTablePath.Name = "tbTablePath";
            this.tbTablePath.ReadOnly = true;
            this.tbTablePath.Size = new System.Drawing.Size(139, 21);
            this.tbTablePath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(37, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Excel 文件";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据表类型";
            // 
            // cbTableType
            // 
            this.cbTableType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTableType.FormattingEnabled = true;
            this.cbTableType.Location = new System.Drawing.Point(115, 21);
            this.cbTableType.Name = "cbTableType";
            this.cbTableType.Size = new System.Drawing.Size(246, 20);
            this.cbTableType.TabIndex = 0;
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(71, 169);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(273, 169);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "确定(&E)";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnterClick);
            // 
            // FormImport
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(425, 214);
            this.ControlBox = false;
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormImport";
            this.Text = "数据导入向导...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.Button btnCancle;
		private System.Windows.Forms.ProgressBar pbWorking;
		private System.Windows.Forms.Button btnBrower;
		private System.Windows.Forms.TextBox tbTablePath;
		private System.Windows.Forms.Button btnEnter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbTableType;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
