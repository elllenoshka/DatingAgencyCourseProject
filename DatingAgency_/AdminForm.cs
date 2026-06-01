using DatingAgency.ApiClients;
using DatingAgency.Dtos;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatingAgency
{
    public partial class AdminForm : Form
    {
        private readonly AdminApiClient adminApiClient = new AdminApiClient();

        public AdminForm()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(190, Color.White);

            Load += AdminForm_Load;
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            Text = "Панель адміністратора";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            AutoScroll = true;
            ClientSize = new Size(1350, 1100);

            customer.MultiSelect = false;
            candidate.MultiSelect = false;

            SetupGrid(customer);
            SetupGrid(candidate);
            SetupGrid(meetings);
            SetupGrid(archive);
            SetupGrid(employeeDataGridView);

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
                customer.DataSource = await adminApiClient.GetClientsAsync();
                candidate.DataSource = await adminApiClient.GetMatchesAsync();
                meetings.DataSource = await adminApiClient.GetMeetingsAsync();
                archive.DataSource = await adminApiClient.GetArchiveAsync();
                employeeDataGridView.DataSource = await adminApiClient.GetEmployeesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка завантаження даних з сервера. Перевірте, чи запущений DatingAgencyServer.\n\n" +
                    "Деталі помилки: " + ex.Message
                );
            }
        }

        private async void btnShowAllData_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
            MessageBox.Show("Дані оновлено.");
        }

        private async void btnAddCandidate_Click(object sender, EventArgs e)
        {
            if (customer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть клієнта у першій таблиці.");
                return;
            }

            int selectedClientId =
                Convert.ToInt32(customer.SelectedRows[0].Cells["ClientProfileId"].Value);

            try
            {
                btnAddCandidate.Enabled = false;

                CreateMatchResponseDto response =
                    await adminApiClient.CreateMatchAsync(selectedClientId);

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
                btnAddCandidate.Enabled = true;
            }
        }

        private async void btnDeleteCandidate_Click(object sender, EventArgs e)
        {
            if (candidate.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть пару для видалення.");
                return;
            }

            int matchId =
                Convert.ToInt32(candidate.SelectedRows[0].Cells["MatchId"].Value);

            DialogResult result = MessageBox.Show(
                "Ви дійсно хочете видалити цю пару?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                btnDeleteCandidate.Enabled = false;

                ApiResponseDto response =
                    await adminApiClient.DeleteMatchAsync(matchId);

                MessageBox.Show(response.Message);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка видалення пари через сервер: " + ex.Message);
            }
            finally
            {
                btnDeleteCandidate.Enabled = true;
            }
        }

        private async void btnArchive_Click(object sender, EventArgs e)
        {
            if (candidate.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть пару для архівації.");
                return;
            }

            int matchId =
                Convert.ToInt32(candidate.SelectedRows[0].Cells["MatchId"].Value);

            try
            {
                btnArchive.Enabled = false;

                ApiResponseDto response =
                    await adminApiClient.ArchiveMatchAsync(matchId);

                MessageBox.Show(response.Message);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка архівації через сервер: " + ex.Message);
            }
            finally
            {
                btnArchive.Enabled = true;
            }
        }

        private async void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть працівника.");
                return;
            }

            int userId =
                Convert.ToInt32(employeeDataGridView.SelectedRows[0].Cells["UserId"].Value);

            bool isActive =
                Convert.ToBoolean(employeeDataGridView.SelectedRows[0].Cells["Активний"].Value);

            bool newStatus = !isActive;

            try
            {
                btnDeleteEmployee.Enabled = false;

                ApiResponseDto response =
                    await adminApiClient.SetEmployeeStatusAsync(userId, newStatus);

                MessageBox.Show(response.Message);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка зміни статусу працівника через сервер: " + ex.Message);
            }
            finally
            {
                btnDeleteEmployee.Enabled = true;
            }
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (AddEmployeeForm addEmployeeForm = new AddEmployeeForm())
            {
                if (addEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            Close();
        }
    }
}