namespace Burdukov_kurs
{
    partial class CallManagementForm
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
            this.lblSubscriberName = new System.Windows.Forms.Label();
            this.txtSubscriberName = new System.Windows.Forms.TextBox();
            this.lblSubscriberNumber = new System.Windows.Forms.Label();
            this.txtSubscriberNumber = new System.Windows.Forms.TextBox();
            this.lblCorrespondentNumber = new System.Windows.Forms.Label();
            this.txtCorrespondentNumber = new System.Windows.Forms.TextBox();
            this.lblCallType = new System.Windows.Forms.Label();
            this.cmbCallType = new System.Windows.Forms.ComboBox();
            this.lblCallTime = new System.Windows.Forms.Label();
            this.dtpCallTime = new System.Windows.Forms.DateTimePicker();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblCost = new System.Windows.Forms.Label();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.lblTariff = new System.Windows.Forms.Label();
            this.cmbTariff = new System.Windows.Forms.ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.btnAddCall = new System.Windows.Forms.Button();
            this.btnEditCall = new System.Windows.Forms.Button();
            this.btnDeleteCall = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.grpCallDetails = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            this.grpCallDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCalls
            // 
            this.dgvCalls.AllowUserToAddRows = false;
            this.dgvCalls.AllowUserToDeleteRows = false;
            this.dgvCalls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalls.Location = new System.Drawing.Point(12, 270);
            this.dgvCalls.MultiSelect = false;
            this.dgvCalls.Name = "dgvCalls";
            this.dgvCalls.ReadOnly = true;
            this.dgvCalls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalls.Size = new System.Drawing.Size(776, 230);
            this.dgvCalls.TabIndex = 10;
            this.dgvCalls.SelectionChanged += new System.EventHandler(this.dgvCalls_SelectionChanged);
            // 
            // lblSubscriberName
            // 
            this.lblSubscriberName.AutoSize = true;
            this.lblSubscriberName.Location = new System.Drawing.Point(6, 22);
            this.lblSubscriberName.Name = "lblSubscriberName";
            this.lblSubscriberName.Size = new System.Drawing.Size(85, 13);
            this.lblSubscriberName.TabIndex = 0;
            this.lblSubscriberName.Text = "Имя абонента:";
            // 
            // txtSubscriberName
            // 
            this.txtSubscriberName.Location = new System.Drawing.Point(130, 19);
            this.txtSubscriberName.Name = "txtSubscriberName";
            this.txtSubscriberName.Size = new System.Drawing.Size(200, 20);
            this.txtSubscriberName.TabIndex = 0;
            // 
            // lblSubscriberNumber
            // 
            this.lblSubscriberNumber.AutoSize = true;
            this.lblSubscriberNumber.Location = new System.Drawing.Point(6, 48);
            this.lblSubscriberNumber.Name = "lblSubscriberNumber";
            this.lblSubscriberNumber.Size = new System.Drawing.Size(96, 13);
            this.lblSubscriberNumber.TabIndex = 2;
            this.lblSubscriberNumber.Text = "Номер абонента:";
            // 
            // txtSubscriberNumber
            // 
            this.txtSubscriberNumber.Location = new System.Drawing.Point(130, 45);
            this.txtSubscriberNumber.Name = "txtSubscriberNumber";
            this.txtSubscriberNumber.Size = new System.Drawing.Size(200, 20);
            this.txtSubscriberNumber.TabIndex = 1;
            // 
            // lblCorrespondentNumber
            // 
            this.lblCorrespondentNumber.AutoSize = true;
            this.lblCorrespondentNumber.Location = new System.Drawing.Point(6, 74);
            this.lblCorrespondentNumber.Name = "lblCorrespondentNumber";
            this.lblCorrespondentNumber.Size = new System.Drawing.Size(121, 13);
            this.lblCorrespondentNumber.TabIndex = 4;
            this.lblCorrespondentNumber.Text = "Номер собеседника:";
            // 
            // txtCorrespondentNumber
            // 
            this.txtCorrespondentNumber.Location = new System.Drawing.Point(130, 71);
            this.txtCorrespondentNumber.Name = "txtCorrespondentNumber";
            this.txtCorrespondentNumber.Size = new System.Drawing.Size(200, 20);
            this.txtCorrespondentNumber.TabIndex = 2;
            // 
            // lblCallType
            // 
            this.lblCallType.AutoSize = true;
            this.lblCallType.Location = new System.Drawing.Point(6, 100);
            this.lblCallType.Name = "lblCallType";
            this.lblCallType.Size = new System.Drawing.Size(73, 13);
            this.lblCallType.TabIndex = 6;
            this.lblCallType.Text = "Тип звонка:";
            // 
            // cmbCallType
            // 
            this.cmbCallType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallType.FormattingEnabled = true;
            this.cmbCallType.Location = new System.Drawing.Point(130, 97);
            this.cmbCallType.Name = "cmbCallType";
            this.cmbCallType.Size = new System.Drawing.Size(200, 21);
            this.cmbCallType.TabIndex = 3;
            // 
            // lblCallTime
            // 
            this.lblCallTime.AutoSize = true;
            this.lblCallTime.Location = new System.Drawing.Point(350, 22);
            this.lblCallTime.Name = "lblCallTime";
            this.lblCallTime.Size = new System.Drawing.Size(87, 13);
            this.lblCallTime.TabIndex = 8;
            this.lblCallTime.Text = "Время звонка:";
            // 
            // dtpCallTime
            // 
            this.dtpCallTime.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpCallTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCallTime.Location = new System.Drawing.Point(450, 19);
            this.dtpCallTime.Name = "dtpCallTime";
            this.dtpCallTime.Size = new System.Drawing.Size(200, 20);
            this.dtpCallTime.TabIndex = 4;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(350, 48);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(83, 13);
            this.lblDuration.TabIndex = 10;
            this.lblDuration.Text = "Длительность:";
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(450, 46);
            this.numDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(200, 20);
            this.numDuration.TabIndex = 5;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(350, 74);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(65, 13);
            this.lblCost.TabIndex = 12;
            this.lblCost.Text = "Стоимость:";
            // 
            // numCost
            // 
            this.numCost.DecimalPlaces = 2;
            this.numCost.Location = new System.Drawing.Point(450, 72);
            this.numCost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCost.Name = "numCost";
            this.numCost.Size = new System.Drawing.Size(200, 20);
            this.numCost.TabIndex = 6;
            // 
            // lblTariff
            // 
            this.lblTariff.AutoSize = true;
            this.lblTariff.Location = new System.Drawing.Point(350, 100);
            this.lblTariff.Name = "lblTariff";
            this.lblTariff.Size = new System.Drawing.Size(43, 13);
            this.lblTariff.TabIndex = 14;
            this.lblTariff.Text = "Тариф:";
            // 
            // cmbTariff
            // 
            this.cmbTariff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTariff.FormattingEnabled = true;
            this.cmbTariff.Location = new System.Drawing.Point(450, 97);
            this.cmbTariff.Name = "cmbTariff";
            this.cmbTariff.Size = new System.Drawing.Size(200, 21);
            this.cmbTariff.TabIndex = 7;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(350, 127);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(47, 13);
            this.lblService.TabIndex = 16;
            this.lblService.Text = "Услуга:";
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(450, 124);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(200, 21);
            this.cmbService.TabIndex = 8;
            // 
            // btnAddCall
            // 
            this.btnAddCall.Location = new System.Drawing.Point(15, 160);
            this.btnAddCall.Name = "btnAddCall";
            this.btnAddCall.Size = new System.Drawing.Size(100, 23);
            this.btnAddCall.TabIndex = 9;
            this.btnAddCall.Text = "Добавить";
            this.btnAddCall.UseVisualStyleBackColor = true;
            this.btnAddCall.Click += new System.EventHandler(this.btnAddCall_Click);
            // 
            // btnEditCall
            // 
            this.btnEditCall.Enabled = false;
            this.btnEditCall.Location = new System.Drawing.Point(121, 160);
            this.btnEditCall.Name = "btnEditCall";
            this.btnEditCall.Size = new System.Drawing.Size(100, 23);
            this.btnEditCall.TabIndex = 11;
            this.btnEditCall.Text = "Редактировать";
            this.btnEditCall.UseVisualStyleBackColor = true;
            this.btnEditCall.Click += new System.EventHandler(this.btnEditCall_Click);
            // 
            // btnDeleteCall
            // 
            this.btnDeleteCall.Enabled = false;
            this.btnDeleteCall.Location = new System.Drawing.Point(227, 160);
            this.btnDeleteCall.Name = "btnDeleteCall";
            this.btnDeleteCall.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteCall.TabIndex = 12;
            this.btnDeleteCall.Text = "Удалить";
            this.btnDeleteCall.UseVisualStyleBackColor = true;
            this.btnDeleteCall.Click += new System.EventHandler(this.btnDeleteCall_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(333, 160);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(100, 23);
            this.btnClearFields.TabIndex = 13;
            this.btnClearFields.Text = "Очистить";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // grpCallDetails
            // 
            this.grpCallDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCallDetails.Controls.Add(this.lblSubscriberName);
            this.grpCallDetails.Controls.Add(this.btnClearFields);
            this.grpCallDetails.Controls.Add(this.txtSubscriberName);
            this.grpCallDetails.Controls.Add(this.btnDeleteCall);
            this.grpCallDetails.Controls.Add(this.lblSubscriberNumber);
            this.grpCallDetails.Controls.Add(this.btnEditCall);
            this.grpCallDetails.Controls.Add(this.txtSubscriberNumber);
            this.grpCallDetails.Controls.Add(this.btnAddCall);
            this.grpCallDetails.Controls.Add(this.lblCorrespondentNumber);
            this.grpCallDetails.Controls.Add(this.cmbService);
            this.grpCallDetails.Controls.Add(this.txtCorrespondentNumber);
            this.grpCallDetails.Controls.Add(this.lblService);
            this.grpCallDetails.Controls.Add(this.lblCallType);
            this.grpCallDetails.Controls.Add(this.cmbTariff);
            this.grpCallDetails.Controls.Add(this.cmbCallType);
            this.grpCallDetails.Controls.Add(this.lblTariff);
            this.grpCallDetails.Controls.Add(this.lblCallTime);
            this.grpCallDetails.Controls.Add(this.numCost);
            this.grpCallDetails.Controls.Add(this.dtpCallTime);
            this.grpCallDetails.Controls.Add(this.lblCost);
            this.grpCallDetails.Controls.Add(this.lblDuration);
            this.grpCallDetails.Controls.Add(this.numDuration);
            this.grpCallDetails.Location = new System.Drawing.Point(12, 12);
            this.grpCallDetails.Name = "grpCallDetails";
            this.grpCallDetails.Size = new System.Drawing.Size(776, 252);
            this.grpCallDetails.TabIndex = 0;
            this.grpCallDetails.TabStop = false;
            this.grpCallDetails.Text = "Детали звонка";
            // 
            // CallManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.grpCallDetails);
            this.Controls.Add(this.dgvCalls);
            this.Name = "CallManagementForm";
            this.Text = "Управление данными о вызовах";
            this.Load += new System.EventHandler(this.CallManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            this.grpCallDetails.ResumeLayout(false);
            this.grpCallDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalls;
        private System.Windows.Forms.Label lblSubscriberName;
        private System.Windows.Forms.TextBox txtSubscriberName;
        private System.Windows.Forms.Label lblSubscriberNumber;
        private System.Windows.Forms.TextBox txtSubscriberNumber;
        private System.Windows.Forms.Label lblCorrespondentNumber;
        private System.Windows.Forms.TextBox txtCorrespondentNumber;
        private System.Windows.Forms.Label lblCallType;
        private System.Windows.Forms.ComboBox cmbCallType;
        private System.Windows.Forms.Label lblCallTime;
        private System.Windows.Forms.DateTimePicker dtpCallTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Label lblTariff;
        private System.Windows.Forms.ComboBox cmbTariff;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Button btnAddCall;
        private System.Windows.Forms.Button btnEditCall;
        private System.Windows.Forms.Button btnDeleteCall;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.GroupBox grpCallDetails;
    }
}