using System;
using System.Globalization;
using System.Windows.Forms;

namespace Burdukov_kurs
{
    public partial class AddCallForm : Form
    {
        public Call NewCall { get; private set; }

        public AddCallForm()
        {
            InitializeComponent();
        }

        private void AddCallForm_Load(object sender, EventArgs e)
        {
            // TODO: Design AddCallForm and uncomment the following lines, then update control names if necessary.
            // Заполняем ComboBox типами вызовов
            // cmbCallType.DataSource = Enum.GetValues(typeof(CallType));
            // dtpCallTime.Value = DateTime.Now; // Устанавливаем текущее время по умолчанию
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Design AddCallForm and uncomment the following lines, then update control names if necessary.
            /*
            // Валидация данных
            if (string.IsNullOrWhiteSpace(txtSubscriberNumber.Text) ||
                string.IsNullOrWhiteSpace(txtSubscriberName.Text) || 
                cmbCallType.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtCorrespondentNumber.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля (Имя, Номер абонента, Тип вызова, Номер собеседника).", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int durationInSeconds = 0; // Placeholder - implement duration input
            DateTime callDateTime = dtpCallTime.Value;

            NewCall = new Call(
                txtSubscriberName.Text, 
                txtSubscriberNumber.Text,
                txtCorrespondentNumber.Text,
                (CallType)cmbCallType.SelectedItem,
                callDateTime, 
                durationInSeconds, 
                0m, // Cost - placeholder, needs actual calculation or input
                null, // Tariff - placeholder, needs selection mechanism
                null  // Service - placeholder, needs selection mechanism
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
            */
            MessageBox.Show("AddCallForm functionality is currently commented out. Please design the form and uncomment the code in AddCallForm.cs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Cancel; // Close form without action
            this.Close();
        }
    }
}