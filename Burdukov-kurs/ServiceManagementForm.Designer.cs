namespace Burdukov_kurs
{
    partial class ServiceManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lblServicePrice = new System.Windows.Forms.Label();
            this.numServicePrice = new System.Windows.Forms.NumericUpDown();
            this.lblServiceDescription = new System.Windows.Forms.Label();
            this.txtServiceDescription = new System.Windows.Forms.TextBox();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnEditService = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServicePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(12, 12);
            this.dgvServices.MultiSelect = false;
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(460, 150);
            this.dgvServices.TabIndex = 0;
            this.dgvServices.SelectionChanged += new System.EventHandler(this.dgvServices_SelectionChanged);
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(12, 175);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(96, 13);
            this.lblServiceName.TabIndex = 1;
            this.lblServiceName.Text = "Название услуги:";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(115, 172);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(230, 20);
            this.txtServiceName.TabIndex = 2;
            // 
            // lblServicePrice
            // 
            this.lblServicePrice.AutoSize = true;
            this.lblServicePrice.Location = new System.Drawing.Point(12, 201);
            this.lblServicePrice.Name = "lblServicePrice";
            this.lblServicePrice.Size = new System.Drawing.Size(65, 13);
            this.lblServicePrice.TabIndex = 3;
            this.lblServicePrice.Text = "Стоимость:";
            // 
            // numServicePrice
            // 
            this.numServicePrice.DecimalPlaces = 2;
            this.numServicePrice.Location = new System.Drawing.Point(115, 199);
            this.numServicePrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numServicePrice.Name = "numServicePrice";
            this.numServicePrice.Size = new System.Drawing.Size(120, 20);
            this.numServicePrice.TabIndex = 4;
            // 
            // lblServiceDescription
            // 
            this.lblServiceDescription.AutoSize = true;
            this.lblServiceDescription.Location = new System.Drawing.Point(12, 227);
            this.lblServiceDescription.Name = "lblServiceDescription";
            this.lblServiceDescription.Size = new System.Drawing.Size(60, 13);
            this.lblServiceDescription.TabIndex = 5;
            this.lblServiceDescription.Text = "Описание:";
            // 
            // txtServiceDescription
            // 
            this.txtServiceDescription.Location = new System.Drawing.Point(115, 224);
            this.txtServiceDescription.Multiline = true;
            this.txtServiceDescription.Name = "txtServiceDescription";
            this.txtServiceDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServiceDescription.Size = new System.Drawing.Size(230, 60);
            this.txtServiceDescription.TabIndex = 6;
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(351, 170);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(110, 23);
            this.btnAddService.TabIndex = 7;
            this.btnAddService.Text = "Добавить";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnEditService
            // 
            this.btnEditService.Enabled = false;
            this.btnEditService.Location = new System.Drawing.Point(351, 199);
            this.btnEditService.Name = "btnEditService";
            this.btnEditService.Size = new System.Drawing.Size(110, 23);
            this.btnEditService.TabIndex = 8;
            this.btnEditService.Text = "Редактировать";
            this.btnEditService.UseVisualStyleBackColor = true;
            this.btnEditService.Click += new System.EventHandler(this.btnEditService_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(351, 228);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(110, 23);
            this.btnSaveChanges.TabIndex = 9;
            this.btnSaveChanges.Text = "Сохранить";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Enabled = false;
            this.btnDeleteService.Location = new System.Drawing.Point(351, 257);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(110, 23);
            this.btnDeleteService.TabIndex = 10;
            this.btnDeleteService.Text = "Удалить";
            this.btnDeleteService.UseVisualStyleBackColor = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(351, 286);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(110, 23);
            this.btnClearFields.TabIndex = 11;
            this.btnClearFields.Text = "Очистить поля";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // ServiceManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 341);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnDeleteService);
            this.Controls.Add(this.btnEditService);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.txtServiceDescription);
            this.Controls.Add(this.lblServiceDescription);
            this.Controls.Add(this.numServicePrice);
            this.Controls.Add(this.lblServicePrice);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.lblServiceName);
            this.Controls.Add(this.dgvServices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление услугами оператора";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numServicePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lblServicePrice;
        private System.Windows.Forms.NumericUpDown numServicePrice;
        private System.Windows.Forms.Label lblServiceDescription;
        private System.Windows.Forms.TextBox txtServiceDescription;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnEditService;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.Button btnClearFields;
        // private System.Windows.Forms.Label lblTariff; // Optional
        // private System.Windows.Forms.ComboBox cmbTariffs; // Optional
    }
}