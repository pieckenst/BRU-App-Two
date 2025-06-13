namespace Burdukov_kurs
{
    partial class AddTariffForm
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
            this.lblTariffName = new System.Windows.Forms.Label();
            this.txtTariffName = new System.Windows.Forms.TextBox();
            this.lblPricePerMinute = new System.Windows.Forms.Label();
            this.numPricePerMinute = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerMinute)).BeginInit();
            this.SuspendLayout();
            
            // lblTariffName
            // 
            this.lblTariffName.AutoSize = true;
            this.lblTariffName.Location = new System.Drawing.Point(12, 15);
            this.lblTariffName.Name = "lblTariffName";
            this.lblTariffName.Size = new System.Drawing.Size(96, 13);
            this.lblTariffName.TabIndex = 0;
            this.lblTariffName.Text = "Название тарифа:";
            // 
            // txtTariffName
            // 
            this.txtTariffName.Location = new System.Drawing.Point(114, 12);
            this.txtTariffName.Name = "txtTariffName";
            this.txtTariffName.Size = new System.Drawing.Size(250, 20);
            this.txtTariffName.TabIndex = 1;
            // 
            // lblPricePerMinute
            // 
            this.lblPricePerMinute.AutoSize = true;
            this.lblPricePerMinute.Location = new System.Drawing.Point(12, 41);
            this.lblPricePerMinute.Name = "lblPricePerMinute";
            this.lblPricePerMinute.Size = new System.Drawing.Size(89, 13);
            this.lblPricePerMinute.TabIndex = 2;
            this.lblPricePerMinute.Text = "Цена за минуту:";
            // 
            // numPricePerMinute
            // 
            this.numPricePerMinute.DecimalPlaces = 2;
            this.numPricePerMinute.Location = new System.Drawing.Point(114, 39);
            this.numPricePerMinute.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPricePerMinute.Name = "numPricePerMinute";
            this.numPricePerMinute.Size = new System.Drawing.Size(120, 20);
            this.numPricePerMinute.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 67);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(114, 64);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(250, 80);
            this.txtDescription.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(208, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(289, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddTariffForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(376, 185);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.numPricePerMinute);
            this.Controls.Add(this.lblPricePerMinute);
            this.Controls.Add(this.txtTariffName);
            this.Controls.Add(this.lblTariffName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTariffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление нового тарифа";
            ((System.ComponentModel.ISupportInitialize)(this.numPricePerMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTariffName;
        private System.Windows.Forms.TextBox txtTariffName;
        private System.Windows.Forms.Label lblPricePerMinute;
        private System.Windows.Forms.NumericUpDown numPricePerMinute;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}
