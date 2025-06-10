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
    public partial class CallManagementForm : Form
    {
        private const string CallsFilePath = "calls_data.csv";
        private const string TariffsFilePath = "tariffs.csv";
        private const string ServicesFilePath = "operator_services.csv";

        private List<Call> allCalls = new List<Call>();
        private List<Tariff> availableTariffs = new List<Tariff>();
        private List<OperatorService> availableServices = new List<OperatorService>();
        private Call currentEditingCall = null;

        public CallManagementForm()
        {
            InitializeComponent();
        }

        private void CallManagementForm_Load(object sender, EventArgs e)
        {
            LoadTariffs();
            LoadServices();
            LoadCalls();
            PopulateComboBoxes();
            SetupDataGridViewColumns();
        }

        private void LoadTariffs()
        {
            availableTariffs.Clear();
            if (File.Exists(TariffsFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(TariffsFilePath);
                    if (lines.Length > 0 && lines[0] == "Id,Name,PricePerMinute,Description") // Header check
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
                                    availableTariffs.Add(new Tariff(id, name, price, description));
                                }
                                catch (FormatException ex)
                                {
                                    MessageBox.Show($"Ошибка форматирования данных тарифа в файле '{TariffsFilePath}' в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void LoadServices()
        {
            availableServices.Clear();
            if (File.Exists(ServicesFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(ServicesFilePath);
                     if (lines.Length > 0 && lines[0] == "Id,Name,Price,Description") // Header check
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
                                    availableServices.Add(new OperatorService(id, name, price, description));
                                }
                                catch (FormatException ex)
                                {
                                    MessageBox.Show($"Ошибка форматирования данных услуги в файле '{ServicesFilePath}' в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void LoadCalls()
        {
            allCalls.Clear();
            if (File.Exists(CallsFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(CallsFilePath);
                    // SubscriberName,SubscriberNumber,CorrespondentNumber,CallType,CallTime,Duration,Cost,TariffId,ServiceId
                    if (lines.Length > 0 && lines[0] == "SubscriberName,SubscriberNumber,CorrespondentNumber,CallType,CallTime,Duration,Cost,TariffId,ServiceId")
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(',');
                            if (values.Length == 9)
                            {
                                try
                                {
                                    string subName = values[0].Trim('"');
                                    string subNum = values[1].Trim('"');
                                    string corrNum = values[2].Trim('"');
                                    CallType callType = (CallType)Enum.Parse(typeof(CallType), values[3]);
                                    DateTime callTime = DateTime.Parse(values[4]);
                                    int duration = int.Parse(values[5]);
                                    decimal cost = decimal.Parse(values[6].Replace('.', ','));
                                    Guid? tariffId = string.IsNullOrEmpty(values[7]) ? (Guid?)null : Guid.Parse(values[7]);
                                    Guid? serviceId = string.IsNullOrEmpty(values[8]) ? (Guid?)null : Guid.Parse(values[8]);

                                    Tariff tariff = tariffId.HasValue ? availableTariffs.FirstOrDefault(t => t.Id == tariffId.Value) : null;
                                    OperatorService service = serviceId.HasValue ? availableServices.FirstOrDefault(s => s.Id == serviceId.Value) : null;

                                    allCalls.Add(new Call(subName, subNum, corrNum, callType, callTime, duration, cost, tariff, service));
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ошибка форматирования данных вызова в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о вызовах: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            BindDataToGrid();
            ClearInputFields();
        }

        private void SaveCalls()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SubscriberName,SubscriberNumber,CorrespondentNumber,CallType,CallTime,Duration,Cost,TariffId,ServiceId");
                foreach (var call in allCalls)
                {
                    sb.AppendLine($"\"{call.SubscriberName}\",\"{call.SubscriberNumber}\",\"{call.CorrespondentNumber}\",{call.Type},{call.CallTime:yyyy-MM-dd HH:mm:ss},{call.Duration},{call.Cost.ToString().Replace(',', '.')},{(call.Tariff?.Id.ToString() ?? string.Empty)},{(call.Service?.Id.ToString() ?? string.Empty)}");
                }
                File.WriteAllText(CallsFilePath, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных о вызовах: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateComboBoxes()
        {
            try
            {
                // Initialize CallType combo box
                if (cmbCallType != null)
                {
                    cmbCallType.BeginUpdate();
                    cmbCallType.DataSource = Enum.GetValues(typeof(CallType));
                    if (cmbCallType.Items.Count > 0)
                    {
                        cmbCallType.SelectedIndex = 0;
                    }
                    cmbCallType.EndUpdate();
                }

                // Initialize Tariff combo box
                if (cmbTariff != null)
                {
                    cmbTariff.BeginUpdate();
                    cmbTariff.DataSource = availableTariffs.ToList();
                    cmbTariff.DisplayMember = "Name";
                    cmbTariff.ValueMember = "Id";
                    cmbTariff.SelectedItem = null;
                    cmbTariff.EndUpdate();
                }

                // Initialize Service combo box
                if (cmbService != null)
                {
                    cmbService.BeginUpdate();
                    cmbService.DataSource = availableServices.ToList();
                    cmbService.DisplayMember = "Name";
                    cmbService.ValueMember = "Id";
                    cmbService.SelectedItem = null;
                    cmbService.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации выпадающих списков: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid()
        {
            dgvCalls.DataSource = null;
            dgvCalls.DataSource = allCalls.ToList(); 
            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            if (dgvCalls.Columns.Count > 0)
            {
                dgvCalls.Columns["SubscriberName"].HeaderText = "Имя абонента";
                dgvCalls.Columns["SubscriberNumber"].HeaderText = "Номер абонента";
                dgvCalls.Columns["CorrespondentNumber"].HeaderText = "Номер собеседника";
                dgvCalls.Columns["Type"].HeaderText = "Тип";
                dgvCalls.Columns["CallTime"].HeaderText = "Время";
                dgvCalls.Columns["CallTime"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
                dgvCalls.Columns["Duration"].HeaderText = "Длительность (сек)";
                dgvCalls.Columns["Cost"].HeaderText = "Стоимость";
                dgvCalls.Columns["Cost"].DefaultCellStyle.Format = "C2";
                dgvCalls.Columns["TariffName"].HeaderText = "Тариф";
                dgvCalls.Columns["ServiceName"].HeaderText = "Услуга";

                // Hide original Tariff and Service objects if they are bound directly
                if (dgvCalls.Columns.Contains("Tariff")) dgvCalls.Columns["Tariff"].Visible = false;
                if (dgvCalls.Columns.Contains("Service")) dgvCalls.Columns["Service"].Visible = false;

                dgvCalls.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void ClearInputFields()
        {
            txtSubscriberName.Clear();
            txtSubscriberNumber.Clear();
            txtCorrespondentNumber.Clear();
            
            // Safely set selected index if there are items
            if (cmbCallType != null && cmbCallType.Items.Count > 0)
            {
                cmbCallType.SelectedIndex = 0;
            }
            
            dtpCallTime.Value = DateTime.Now;
            numDuration.Value = 0;
            numCost.Value = 0;
            
            if (cmbTariff != null)
            {
                cmbTariff.SelectedItem = null;
            }
            
            if (cmbService != null)
            {
                cmbService.SelectedItem = null;
            }

            currentEditingCall = null;
            btnAddCall.Text = "Добавить";
            btnEditCall.Enabled = false;
            btnDeleteCall.Enabled = false;
            
            if (dgvCalls != null)
            {
                dgvCalls.ClearSelection();
            }
        }

        private void btnAddCall_Click(object sender, EventArgs e)
        {
            
            try
            {
                var call = new Call
                {
                    SubscriberName = txtSubscriberName.Text.Trim(),
                    SubscriberNumber = txtSubscriberNumber.Text.Trim(),
                    CorrespondentNumber = txtCorrespondentNumber.Text.Trim(),
                    Type = (CallType)cmbCallType.SelectedItem,
                    CallTime = dtpCallTime.Value,
                    Duration = (int)numDuration.Value,
                    Cost = numCost.Value,
                    Tariff = cmbTariff.SelectedItem as Tariff,
                    Service = cmbService.SelectedItem as OperatorService
                };

                if (currentEditingCall == null) // Add new call
                {
                    allCalls.Add(call);
                    MessageBox.Show("Вызов успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Edit existing call
                {
                    int index = allCalls.IndexOf(currentEditingCall);
                    if (index >= 0)
                    {
                        allCalls[index] = call;
                        MessageBox.Show("Вызов успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


                SaveCalls();
                BindDataToGrid();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении вызова: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCall_Click(object sender, EventArgs e)
        {
            if (dgvCalls.SelectedRows.Count > 0)
            {
                currentEditingCall = (Call)dgvCalls.SelectedRows[0].DataBoundItem;
                txtSubscriberName.Text = currentEditingCall.SubscriberName;
                txtSubscriberNumber.Text = currentEditingCall.SubscriberNumber;
                txtCorrespondentNumber.Text = currentEditingCall.CorrespondentNumber;
                cmbCallType.SelectedItem = currentEditingCall.Type;
                dtpCallTime.Value = currentEditingCall.CallTime;
                numDuration.Value = currentEditingCall.Duration;
                numCost.Value = currentEditingCall.Cost;
                cmbTariff.SelectedItem = availableTariffs.FirstOrDefault(t => t.Id == currentEditingCall.Tariff?.Id);
                cmbService.SelectedItem = availableServices.FirstOrDefault(s => s.Id == currentEditingCall.Service?.Id);

                btnAddCall.Text = "Сохранить";
                btnEditCall.Enabled = true;
                btnDeleteCall.Enabled = true;
            }
        }

        private void btnDeleteCall_Click(object sender, EventArgs e)
        {
            if (dgvCalls.SelectedRows.Count > 0 && currentEditingCall != null)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить выбранный вызов?",
                                             "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    allCalls.Remove(currentEditingCall);
                    SaveCalls();
                    BindDataToGrid();
                    ClearInputFields();
                    MessageBox.Show("Вызов успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                 MessageBox.Show("Выберите вызов для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void dgvCalls_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCalls.SelectedRows.Count > 0)
            {
                currentEditingCall = (Call)dgvCalls.SelectedRows[0].DataBoundItem;
                txtSubscriberName.Text = currentEditingCall.SubscriberName;
                txtSubscriberNumber.Text = currentEditingCall.SubscriberNumber;
                txtCorrespondentNumber.Text = currentEditingCall.CorrespondentNumber;
                cmbCallType.SelectedItem = currentEditingCall.Type;
                dtpCallTime.Value = currentEditingCall.CallTime;
                numDuration.Value = currentEditingCall.Duration;
                numCost.Value = currentEditingCall.Cost;
                cmbTariff.SelectedItem = availableTariffs.FirstOrDefault(t => t.Id == currentEditingCall.Tariff?.Id);
                cmbService.SelectedItem = availableServices.FirstOrDefault(s => s.Id == currentEditingCall.Service?.Id);

                btnAddCall.Text = "Сохранить";
                btnEditCall.Enabled = true;
                btnDeleteCall.Enabled = true;
            }
            else
            {
                // Optional: Clear fields if no row is selected, or leave them as is from last selection
                // ClearInputFields(); // Uncomment if you want to clear fields when selection is lost
            }
        }
    }
}