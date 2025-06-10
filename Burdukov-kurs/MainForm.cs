using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; // Для операций с файлами
using System.Windows.Forms;
// Removed duplicate using statements and nested class declaration
// using Burdukov_kurs; // This will be added if CallManagementForm is in the same namespace and not found

namespace Burdukov_kurs
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private List<Call> allCalls = new List<Call>();
        private const string CallsFilePath = "calls_data.csv"; // Path to the calls data file
        private const string TariffsFilePath = "tariffs.csv";
        private const string ServicesFilePath = "operator_services.csv";

        private List<Tariff> availableTariffs = new List<Tariff>();
        private List<OperatorService> availableServices = new List<OperatorService>();

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadCallDataFromFile(); // Load data from file instead of demo data
            InitializeSortComboBox();
            // Привязка обработчиков событий к кнопкам
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);

            // Event handlers for menu items
            this.manageTariffsToolStripMenuItem.Click += new System.EventHandler(this.ManageTariffsToolStripMenuItem_Click);
            this.manageServicesToolStripMenuItem.Click += new System.EventHandler(this.ManageServicesToolStripMenuItem_Click);
            this.manageCallsToolStripMenuItem.Click += new System.EventHandler(this.ManageCallsToolStripMenuItem_Click);

            // Настройка видимости меню в зависимости от роли пользователя
            if (currentUser.Role == UserRole.Administrator)
            {
                adminToolStripMenuItem.Visible = true;
            }
            else
            {
                adminToolStripMenuItem.Visible = false;
            }
        }

        private void LoadTariffsFromFile()
        {
            availableTariffs.Clear();
            if (!File.Exists(TariffsFilePath))
            {
                // Optional: Create an empty file with headers if it doesn't exist
                // File.WriteAllText(TariffsFilePath, "Id,Name,PricePerMinute,Description\n");
                return; // No tariffs to load
            }

            try
            {
                string[] lines = File.ReadAllLines(TariffsFilePath);
                if (lines.Length > 0 && lines[0].Trim() == "Id,Name,PricePerMinute,Description") // Header check
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
                                MessageBox.Show($"Ошибка форматирования данных тарифа в файле '{Path.GetFileName(TariffsFilePath)}' в строке {i + 1}: {ex.Message}", "Ошибка чтения файла тарифов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке тарифов: " + ex.Message, "Ошибка загрузки тарифов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServicesFromFile()
        {
            availableServices.Clear();
            if (!File.Exists(ServicesFilePath))
            {
                // Optional: Create an empty file with headers if it doesn't exist
                // File.WriteAllText(ServicesFilePath, "Id,Name,Price,Description\n");
                return; // No services to load
            }

            try
            {
                string[] lines = File.ReadAllLines(ServicesFilePath);
                 if (lines.Length > 0 && lines[0].Trim() == "Id,Name,Price,Description") // Header check
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
                                MessageBox.Show($"Ошибка форматирования данных услуги в файле '{Path.GetFileName(ServicesFilePath)}' в строке {i + 1}: {ex.Message}", "Ошибка чтения файла услуг", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке услуг: " + ex.Message, "Ошибка загрузки услуг", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCallDataFromFile()
        {
            LoadTariffsFromFile(); // Ensure tariffs are loaded first
            LoadServicesFromFile(); // Ensure services are loaded first

            allCalls.Clear();
            if (!File.Exists(CallsFilePath))
            {
                return; // No calls to load
            }
            
            try
            {
                string[] lines = File.ReadAllLines(CallsFilePath);
                if (lines.Length > 0 && lines[0].Trim() == "SubscriberName,SubscriberNumber,CorrespondentNumber,CallType,CallTime,Duration,Cost,TariffId,ServiceId")
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
                                Guid? tariffId = string.IsNullOrEmpty(values[7]) || values[7].ToLower() == "null" ? (Guid?)null : Guid.Parse(values[7]);
                                Guid? serviceId = string.IsNullOrEmpty(values[8]) || values[8].ToLower() == "null" ? (Guid?)null : Guid.Parse(values[8]);

                                Tariff tariff = tariffId.HasValue ? availableTariffs.FirstOrDefault(t => t.Id == tariffId.Value) : null;
                                OperatorService service = serviceId.HasValue ? availableServices.FirstOrDefault(s => s.Id == serviceId.Value) : null;

                                allCalls.Add(new Call(subName, subNum, corrNum, callType, callTime, duration, cost, tariff, service));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка форматирования данных вызова в файле '{Path.GetFileName(CallsFilePath)}' в строке {i + 1}: {ex.Message}", "Ошибка чтения файла вызовов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о вызовах: " + ex.Message, "Ошибка загрузки вызовов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSortComboBox()
        {
            cmbSort.Items.Add("По дате (возрастание)");
            cmbSort.Items.Add("По дате (убывание)");
            cmbSort.Items.Add("По длительности (возрастание)");
            cmbSort.Items.Add("По длительности (убывание)");
            cmbSort.Items.Add("По ФИО абонента (А-Я)");
            cmbSort.Items.Add("По ФИО абонента (Я-А)");
            if (cmbSort.Items.Count > 0) cmbSort.SelectedIndex = 0;
        }

        // Event handler for "Управление тарифами"
        private void управлениеТарифамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Assuming TariffManagementForm exists and is correctly namespaced
            // TariffManagementForm tariffForm = new TariffManagementForm();
            // tariffForm.ShowDialog();
            // LoadCallDataFromFile(); // Reload data in case tariffs changed
            MessageBox.Show("Tariff Management form will be implemented here.");
        }

        // Event handler for "Управление услугами"
        private void управлениеУслугамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Assuming ServiceManagementForm exists and is correctly namespaced
            // ServiceManagementForm serviceForm = new ServiceManagementForm();
            // serviceForm.ShowDialog();
            // LoadCallDataFromFile(); // Reload data in case services changed
            MessageBox.Show("Service Management form will be implemented here.");
        }

        // Event handler for "Управление вызовами"
        private void управлениеВызовамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallManagementForm callForm = new CallManagementForm();
            callForm.ShowDialog();
            LoadCallDataFromFile(); // Reload data in case calls changed
        }

        private void SetupDataGridViewColumns()
        {
            dgvCalls.AutoGenerateColumns = false; // Important for custom column setup
            dgvCalls.Columns.Clear();

            // Define columns programmatically to ensure correct binding and headers
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubscriberName", HeaderText = "Имя абонента" });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubscriberNumber", HeaderText = "Номер абонента" });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CorrespondentNumber", HeaderText = "Номер собеседника" });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Type", HeaderText = "Тип" });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CallTime", HeaderText = "Время", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm:ss" } });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Duration", HeaderText = "Длительность (сек)" });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cost", HeaderText = "Стоимость", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TariffName", HeaderText = "Тариф" });
            dgvCalls.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceName", HeaderText = "Услуга" });

            // Автоматическое изменение размера столбцов для соответствия содержимому
            dgvCalls.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnGenerateReport_Click(object sender, System.EventArgs e)
        {
            DateTime startDate = dtpPeriodStart.Value.Date;
            DateTime endDate = dtpPeriodEnd.Value.Date.AddDays(1).AddTicks(-1); // Включая весь конечный день

            var callsInPeriod = allCalls.Where(c => c.CallTime.Date >= startDate && c.CallTime.Date <= endDate.Date).ToList();

            if (!callsInPeriod.Any())
            {
                MessageBox.Show("Нет данных для отображения за указанный период.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var reportData = new Dictionary<string, SubscriberReportData>();

            var groupedBySubscriber = callsInPeriod.GroupBy(c => c.SubscriberName);

            foreach (var group in groupedBySubscriber)
            {
                var subscriberData = new SubscriberReportData();
                subscriberData.Calls = group.ToList();
                subscriberData.TotalIncomingDuration = TimeSpan.FromSeconds(group.Where(c => c.Type == CallType.Incoming).Sum(c => c.Duration));
                subscriberData.TotalOutgoingDuration = TimeSpan.FromSeconds(group.Where(c => c.Type == CallType.Outgoing).Sum(c => c.Duration));
                subscriberData.TotalOutgoingCost = group.Where(c => c.Type == CallType.Outgoing).Sum(c => c.Cost);
                
                reportData[group.Key] = subscriberData;
            }

            IndividualReportForm reportForm = new IndividualReportForm(reportData);
            reportForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            List<Call> filteredCalls;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                filteredCalls = allCalls;
            }
            else
            {
                filteredCalls = allCalls.Where(c =>
                    (c.SubscriberName != null && c.SubscriberName.ToLower().Contains(searchTerm)) ||
                    (c.SubscriberNumber != null && c.SubscriberNumber.Contains(searchTerm)) ||
                    (c.CorrespondentNumber != null && c.CorrespondentNumber.ToLower().Contains(searchTerm))
                ).ToList();
            }

            dgvCalls.DataSource = null;
            dgvCalls.DataSource = filteredCalls;
            SetupDataGridViewColumns();

            if (!filteredCalls.Any() && !string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("По вашему запросу ничего не найдено.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSort_Click(object sender, System.EventArgs e)
        {
            if (dgvCalls.DataSource == null) return;

            List<Call> currentCalls = (List<Call>)dgvCalls.DataSource;
            List<Call> sortedCalls = new List<Call>(currentCalls);

            string sortBy = cmbSort.SelectedItem.ToString();

            switch (sortBy)
            {
                case "По дате (возрастание)":
                    sortedCalls = sortedCalls.OrderBy(c => c.CallTime).ToList();
                    break;
                case "По дате (убывание)":
                    sortedCalls = sortedCalls.OrderByDescending(c => c.CallTime).ToList();
                    break;
                case "По длительности (возрастание)":
                    sortedCalls = sortedCalls.OrderBy(c => c.Duration).ToList();
                    break;
                case "По длительности (убывание)":
                    sortedCalls = sortedCalls.OrderByDescending(c => c.Duration).ToList();
                    break;
                case "По ФИО абонента (А-Я)":
                    sortedCalls = sortedCalls.OrderBy(c => c.SubscriberName).ToList();
                    break;
                case "По ФИО абонента (Я-А)":
                    sortedCalls = sortedCalls.OrderByDescending(c => c.SubscriberName).ToList();
                    break;
            }

            dgvCalls.DataSource = null;
            dgvCalls.DataSource = sortedCalls;
            SetupDataGridViewColumns();
        }

        // Обработчики событий для меню "Файл"
        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Сохранить данные как";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = "calls_data.csv"; // Suggest default file name

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (allCalls.Any())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("SubscriberName,SubscriberNumber,CorrespondentNumber,CallType,CallTime,Duration,Cost,TariffId,ServiceId");
                        foreach (var call in allCalls) // Save current in-memory allCalls list
                        {
                            sb.AppendLine($"\"{call.SubscriberName}\",\"{call.SubscriberNumber}\",\"{call.CorrespondentNumber}\",{call.Type},{call.CallTime:yyyy-MM-dd HH:mm:ss},{call.Duration},{call.Cost.ToString().Replace(',', '.')},{(call.Tariff?.Id.ToString() ?? string.Empty)},{(call.Service?.Id.ToString() ?? string.Empty)}");
                        }
                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                        MessageBox.Show("Данные успешно сохранены в файл: " + Path.GetFileName(saveFileDialog.FileName), "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Нет данных для сохранения.", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Открыть файл данных о вызовах";
            openFileDialog.DefaultExt = "csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadSpecificCallDataFile(openFileDialog.FileName);
                    dgvCalls.DataSource = null; // Force refresh
                    dgvCalls.DataSource = allCalls;
                    // SetupDataGridViewColumns(); // Columns should already be set up, but refresh might be needed if auto-generate was on
                    MessageBox.Show("Данные успешно загружены из файла: " + Path.GetFileName(openFileDialog.FileName), "Открытие файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при открытии файла: " + ex.Message, "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Метод для загрузки данных из конкретного файла (используется openFileToolStripMenuItem_Click)
        private void LoadSpecificCallDataFile(string filePath)
        {
            LoadTariffsFromFile(); // Тарифы и услуги нужны для связывания
            LoadServicesFromFile();
            allCalls.Clear();

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Файл '{Path.GetFileName(filePath)}' не найден.", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length > 0 && lines[0].Trim() == "SubscriberName,SubscriberNumber,CorrespondentNumber,CallType,CallTime,Duration,Cost,TariffId,ServiceId")
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
                                Guid? tariffId = string.IsNullOrEmpty(values[7]) || values[7].ToLower() == "null" ? (Guid?)null : Guid.Parse(values[7]);
                                Guid? serviceId = string.IsNullOrEmpty(values[8]) || values[8].ToLower() == "null" ? (Guid?)null : Guid.Parse(values[8]);

                                Tariff tariff = tariffId.HasValue ? availableTariffs.FirstOrDefault(t => t.Id == tariffId.Value) : null;
                                OperatorService service = serviceId.HasValue ? availableServices.FirstOrDefault(s => s.Id == serviceId.Value) : null;

                                allCalls.Add(new Call(subName, subNum, corrNum, callType, callTime, duration, cost, tariff, service));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка форматирования данных вызова в файле '{Path.GetFileName(filePath)}' в строке {i + 1}: {ex.Message}", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else if (lines.Length > 0)
                {
                    MessageBox.Show($"Файл '{Path.GetFileName(filePath)}' имеет неверный формат заголовка.", "Ошибка формата файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных о вызовах из файла '{Path.GetFileName(filePath)}': " + ex.Message, "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите файл для удаления";
            openFileDialog.Filter = "Все файлы (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePathToDelete = openFileDialog.FileName;
                DialogResult confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить файл '{Path.GetFileName(filePathToDelete)}'? Это действие необратимо.",
                                                       "Подтверждение удаления",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(filePathToDelete);
                        MessageBox.Show("Файл успешно удален.", "Удаление файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        if (Path.GetFullPath(filePathToDelete).Equals(Path.GetFullPath(CallsFilePath), StringComparison.OrdinalIgnoreCase))
                        {
                            allCalls.Clear();
                            dgvCalls.DataSource = null;
                            dgvCalls.DataSource = allCalls; // Refresh with empty list
                            MessageBox.Show("Текущий файл данных ('calls_data.csv') был удален. Данные на форме очищены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении файла: " + ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Обработчики событий для меню "Администрирование"
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser.Role == UserRole.Administrator)
            {
                UserManagementForm userManagementForm = new UserManagementForm();
                userManagementForm.ShowDialog();
                // Optionally, reload users or refresh something if UserManagementForm makes changes that affect MainForm
            }
            else
            {
                MessageBox.Show("У вас нет прав для доступа к этой функции.", "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void manageTariffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TariffManagementForm tariffForm = new TariffManagementForm();
            tariffForm.ShowDialog();
            LoadCallDataFromFile(); // Reload data as tariffs might affect call costs or display
            btnLoadData_Click(this, EventArgs.Empty); // Refresh DataGridView
        }

        private void manageServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceManagementForm serviceForm = new ServiceManagementForm();
            serviceForm.ShowDialog();
            LoadCallDataFromFile(); // Reload data as services might affect calls
            btnLoadData_Click(this, EventArgs.Empty); // Refresh DataGridView
        }

        private void manageCallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallManagementForm callForm = new CallManagementForm();
            callForm.ShowDialog();
            LoadCallDataFromFile(); // Reload data as calls were directly managed
            btnLoadData_Click(this, EventArgs.Empty); // Refresh DataGridView
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadCallDataFromFile();
            if (dgvCalls != null)
            {
                dgvCalls.DataSource = null;
                dgvCalls.DataSource = allCalls;
            }
        }

        // Button click handlers are implemented above in the file

        private void ManageTariffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tariffForm = new TariffManagementForm();
            tariffForm.ShowDialog();
        }

        private void ManageServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var serviceForm = new ServiceManagementForm();
            serviceForm.ShowDialog();
        }

        private void ManageCallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var callForm = new CallManagementForm();
            callForm.ShowDialog();
        }
    }
}
