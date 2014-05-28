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
            this.miBrowserData = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrowserScore = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrowserTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrowserClass = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrowserIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miClearData = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearScore = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearClassInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackupAndRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackupCurrentScore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRestoreScore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBrowserDataSelecter = new System.Windows.Forms.ToolStripMenuItem();
            this.miTool = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiInitialize = new System.Windows.Forms.ToolStripMenuItem();
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
            this.miExit.Size = new System.Drawing.Size(118, 22);
            this.miExit.Text = "退出(&Q)";
            this.miExit.Click += new System.EventHandler(this.MiExitClick);
            // 
            // miData
            // 
            this.miData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBrowserData,
            this.miImportData,
            this.toolStripMenuItem1,
            this.miClearData,
            this.tsmiBackupAndRestore,
            this.tsmiClearData,
            this.tsmiBrowserDataSelecter});
            this.miData.Name = "miData";
            this.miData.Size = new System.Drawing.Size(61, 21);
            this.miData.Text = "数据(&D)";
            // 
            // miBrowserData
            // 
            this.miBrowserData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBrowserScore,
            this.miBrowserTeachers,
            this.miBrowserClass,
            this.miBrowserIgnore});
            this.miBrowserData.Name = "miBrowserData";
            this.miBrowserData.Size = new System.Drawing.Size(152, 22);
            this.miBrowserData.Text = "查看数据(&S)";
            // 
            // miBrowserScore
            // 
            this.miBrowserScore.Name = "miBrowserScore";
            this.miBrowserScore.Size = new System.Drawing.Size(200, 22);
            this.miBrowserScore.Text = "学生成绩(&S)";
            this.miBrowserScore.Click += new System.EventHandler(this.miBrowserScore_Click);
            // 
            // miBrowserTeachers
            // 
            this.miBrowserTeachers.Name = "miBrowserTeachers";
            this.miBrowserTeachers.Size = new System.Drawing.Size(200, 22);
            this.miBrowserTeachers.Text = "任课教师(&T)";
            this.miBrowserTeachers.Click += new System.EventHandler(this.miBrowserTeachers_Click);
            // 
            // miBrowserClass
            // 
            this.miBrowserClass.Name = "miBrowserClass";
            this.miBrowserClass.Size = new System.Drawing.Size(200, 22);
            this.miBrowserClass.Text = "班级信息及考核目标(&C)";
            this.miBrowserClass.Click += new System.EventHandler(this.miBrowserClass_Click);
            // 
            // miBrowserIgnore
            // 
            this.miBrowserIgnore.Name = "miBrowserIgnore";
            this.miBrowserIgnore.Size = new System.Drawing.Size(200, 22);
            this.miBrowserIgnore.Text = "不计考核学生名单(&I)";
            this.miBrowserIgnore.Click += new System.EventHandler(this.miBrowserIgnore_Click);
            // 
            // miImportData
            // 
            this.miImportData.Name = "miImportData";
            this.miImportData.Size = new System.Drawing.Size(152, 22);
            this.miImportData.Text = "导入数据(&I)...";
            this.miImportData.Click += new System.EventHandler(this.miImportData_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // miClearData
            // 
            this.miClearData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClearScore,
            this.miClearTeachers,
            this.miClearClassInfo,
            this.miClearIgnore});
            this.miClearData.Name = "miClearData";
            this.miClearData.Size = new System.Drawing.Size(152, 22);
            this.miClearData.Text = "清空数据(&D)";
            // 
            // miClearScore
            // 
            this.miClearScore.Name = "miClearScore";
            this.miClearScore.Size = new System.Drawing.Size(200, 22);
            this.miClearScore.Text = "学生成绩(&S)";
            this.miClearScore.Click += new System.EventHandler(this.miClearScore_Click);
            // 
            // miClearTeachers
            // 
            this.miClearTeachers.Name = "miClearTeachers";
            this.miClearTeachers.Size = new System.Drawing.Size(200, 22);
            this.miClearTeachers.Text = "任课教师(&T)";
            this.miClearTeachers.Click += new System.EventHandler(this.miClearTeachers_Click);
            // 
            // miClearClassInfo
            // 
            this.miClearClassInfo.Name = "miClearClassInfo";
            this.miClearClassInfo.Size = new System.Drawing.Size(200, 22);
            this.miClearClassInfo.Text = "班级信息及考核目标(&C)";
            this.miClearClassInfo.Click += new System.EventHandler(this.miClearClassInfo_Click);
            // 
            // miClearIgnore
            // 
            this.miClearIgnore.Name = "miClearIgnore";
            this.miClearIgnore.Size = new System.Drawing.Size(200, 22);
            this.miClearIgnore.Text = "不计考核学生名单(&I)";
            this.miClearIgnore.Click += new System.EventHandler(this.miClearIgnore_Click);
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
            this.tsmiClearData.Text = "清空";
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            // 
            // tsmiInitialize
            // 
            this.tsmiInitialize.Name = "tsmiInitialize";
            this.tsmiInitialize.Size = new System.Drawing.Size(220, 22);
            this.tsmiInitialize.Text = "手动初始化";
            this.tsmiInitialize.Click += new System.EventHandler(this.tsmiInitialize_Click);
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
        private System.Windows.Forms.ToolStripMenuItem miBrowserData;
        private System.Windows.Forms.ToolStripMenuItem miImportData;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miBrowserScore;
        private System.Windows.Forms.ToolStripMenuItem miBrowserTeachers;
        private System.Windows.Forms.ToolStripMenuItem miBrowserClass;
        private System.Windows.Forms.ToolStripMenuItem miTool;
        private System.Windows.Forms.ToolStripMenuItem miBrowserIgnore;
        private System.Windows.Forms.ToolStripMenuItem miClearData;
        private System.Windows.Forms.ToolStripMenuItem miClearScore;
        private System.Windows.Forms.ToolStripMenuItem miClearTeachers;
        private System.Windows.Forms.ToolStripMenuItem miClearClassInfo;
        private System.Windows.Forms.ToolStripMenuItem miClearIgnore;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
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