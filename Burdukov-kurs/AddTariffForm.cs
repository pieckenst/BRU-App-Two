using System;
using System.Windows.Forms;

namespace Burdukov_kurs
{
    public partial class AddTariffForm : Form
    {
        public string TariffName { get; private set; }
        public decimal PricePerMinute { get; private set; }
        public string Description { get; private set; }

        public AddTariffForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTariffName.Text))
            {
                MessageBox.Show("Название тарифа не может быть пустым.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTariffName.Focus();
                return;
            }

            if (numPricePerMinute.Value <= 0)
            {
                MessageBox.Show("Цена за минуту должна быть больше нуля.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPricePerMinute.Focus();
                return;
            }

            TariffName = txtTariffName.Text.Trim();
            PricePerMinute = numPricePerMinute.Value;
            Description = txtDescription.Text.Trim();
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
