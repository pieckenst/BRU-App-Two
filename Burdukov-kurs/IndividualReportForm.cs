using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Burdukov_kurs
{
    public partial class IndividualReportForm : Form
    {
        public IndividualReportForm(Dictionary<string, SubscriberReportData> reportData)
        {
            InitializeComponent();
            GenerateReportTabs(reportData);
        }

        private void GenerateReportTabs(Dictionary<string, SubscriberReportData> reportData)
        {
            foreach (var entry in reportData)
            {
                string subscriberFullName = entry.Key;
                SubscriberReportData data = entry.Value;

                TabPage tabPage = new TabPage(subscriberFullName);
                tabControlReports.TabPages.Add(tabPage);

                // LayoutPanel для организации элементов
                TableLayoutPanel layoutPanel = new TableLayoutPanel();
                layoutPanel.Dock = DockStyle.Fill;
                layoutPanel.ColumnCount = 1;
                layoutPanel.RowCount = 4; // Место для заголовка, грида и итогов
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Заголовок абонента
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F)); // DataGridView
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Итоги
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Итоги
                tabPage.Controls.Add(layoutPanel);

                // Заголовок с ФИО абонента
                Label lblSubscriberHeader = new Label();
                lblSubscriberHeader.Text = $"Отчет по абоненту: {subscriberFullName}";
                lblSubscriberHeader.Font = new Font(this.Font, FontStyle.Bold);
                lblSubscriberHeader.AutoSize = true;
                layoutPanel.Controls.Add(lblSubscriberHeader, 0, 0);

                // DataGridView для отображения звонков
                DataGridView dgvCalls = new DataGridView();
                dgvCalls.Dock = DockStyle.Fill;
                dgvCalls.AllowUserToAddRows = false;
                dgvCalls.AllowUserToDeleteRows = false;
                dgvCalls.ReadOnly = true;
                dgvCalls.DataSource = data.Calls;
                SetupDataGridViewColumns(dgvCalls);
                layoutPanel.Controls.Add(dgvCalls, 0, 1);

                // Метки для итоговой информации
                Label lblTotalIncomingDuration = new Label();
                lblTotalIncomingDuration.Text = $"Общее время входящих вызовов: {data.TotalIncomingDuration}";
                lblTotalIncomingDuration.AutoSize = true;
                layoutPanel.Controls.Add(lblTotalIncomingDuration, 0, 2);

                Label lblTotalOutgoingDuration = new Label();
                lblTotalOutgoingDuration.Text = $"Общее время исходящих вызовов: {data.TotalOutgoingDuration}";
                lblTotalOutgoingDuration.AutoSize = true;
                layoutPanel.Controls.Add(lblTotalOutgoingDuration, 0, 3);

                Label lblTotalOutgoingCost = new Label();
                lblTotalOutgoingCost.Text = $"Общая сумма на исходящие вызовы: {data.TotalOutgoingCost:C}";
                lblTotalOutgoingCost.AutoSize = true;
                // Добавляем еще одну строку для стоимости или используем FlowLayoutPanel для итогов
                // Для простоты, добавим еще одну строку в TableLayoutPanel
                layoutPanel.RowCount = 5;
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                layoutPanel.Controls.Add(lblTotalOutgoingCost, 0, 4);
            }
        }

        private void SetupDataGridViewColumns(DataGridView dgv)
        {
            if (dgv.DataSource == null || dgv.Columns.Count == 0) return;

            dgv.Columns["SubscriberNumber"].HeaderText = "Номер абонента";
            dgv.Columns["SubscriberNumber"].Visible = false; // Уже в заголовке вкладки
            dgv.Columns["SubscriberFullName"].HeaderText = "ФИО абонента";
            dgv.Columns["SubscriberFullName"].Visible = false; // Уже в заголовке вкладки
            dgv.Columns["Type"].HeaderText = "Тип вызова";
            dgv.Columns["CorrespondentNumber"].HeaderText = "Номер собеседника";
            dgv.Columns["CallDate"].HeaderText = "Дата звонка";
            dgv.Columns["CallTime"].HeaderText = "Время звонка";
            dgv.Columns["Duration"].HeaderText = "Продолжительность";
            dgv.Columns["TariffPerMinute"].HeaderText = "Тариф (мин)";

            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }

    // Класс для хранения данных отчета по одному абоненту
    public class SubscriberReportData
    {
        public List<Call> Calls { get; set; }
        public TimeSpan TotalIncomingDuration { get; set; }
        public TimeSpan TotalOutgoingDuration { get; set; }
        public decimal TotalOutgoingCost { get; set; }

        public SubscriberReportData()
        {
            Calls = new List<Call>();
        }
    }
}