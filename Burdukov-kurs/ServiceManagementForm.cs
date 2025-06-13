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
            
            // Reset button states
            btnEditService.Enabled = false;
            btnSaveChanges.Enabled = false;
            btnDeleteService.Enabled = false;
            
            // Reset input field states
            txtServiceName.ReadOnly = true;
            numServicePrice.Enabled = false;
            txtServiceDescription.ReadOnly = true;
            
            dgvServices.ClearSelection();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            // Always clear input fields when adding new service
            ClearInputFields();
            
            // Open the add dialog
            using (var addForm = new AddServiceForm())
            {
                if (addForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (allServices.Any(s => s.Name.Equals(addForm.ServiceName, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Услуга с таким названием уже существует.", "Ошибка ввода", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Add new service
                    var newService = new OperatorService(addForm.ServiceName, addForm.Price, addForm.Description);
                    allServices.Add(newService);
                    
                    // Save and refresh
                    SaveServices();
                    BindDataToGrid();
                    
                    // Select the newly added service
                    var index = allServices.IndexOf(newService);
                    if (index >= 0)
                    {
                        dgvServices.Rows[index].Selected = true;
                        dgvServices.FirstDisplayedScrollingRowIndex = index;
                    }
                    
                    MessageBox.Show("Услуга успешно добавлена.", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                currentEditingService = (OperatorService)dgvServices.SelectedRows[0].DataBoundItem;
                
                // Load the selected service into the input fields for editing
                txtServiceName.Text = currentEditingService.Name;
                numServicePrice.Value = currentEditingService.Price;
                txtServiceDescription.Text = currentEditingService.Description;
                
                // Enable/disable appropriate buttons
                btnEditService.Enabled = false; // Disable edit button while editing
                btnSaveChanges.Enabled = true; // Enable save button
                btnDeleteService.Enabled = true;
                
                // Enable input fields for editing
                txtServiceName.ReadOnly = false;
                numServicePrice.Enabled = true;
                txtServiceDescription.ReadOnly = false;
                
                // Set focus to the name field
                txtServiceName.Focus();
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
                    MessageBox.Show("Услуга успешно удалена.", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                
                // Load the selected service into the input fields
                txtServiceName.Text = currentEditingService.Name;
                numServicePrice.Value = currentEditingService.Price;
                txtServiceDescription.Text = currentEditingService.Description;
                
                // Enable edit and delete buttons
                btnEditService.Enabled = true;
                btnDeleteService.Enabled = true;
                btnSaveChanges.Enabled = false; // Disable save button initially
                
                // Make fields read-only until edit is clicked
                txtServiceName.ReadOnly = true;
                numServicePrice.Enabled = false;
                txtServiceDescription.ReadOnly = true;
            }
            else
            {
                // Clear input fields when no row is selected
                ClearInputFields();
            }
        }
        
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (currentEditingService == null) return;
            
            string newName = txtServiceName.Text.Trim();
            decimal newPrice = numServicePrice.Value;
            string newDescription = txtServiceDescription.Text.Trim();
            
            // Validate input
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Название услуги не может быть пустым.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }
            
            // Check for duplicate name (excluding current service)
            if (allServices.Any(s => s.Id != currentEditingService.Id && 
                                   s.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Другая услуга с таким названием уже существует.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }
            
            // Update the service
            currentEditingService.Name = newName;
            currentEditingService.Price = newPrice;
            currentEditingService.Description = newDescription;
            
            // Save changes
            SaveServices();
            BindDataToGrid();
            
            // Reset UI
            btnSaveChanges.Enabled = false;
            btnEditService.Enabled = true;
            
            // Make fields read-only again
            txtServiceName.ReadOnly = true;
            numServicePrice.Enabled = false;
            txtServiceDescription.ReadOnly = true;
            
            MessageBox.Show("Изменения сохранены.", "Успех", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}