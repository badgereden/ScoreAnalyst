namespace ScoreAnalyst
{
    partial class FormMain
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackupAndRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackupCurrentScore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRestoreScore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBrowserDataSelecter = new System.Windows.Forms.ToolStripMenuItem();
            this.miTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInitialize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiNewReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGradeStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGradeDifference = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportStudentScore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeacherRank = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTest = new System.Windows.Forms.ToolStripMenuItem();
            this.miOption = new System.Windows.Forms.ToolStripMenuItem();
            this.miConfigManager = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miData,
            this.miTool,
            this.miHelp,
            this.miOption});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(745, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(58, 21);
            this.miFile.Text = "文件(&F)";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(152, 22);
            this.miExit.Text = "退出(&Q)";
            this.miExit.Click += new System.EventHandler(this.MiExitClick);
            // 
            // miData
            // 
            this.miData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBackupAndRestore,
            this.tsmiBrowserDataSelecter,
            this.tsmiClearData});
            this.miData.Name = "miData";
            this.miData.Size = new System.Drawing.Size(61, 21);
            this.miData.Text = "数据(&D)";
            // 
            // tsmiBackupAndRestore
            // 
            this.tsmiBackupAndRestore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBackupCurrentScore,
            this.tsmiRestoreScore});
            this.tsmiBackupAndRestore.Name = "tsmiBackupAndRestore";
            this.tsmiBackupAndRestore.Size = new System.Drawing.Size(152, 22);
            this.tsmiBackupAndRestore.Text = "备份与恢复(&B)";
            // 
            // tsmiBackupCurrentScore
            // 
            this.tsmiBackupCurrentScore.Name = "tsmiBackupCurrentScore";
            this.tsmiBackupCurrentScore.Size = new System.Drawing.Size(188, 22);
            this.tsmiBackupCurrentScore.Text = "备份当前成绩(&B)";
            this.tsmiBackupCurrentScore.Click += new System.EventHandler(this.tsmiBackupCurrentScore_Click);
            // 
            // tsmiRestoreScore
            // 
            this.tsmiRestoreScore.Name = "tsmiRestoreScore";
            this.tsmiRestoreScore.Size = new System.Drawing.Size(188, 22);
            this.tsmiRestoreScore.Text = "还原成绩至当前库(&R)";
            this.tsmiRestoreScore.Click += new System.EventHandler(this.tsmiRestoreScore_Click);
            // 
            // tsmiClearData
            // 
            this.tsmiClearData.Name = "tsmiClearData";
            this.tsmiClearData.Size = new System.Drawing.Size(152, 22);
            this.tsmiClearData.Text = "清空数据";
            this.tsmiClearData.Click += new System.EventHandler(this.tsmiClearData_Click);
            // 
            // tsmiBrowserDataSelecter
            // 
            this.tsmiBrowserDataSelecter.Name = "tsmiBrowserDataSelecter";
            this.tsmiBrowserDataSelecter.Size = new System.Drawing.Size(152, 22);
            this.tsmiBrowserDataSelecter.Text = "查看数据";
            this.tsmiBrowserDataSelecter.Click += new System.EventHandler(this.tsmiBrowserDataSelecter_Click);
            // 
            // miTool
            // 
            this.miTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInitialize,
            this.toolStripMenuItem2,
            this.tsmiNewReport,
            this.tsmiGradeStatistics,
            this.tsmiSection,
            this.tsmiGradeDifference,
            this.tsmiExportStudentScore,
            this.tsmiTeacherRank});
            this.miTool.Name = "miTool";
            this.miTool.Size = new System.Drawing.Size(59, 21);
            this.miTool.Text = "报表(&T)";
            // 
            // tsmiInitialize
            // 
            this.tsmiInitialize.Name = "tsmiInitialize";
            this.tsmiInitialize.Size = new System.Drawing.Size(220, 22);
            this.tsmiInitialize.Text = "手动初始化";
            this.tsmiInitialize.Click += new System.EventHandler(this.tsmiInitialize_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            // 
            // tsmiNewReport
            // 
            this.tsmiNewReport.Name = "tsmiNewReport";
            this.tsmiNewReport.Size = new System.Drawing.Size(220, 22);
            this.tsmiNewReport.Text = "学科分段统计(U)...";
            this.tsmiNewReport.Click += new System.EventHandler(this.tsmiNewReport_Click);
            // 
            // tsmiGradeStatistics
            // 
            this.tsmiGradeStatistics.Name = "tsmiGradeStatistics";
            this.tsmiGradeStatistics.Size = new System.Drawing.Size(220, 22);
            this.tsmiGradeStatistics.Text = "年级分段累计(&G)...";
            this.tsmiGradeStatistics.Click += new System.EventHandler(this.tsmiGradeStatistics_Click);
            // 
            // tsmiSection
            // 
            this.tsmiSection.Name = "tsmiSection";
            this.tsmiSection.Size = new System.Drawing.Size(220, 22);
            this.tsmiSection.Text = "竞赛班名次段人数统计(&S)...";
            this.tsmiSection.Click += new System.EventHandler(this.tsmiSection_Click);
            // 
            // tsmiGradeDifference
            // 
            this.tsmiGradeDifference.Name = "tsmiGradeDifference";
            this.tsmiGradeDifference.Size = new System.Drawing.Size(220, 22);
            this.tsmiGradeDifference.Text = "所有班级超差分析(&D)...";
            this.tsmiGradeDifference.Click += new System.EventHandler(this.tsmiGradeDifference_Click);
            // 
            // tsmiExportStudentScore
            // 
            this.tsmiExportStudentScore.Name = "tsmiExportStudentScore";
            this.tsmiExportStudentScore.Size = new System.Drawing.Size(220, 22);
            this.tsmiExportStudentScore.Text = "全年级学生成绩(&O)";
            this.tsmiExportStudentScore.Click += new System.EventHandler(this.tsmiExportStudentScore_Click);
            // 
            // tsmiTeacherRank
            // 
            this.tsmiTeacherRank.Name = "tsmiTeacherRank";
            this.tsmiTeacherRank.Size = new System.Drawing.Size(220, 22);
            this.tsmiTeacherRank.Text = "教师超差排序(&R)";
            this.tsmiTeacherRank.Click += new System.EventHandler(this.tsmiTeacherRank_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout,
            this.tsmiTest});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(61, 21);
            this.miHelp.Text = "帮助(&H)";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(125, 22);
            this.tsmiAbout.Text = "关于(&A)...";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // tsmiTest
            // 
            this.tsmiTest.Name = "tsmiTest";
            this.tsmiTest.Size = new System.Drawing.Size(125, 22);
            this.tsmiTest.Text = "测试(&T)";
            this.tsmiTest.Click += new System.EventHandler(this.tsmiTest_Click);
            // 
            // miOption
            // 
            this.miOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConfigManager});
            this.miOption.Name = "miOption";
            this.miOption.Size = new System.Drawing.Size(59, 21);
            this.miOption.Text = "选项(&P)";
            // 
            // miConfigManager
            // 
            this.miConfigManager.Name = "miConfigManager";
            this.miConfigManager.Size = new System.Drawing.Size(148, 22);
            this.miConfigManager.Text = "配置文件管理";
            this.miConfigManager.Click += new System.EventHandler(this.miConfigManager_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 425);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miData;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miTool;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiGradeStatistics;
        private System.Windows.Forms.ToolStripMenuItem tsmiSection;
        private System.Windows.Forms.ToolStripMenuItem tsmiGradeDifference;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportStudentScore;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackupAndRestore;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackupCurrentScore;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestoreScore;
        private System.Windows.Forms.ToolStripMenuItem tsmiTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeacherRank;
        private System.Windows.Forms.ToolStripMenuItem miOption;
        private System.Windows.Forms.ToolStripMenuItem miConfigManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearData;
        private System.Windows.Forms.ToolStripMenuItem tsmiBrowserDataSelecter;
        private System.Windows.Forms.ToolStripMenuItem tsmiInitialize;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}