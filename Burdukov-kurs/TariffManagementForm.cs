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
    public partial class TariffManagementForm : Form
    {
        private const string TariffsFilePath = "tariffs.csv";
        private List<Tariff> allTariffs = new List<Tariff>();
        private Tariff currentEditingTariff = null;

        public TariffManagementForm()
        {
            InitializeComponent();
            LoadTariffs();
        }

        private void LoadTariffs()
        {
            allTariffs.Clear();
            if (File.Exists(TariffsFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(TariffsFilePath);
                    if (lines.Length > 0 && lines[0] == "Id,Name,PricePerMinute,Description") // Check header
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(',');
                            if (values.Length == 4)
                            {
                                try
                                {
                                    Guid id = Guid.Parse(values[0]);
                                    string name = values[1].Trim('"');
                                    decimal price = decimal.Parse(values[2].Replace('.', ','));
                                    string description = values[3].Trim('"');
                                    allTariffs.Add(new Tariff(id, name, price, description));
                                }
                                catch (FormatException ex)
                                {
                                    MessageBox.Show($"Ошибка форматирования данных тарифа в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                catch (ArgumentException ex) // For Guid.Parse
                                {
                                    MessageBox.Show($"Ошибка в Id тарифа в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке тарифов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            BindDataToGrid();
            ClearInputFields();
        }

        private void SaveTariffs()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Id,Name,PricePerMinute,Description"); // Header
                foreach (var tariff in allTariffs)
                {
                    sb.AppendLine($"{tariff.Id}, \"{tariff.Name}\", {tariff.PricePerMinute.ToString().Replace(',', '.')}, \"{tariff.Description}\"");
                }
                File.WriteAllText(TariffsFilePath, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении тарифов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid()
        {
            dgvTariffs.DataSource = null;
            dgvTariffs.DataSource = allTariffs.ToList(); // ToList() для создания копии и корректной привязки
            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            if (dgvTariffs.Columns.Count > 0)
            {
                dgvTariffs.Columns["Id"].Visible = false; // Скрываем Id
                dgvTariffs.Columns["Name"].HeaderText = "Название";
                dgvTariffs.Columns["PricePerMinute"].HeaderText = "Цена/мин";
                dgvTariffs.Columns["PricePerMinute"].DefaultCellStyle.Format = "C2";
                dgvTariffs.Columns["Description"].HeaderText = "Описание";
                dgvTariffs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void ClearInputFields()
        {
            txtTariffName.Clear();
            numPricePerMinute.Value = 0;
            txtDescription.Clear();
            currentEditingTariff = null;
            
            // Reset button states
            btnEditTariff.Enabled = false;
            btnSaveChanges.Enabled = false;
            btnDeleteTariff.Enabled = false;
            
            // Reset input field states
            txtTariffName.ReadOnly = true;
            numPricePerMinute.Enabled = false;
            txtDescription.ReadOnly = true;
            
            dgvTariffs.ClearSelection();
        }

        private void btnAddTariff_Click(object sender, EventArgs e)
        {
            // Always clear input fields when adding new tariff
            ClearInputFields();
            
            // Open the add dialog
            using (var addForm = new AddTariffForm())
            {
                if (addForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (allTariffs.Any(t => t.Name.Equals(addForm.TariffName, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Тариф с таким названием уже существует.", "Ошибка ввода", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Add new tariff
                    var newTariff = new Tariff(addForm.TariffName, addForm.PricePerMinute, addForm.Description);
                    allTariffs.Add(newTariff);
                    
                    // Save and refresh
                    SaveTariffs();
                    BindDataToGrid();
                    
                    // Select the newly added tariff
                    var index = allTariffs.IndexOf(newTariff);
                    if (index >= 0)
                    {
                        dgvTariffs.Rows[index].Selected = true;
                        dgvTariffs.FirstDisplayedScrollingRowIndex = index;
                    }
                    
                    MessageBox.Show("Тариф успешно добавлен.", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditTariff_Click(object sender, EventArgs e)
        {
            if (dgvTariffs.SelectedRows.Count > 0)
            {
                currentEditingTariff = (Tariff)dgvTariffs.SelectedRows[0].DataBoundItem;
                
                // Load the selected tariff into the input fields for editing
                txtTariffName.Text = currentEditingTariff.Name;
                numPricePerMinute.Value = currentEditingTariff.PricePerMinute;
                txtDescription.Text = currentEditingTariff.Description;
                
                // Enable/disable appropriate buttons
                btnEditTariff.Enabled = false; // Disable edit button while editing
                btnSaveChanges.Enabled = true; // Enable save button
                btnDeleteTariff.Enabled = true;
                
                // Enable input fields for editing
                txtTariffName.ReadOnly = false;
                numPricePerMinute.Enabled = true;
                txtDescription.ReadOnly = false;
                
                // Set focus to the name field
                txtTariffName.Focus();
            }
        }

        private void btnDeleteTariff_Click(object sender, EventArgs e)
        {
            if (dgvTariffs.SelectedRows.Count > 0 && currentEditingTariff != null)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить тариф '{currentEditingTariff.Name}'?",
                                             "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    allTariffs.Remove(currentEditingTariff);
                    SaveTariffs();
                    BindDataToGrid();
                    ClearInputFields();
                    MessageBox.Show("Тариф успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите тариф для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void dgvTariffs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTariffs.SelectedRows.Count > 0)
            {
                currentEditingTariff = (Tariff)dgvTariffs.SelectedRows[0].DataBoundItem;
                
                // Load the selected tariff into the input fields
                txtTariffName.Text = currentEditingTariff.Name;
                numPricePerMinute.Value = currentEditingTariff.PricePerMinute;
                txtDescription.Text = currentEditingTariff.Description;
                
                // Enable edit and delete buttons
                btnEditTariff.Enabled = true;
                btnDeleteTariff.Enabled = true;
                btnSaveChanges.Enabled = false; // Disable save button initially
                
                // Make fields read-only until edit is clicked
                txtTariffName.ReadOnly = true;
                numPricePerMinute.Enabled = false;
                txtDescription.ReadOnly = true;
            }
            else
            {
                // Clear input fields when no row is selected
                ClearInputFields();
            }
        }
        
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (currentEditingTariff == null) return;
            
            string newName = txtTariffName.Text.Trim();
            decimal newPrice = numPricePerMinute.Value;
            string newDescription = txtDescription.Text.Trim();
            
            // Validate input
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Название тарифа не может быть пустым.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTariffName.Focus();
                return;
            }
            
            if (newPrice <= 0)
            {
                MessageBox.Show("Цена за минуту должна быть больше нуля.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPricePerMinute.Focus();
                return;
            }
            
            // Check for duplicate name (excluding current tariff)
            if (allTariffs.Any(t => t.Id != currentEditingTariff.Id && 
                                  t.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Другой тариф с таким названием уже существует.", "Ошибка ввода", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTariffName.Focus();
                return;
            }
            
            // Update the tariff
            currentEditingTariff.Name = newName;
            currentEditingTariff.PricePerMinute = newPrice;
            currentEditingTariff.Description = newDescription;
            
            // Save changes
            SaveTariffs();
            BindDataToGrid();
            
            // Reset UI
            btnSaveChanges.Enabled = false;
            btnEditTariff.Enabled = true;
            
            // Make fields read-only again
            txtTariffName.ReadOnly = true;
            numPricePerMinute.Enabled = false;
            txtDescription.ReadOnly = true;
            
            MessageBox.Show("Изменения сохранены.", "Успех", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}