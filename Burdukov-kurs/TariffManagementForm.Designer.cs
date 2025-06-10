namespace Burdukov_kurs
{
    partial class TariffManagementForm
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
            this.dgvTariffs = new System.Windows.Forms.DataGridView();
            this.lblTariffName = new System.Windows.Forms.Label();
            this.txtTariffName = new System.Windows.Forms.TextBox();
            this.lblPricePerMinute = new System.Windows.Forms.Label();
            this.numPricePerMinute = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAddTariff = new System.Windows.Forms.Button();
            this.btnEditTariff = new System.Windows.Forms.Button();
            this.btnDeleteTariff = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTariffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTariffs
            // 
            this.dgvTariffs.AllowUserToAddRows = false;
            this.dgvTariffs.AllowUserToDeleteRows = false;
            this.dgvTariffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTariffs.Location = new System.Drawing.Point(12, 12);
            this.dgvTariffs.MultiSelect = false;
            this.dgvTariffs.Name = "dgvTariffs";
            this.dgvTariffs.ReadOnly = true;
            this.dgvTariffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTariffs.Size = new System.Drawing.Size(460, 150);
            this.dgvTariffs.TabIndex = 0;
            this.dgvTariffs.SelectionChanged += new System.EventHandler(this.dgvTariffs_SelectionChanged);
            // 
            // lblTariffName
            // 
            this.lblTariffName.AutoSize = true;
            this.lblTariffName.Location = new System.Drawing.Point(12, 175);
            this.lblTariffName.Name = "lblTariffName";
            this.lblTariffName.Size = new System.Drawing.Size(96, 13);
            this.lblTariffName.TabIndex = 1;
            this.lblTariffName.Text = "Название тарифа:";
            // 
            // txtTariffName
            // 
            this.txtTariffName.Location = new System.Drawing.Point(115, 172);
            this.txtTariffName.Name = "txtTariffName";
            this.txtTariffName.Size = new System.Drawing.Size(230, 20);
            this.txtTariffName.TabIndex = 2;
            // 
            // lblPricePerMinute
            // 
            this.lblPricePerMinute.AutoSize = true;
            this.lblPricePerMinute.Location = new System.Drawing.Point(12, 201);
            this.lblPricePerMinute.Name = "lblPricePerMinute";
            this.lblPricePerMinute.Size = new System.Drawing.Size(89, 13);
            this.lblPricePerMinute.TabIndex = 3;
            this.lblPricePerMinute.Text = "Цена за минуту:";
            // 
            // numPricePerMinute
            // 
            this.numPricePerMinute.DecimalPlaces = 2;
            this.numPricePerMinute.Location = new System.Drawing.Point(115, 199);
            this.numPricePerMinute.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPricePerMinute.Name = "numPricePerMinute";
            this.numPricePerMinute.Size = new System.Drawing.Size(120, 20);
            this.numPricePerMinute.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 227);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(115, 224);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(230, 60);
            this.txtDescription.TabIndex = 6;
            // 
            // btnAddTariff
            // 
            this.btnAddTariff.Location = new System.Drawing.Point(362, 170);
            this.btnAddTariff.Name = "btnAddTariff";
            this.btnAddTariff.Size = new System.Drawing.Size(110, 23);
            this.btnAddTariff.TabIndex = 7;
            this.btnAddTariff.Text = "Добавить";
            this.btnAddTariff.UseVisualStyleBackColor = true;
            this.btnAddTariff.Click += new System.EventHandler(this.btnAddTariff_Click);
            // 
            // btnEditTariff
            // 
            this.btnEditTariff.Enabled = false;
            this.btnEditTariff.Location = new System.Drawing.Point(362, 199);
            this.btnEditTariff.Name = "btnEditTariff";
            this.btnEditTariff.Size = new System.Drawing.Size(110, 23);
            this.btnEditTariff.TabIndex = 8;
            this.btnEditTariff.Text = "Редактировать";
            this.btnEditTariff.UseVisualStyleBackColor = true;
            this.btnEditTariff.Click += new System.EventHandler(this.btnEditTariff_Click);
            // 
            // btnDeleteTariff
            // 
            this.btnDeleteTariff.Enabled = false;
            this.btnDeleteTariff.Location = new System.Drawing.Point(362, 228);
            this.btnDeleteTariff.Name = "btnDeleteTariff";
            this.btnDeleteTariff.Size = new System.Drawing.Size(110, 23);
            this.btnDeleteTariff.TabIndex = 9;
            this.btnDeleteTariff.Text = "Удалить";
            this.btnDeleteTariff.UseVisualStyleBackColor = true;
            this.btnDeleteTariff.Click += new System.EventHandler(this.btnDeleteTariff_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(362, 257);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(110, 23);
            this.btnClearFields.TabIndex = 10;
            this.btnClearFields.Text = "Очистить поля";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // TariffManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 296);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.btnDeleteTariff);
            this.Controls.Add(this.btnEditTariff);
            this.Controls.Add(this.btnAddTariff);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.numPricePerMinute);
            this.Controls.Add(this.lblPricePerMinute);
            this.Controls.Add(this.txtTariffName);
            this.Controls.Add(this.lblTariffName);
            this.Controls.Add(this.dgvTariffs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TariffManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление тарифами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTariffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTariffs;
        private System.Windows.Forms.Label lblTariffName;
        private System.Windows.Forms.TextBox txtTariffName;
        private System.Windows.Forms.Label lblPricePerMinute;
        private System.Windows.Forms.NumericUpDown numPricePerMinute;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAddTariff;
        private System.Windows.Forms.Button btnEditTariff;
        private System.Windows.Forms.Button btnDeleteTariff;
        private System.Windows.Forms.Button btnClearFields;
    }
}