using System;
using System.Windows.Forms;

namespace Burdukov_kurs
{
    public partial class AddServiceForm : Form
    {
        public string ServiceName { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }

        public AddServiceForm()
        {
            InitializeComponent();
            this.Text = "Добавление новой услуги";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Название услуги не может быть пустым.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Цена должна быть больше нуля.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return;
            }

            ServiceName = txtServiceName.Text.Trim();
            Price = numPrice.Value;
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
