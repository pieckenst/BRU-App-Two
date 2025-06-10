namespace Burdukov_kurs
{
    partial class MainForm
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
            this.dgvCalls = new System.Windows.Forms.DataGridView();
            this.lblPeriodStart = new System.Windows.Forms.Label();
            this.dtpPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodEnd = new System.Windows.Forms.Label();
            this.dtpPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTariffsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalls)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCalls
            // 
            this.dgvCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalls.Location = new System.Drawing.Point(15, 27);
            this.dgvCalls.Name = "dgvCalls";
            this.dgvCalls.Size = new System.Drawing.Size(843, 304);
            this.dgvCalls.TabIndex = 0;
            // 
            // lblPeriodStart
            // 
            this.lblPeriodStart.AutoSize = true;
            this.lblPeriodStart.Location = new System.Drawing.Point(12, 352);
            this.lblPeriodStart.Name = "lblPeriodStart";
            this.lblPeriodStart.Size = new System.Drawing.Size(57, 13);
            this.lblPeriodStart.TabIndex = 1;
            this.lblPeriodStart.Text = "Период с:";
            // 
            // dtpPeriodStart
            // 
            this.dtpPeriodStart.Location = new System.Drawing.Point(80, 348);
            this.dtpPeriodStart.Name = "dtpPeriodStart";
            this.dtpPeriodStart.Size = new System.Drawing.Size(140, 20);
            this.dtpPeriodStart.TabIndex = 2;
            // 
            // lblPeriodEnd
            // 
            this.lblPeriodEnd.AutoSize = true;
            this.lblPeriodEnd.Location = new System.Drawing.Point(230, 352);
            this.lblPeriodEnd.Name = "lblPeriodEnd";
            this.lblPeriodEnd.Size = new System.Drawing.Size(22, 13);
            this.lblPeriodEnd.TabIndex = 3;
            this.lblPeriodEnd.Text = "по:";
            // 
            // dtpPeriodEnd
            // 
            this.dtpPeriodEnd.Location = new System.Drawing.Point(260, 348);
            this.dtpPeriodEnd.Name = "dtpPeriodEnd";
            this.dtpPeriodEnd.Size = new System.Drawing.Size(140, 20);
            this.dtpPeriodEnd.TabIndex = 4;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 387);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(120, 23);
            this.btnLoadData.TabIndex = 5;
            this.btnLoadData.Text = "Загрузить данные";
            this.btnLoadData.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(140, 387);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(150, 23);
            this.btnGenerateReport.TabIndex = 6;
            this.btnGenerateReport.Text = "Сформировать отчет";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 427);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 424);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 20);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(300, 422);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(12, 462);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(70, 13);
            this.lblSort.TabIndex = 10;
            this.lblSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(85, 459);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(205, 21);
            this.cmbSort.TabIndex = 11;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(300, 457);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 12;
            this.btnSort.Text = "Сортировать";
            this.btnSort.UseVisualStyleBackColor = true;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(870, 24);
            this.menuStripMain.TabIndex = 13;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFileToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.deleteFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // createFileToolStripMenuItem
            // 
            this.createFileToolStripMenuItem.Name = "createFileToolStripMenuItem";
            this.createFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.createFileToolStripMenuItem.Text = "Создать файл";
            this.createFileToolStripMenuItem.Click += new System.EventHandler(this.createFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.openFileToolStripMenuItem.Text = "Открыть файл";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteFileToolStripMenuItem.Text = "Удалить файл";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagementToolStripMenuItem,
            this.manageTariffsToolStripMenuItem,
            this.manageServicesToolStripMenuItem,
            this.manageCallsToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.adminToolStripMenuItem.Text = "Администрирование";
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.userManagementToolStripMenuItem.Text = "Управление пользователями";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // manageTariffsToolStripMenuItem
            // 
            this.manageTariffsToolStripMenuItem.Name = "manageTariffsToolStripMenuItem";
            this.manageTariffsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.manageTariffsToolStripMenuItem.Text = "Управление тарифами";
            this.manageTariffsToolStripMenuItem.Click += new System.EventHandler(this.manageTariffsToolStripMenuItem_Click);
            // 
            // manageServicesToolStripMenuItem
            // 
            this.manageServicesToolStripMenuItem.Name = "manageServicesToolStripMenuItem";
            this.manageServicesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.manageServicesToolStripMenuItem.Text = "Управление услугами";
            this.manageServicesToolStripMenuItem.Click += new System.EventHandler(this.manageServicesToolStripMenuItem_Click);
            // 
            // manageCallsToolStripMenuItem
            // 
            this.manageCallsToolStripMenuItem.Name = "manageCallsToolStripMenuItem";
            this.manageCallsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.manageCallsToolStripMenuItem.Text = "Управление вызовами";
            this.manageCallsToolStripMenuItem.Click += new System.EventHandler(this.manageCallsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 492);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dtpPeriodEnd);
            this.Controls.Add(this.lblPeriodEnd);
            this.Controls.Add(this.dtpPeriodStart);
            this.Controls.Add(this.lblPeriodStart);
            this.Controls.Add(this.dgvCalls);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет переговоров абонентов";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalls)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalls;
        private System.Windows.Forms.Label lblPeriodStart;
        private System.Windows.Forms.DateTimePicker dtpPeriodStart;
        private System.Windows.Forms.Label lblPeriodEnd;
        private System.Windows.Forms.DateTimePicker dtpPeriodEnd;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTariffsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCallsToolStripMenuItem;
    }
}

            

