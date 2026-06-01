using DatingAgency.ApiClients;
using DatingAgency.Dtos;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatingAgency
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeApiClient employeeApiClient = new EmployeeApiClient();

        public EmployeeForm()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(190, Color.White);

            createMatch.Click -= createMatch_Click;
            createMatch.Click += createMatch_Click;

            Load += EmployeeForm_Load;
        }

        private async void EmployeeForm_Load(object sender, EventArgs e)
        {
            Text = "Панель працівника";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            AutoScroll = true;
            ClientSize = new Size(1050, 700);

            SetupGrid(candidate);
            SetupGrid(customer);
            SetupGrid(meetings);

            await LoadDataAsync();
        }

        private void SetupGrid(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            grid.BackgroundColor = Color.White;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = Color.MistyRose;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.EnableHeadersVisualStyles = false;

            grid.RowHeadersWidth = 35;
        }

        private async Task LoadDataAsync()
        {
            try
            {
                candidate.DataSource = await employeeApiClient.GetMatchesAsync();
                customer.DataSource = await employeeApiClient.GetClientsAsync();
                meetings.DataSource = await employeeApiClient.GetMeetingsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка завантаження даних з сервера. Перевірте, чи запущений DatingAgencyServer.\n\n" +
                    "Деталі помилки: " + ex.Message
                );
            }
        }

        private async void addcustomer_Click(object sender, EventArgs e)
        {
            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }

            await LoadDataAsync();
        }

        private async void createMatch_Click(object sender, EventArgs e)
        {
            if (customer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть клієнта у таблиці клієнтів.");
                return;
            }

            int selectedClientId =
                Convert.ToInt32(customer.SelectedRows[0].Cells["ClientProfileId"].Value);

            try
            {
                createMatch.Enabled = false;

                CreateMatchResponseDto response =
                    await employeeApiClient.CreateMatchAsync(selectedClientId);

                if (!response.Success)
                {
                    MessageBox.Show(response.Message);
                    return;
                }

                MessageBox.Show(
                    $"{response.Message}\n\n" +
                    $"Підібраний партнер: {response.PartnerName}\n" +
                    $"Сумісність: {response.CompatibilityScore}%\n\n" +
                    $"Розрахунок:\n{response.Explanation}"
                );

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка створення пари через сервер: " + ex.Message);
            }
            finally
            {
                createMatch.Enabled = true;
            }
        }

        private async void meeting_Click(object sender, EventArgs e)
        {
            if (candidate.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть пару у таблиці пар для організації зустрічі.");
                return;
            }

            int matchId =
                Convert.ToInt32(candidate.SelectedRows[0].Cells["MatchId"].Value);

            ScheduleMeetingForm scheduleMeetingForm = new ScheduleMeetingForm(matchId);
            scheduleMeetingForm.ShowDialog();

            await LoadDataAsync();
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MessageBox.Show("Дані оновлено.");
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            Close();
        }
    }
}