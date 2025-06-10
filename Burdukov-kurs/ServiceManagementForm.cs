using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Burdukov_kurs
{
    public partial class ServiceManagementForm : Form
    {
        private const string ServicesFilePath = "operator_services.csv";
        private List<OperatorService> allServices = new List<OperatorService>();
        private OperatorService currentEditingService = null;

        public ServiceManagementForm()
        {
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            allServices.Clear();
            if (File.Exists(ServicesFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(ServicesFilePath);
                    // Check for header: Id,Name,Price,Description
                    if (lines.Length > 0 && lines[0] == "Id,Name,Price,Description") 
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(',');
                            if (values.Length == 4) // Expect 4 values
                            {
                                try
                                {
                                    Guid id = Guid.Parse(values[0]);
                                    string name = values[1].Trim('"');
                                    decimal price = decimal.Parse(values[2].Replace('.', ','));
                                    string description = values[3].Trim('"');
                                    allServices.Add(new OperatorService(id, name, price, description));
                                }
                                catch (FormatException ex)
                                {
                                    MessageBox.Show($"Ошибка форматирования данных услуги в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                catch (ArgumentException ex) // For Guid.Parse
                                {
                                    MessageBox.Show($"Ошибка в Id услуги в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке услуг: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            BindDataToGrid();
            ClearInputFields();
        }

        private void SaveServices()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Id,Name,Price,Description"); // Header
                foreach (var service in allServices)
                {
                    sb.AppendLine($"{service.Id},\"{service.Name}\",{service.Price.ToString().Replace(',', '.')},\"{service.Description}\"");
                }
                File.WriteAllText(ServicesFilePath, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении услуг: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid()
        {
            dgvServices.DataSource = null;
            dgvServices.DataSource = allServices.ToList(); 
            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            if (dgvServices.Columns.Count > 0)
            {
                dgvServices.Columns["Id"].Visible = false;
                dgvServices.Columns["Name"].HeaderText = "Название";
                dgvServices.Columns["Price"].HeaderText = "Стоимость";
                dgvServices.Columns["Price"].DefaultCellStyle.Format = "C2";
                dgvServices.Columns["Description"].HeaderText = "Описание";
                dgvServices.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void ClearInputFields()
        {
            txtServiceName.Clear();
            numServicePrice.Value = 0;
            txtServiceDescription.Clear();
            currentEditingService = null;
            btnAddService.Text = "Добавить";
            btnEditService.Enabled = false;
            btnDeleteService.Enabled = false;
            dgvServices.ClearSelection();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            string name = txtServiceName.Text.Trim();
            decimal price = numServicePrice.Value;
            string description = txtServiceDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Название услуги не может быть пустым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }
            // Price can be 0 for free services, or validate as needed

            if (currentEditingService == null) // Add new service
            {
                if (allServices.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Услуга с таким названием уже существует.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServiceName.Focus();
                    return;
                }
                allServices.Add(new OperatorService(name, price, description));
                MessageBox.Show("Услуга успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Edit existing service
            {
                if (allServices.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && s.Id != currentEditingService.Id))
                {
                    MessageBox.Show("Другая услуга с таким названием уже существует.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServiceName.Focus();
                    return;
                }
                currentEditingService.Name = name;
                currentEditingService.Price = price;
                currentEditingService.Description = description;
                MessageBox.Show("Услуга успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SaveServices();
            BindDataToGrid();
            ClearInputFields();
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                currentEditingService = (OperatorService)dgvServices.SelectedRows[0].DataBoundItem;
                txtServiceName.Text = currentEditingService.Name;
                numServicePrice.Value = currentEditingService.Price;
                txtServiceDescription.Text = currentEditingService.Description;
                btnAddService.Text = "Сохранить";
                btnEditService.Enabled = true;
                btnDeleteService.Enabled = true;
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0 && currentEditingService != null)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить услугу '{currentEditingService.Name}'?",
                                             "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    allServices.Remove(currentEditingService);
                    SaveServices();
                    BindDataToGrid();
                    ClearInputFields();
                    MessageBox.Show("Услуга успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                 MessageBox.Show("Выберите услугу для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                currentEditingService = (OperatorService)dgvServices.SelectedRows[0].DataBoundItem;
                txtServiceName.Text = currentEditingService.Name;
                numServicePrice.Value = currentEditingService.Price;
                txtServiceDescription.Text = currentEditingService.Description;
                btnAddService.Text = "Сохранить";
                btnEditService.Enabled = true;
                btnDeleteService.Enabled = true;
            }
        }
    }
}