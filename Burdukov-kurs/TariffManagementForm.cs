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
            btnAddTariff.Text = "Добавить";
            btnEditTariff.Enabled = false;
            btnDeleteTariff.Enabled = false;
            dgvTariffs.ClearSelection();
        }

        private void btnAddTariff_Click(object sender, EventArgs e)
        {
            string name = txtTariffName.Text.Trim();
            decimal price = numPricePerMinute.Value;
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Название тарифа не может быть пустым.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTariffName.Focus();
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Цена за минуту должна быть больше нуля.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPricePerMinute.Focus();
                return;
            }

            if (currentEditingTariff == null) // Добавление нового тарифа
            {
                if (allTariffs.Any(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Тариф с таким названием уже существует.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTariffName.Focus();
                    return;
                }
                allTariffs.Add(new Tariff(name, price, description));
                MessageBox.Show("Тариф успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Редактирование существующего тарифа
            {
                if (allTariffs.Any(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && t.Id != currentEditingTariff.Id))
                {
                    MessageBox.Show("Другой тариф с таким названием уже существует.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTariffName.Focus();
                    return;
                }
                currentEditingTariff.Name = name;
                currentEditingTariff.PricePerMinute = price;
                currentEditingTariff.Description = description;
                MessageBox.Show("Тариф успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SaveTariffs();
            BindDataToGrid();
            ClearInputFields();
        }

        private void btnEditTariff_Click(object sender, EventArgs e)
        {
            if (dgvTariffs.SelectedRows.Count > 0)
            {
                currentEditingTariff = (Tariff)dgvTariffs.SelectedRows[0].DataBoundItem;
                txtTariffName.Text = currentEditingTariff.Name;
                numPricePerMinute.Value = currentEditingTariff.PricePerMinute;
                txtDescription.Text = currentEditingTariff.Description;
                btnAddTariff.Text = "Сохранить";
                btnEditTariff.Enabled = true; // Остается активной для отмены
                btnDeleteTariff.Enabled = true;
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
                txtTariffName.Text = currentEditingTariff.Name;
                numPricePerMinute.Value = currentEditingTariff.PricePerMinute;
                txtDescription.Text = currentEditingTariff.Description;
                btnAddTariff.Text = "Сохранить"; // Меняем текст кнопки, если выбран тариф для редактирования
                btnEditTariff.Enabled = true;
                btnDeleteTariff.Enabled = true;
            }
            else
            {
                // Если выделение снято (например, после удаления или очистки), сбрасываем поля
                // ClearInputFields(); // Это может быть излишним, если SelectionChanged срабатывает при ClearSelection
            }
        }
    }
}