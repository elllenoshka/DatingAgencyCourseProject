using DatingAgency.ApiClients;
using DatingAgency.Dtos;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatingAgency
{
    public partial class ScheduleMeetingForm : Form
    {
        private readonly MeetingApiClient meetingApiClient = new MeetingApiClient();

        private readonly int selectedMatchId;

        public ScheduleMeetingForm()
        {
            InitializeComponent();

            ConfigureDesign();

            selectedMatchId = -1;

            Load += ScheduleMeetingForm_Load;
        }

        public ScheduleMeetingForm(int matchId)
        {
            InitializeComponent();

            ConfigureDesign();

            selectedMatchId = matchId;

            Load += ScheduleMeetingForm_Load;
        }

        private void ConfigureDesign()
        {
            panel1.BackColor = Color.FromArgb(190, Color.White);

            savemeet.FlatStyle = FlatStyle.Flat;
            savemeet.FlatAppearance.BorderSize = 0;
            savemeet.BackColor = Color.MistyRose;
            savemeet.ForeColor = Color.Black;
        }

        private async void ScheduleMeetingForm_Load(object sender, EventArgs e)
        {
            Text = "Організація зустрічі";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            datetime.Format = DateTimePickerFormat.Custom;
            datetime.CustomFormat = "dd.MM.yyyy HH:mm";
            datetime.ShowUpDown = true;

            SetupGrid(dvdcustomer);
            SetupGrid(dvdcandidate);

            LoadComboBoxes();

            if (selectedMatchId == -1)
            {
                MessageBox.Show("Не обрано пару для організації зустрічі.");
                Close();
                return;
            }

            await LoadDataAsync();
        }

        private void LoadComboBoxes()
        {
            formatC.Items.Clear();
            formatC.Items.Add("Офлайн");
            formatC.Items.Add("Онлайн");

            resultC.Items.Clear();
            resultC.Items.Add("Заплановано");
            resultC.Items.Add("Проведено");
            resultC.Items.Add("Скасовано");
            resultC.Items.Add("Перенесено");

            formatC.SelectedIndex = 0;
            resultC.SelectedIndex = 0;
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
                dvdcustomer.DataSource =
                    await meetingApiClient.GetSelectedMatchAsync(selectedMatchId);

                dvdcandidate.DataSource =
                    await meetingApiClient.GetMeetingsForMatchAsync(selectedMatchId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка завантаження даних з сервера. Перевірте, чи запущений DatingAgencyServer.\n\n" +
                    "Деталі помилки: " + ex.Message
                );
            }
        }

        private async void savemeet_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = datetime.Value;
            string format = formatC.SelectedItem?.ToString();
            string location = locationT.Text.Trim();
            string result = resultC.SelectedItem?.ToString();
            string notes = notesT.Text.Trim();

            if (string.IsNullOrWhiteSpace(format) ||
                string.IsNullOrWhiteSpace(location) ||
                string.IsNullOrWhiteSpace(result) ||
                string.IsNullOrWhiteSpace(notes))
            {
                MessageBox.Show("Заповніть формат, місце, статус і примітки.");
                return;
            }

            CreateMeetingRequestDto request = new CreateMeetingRequestDto
            {
                MatchId = selectedMatchId,
                EmployeeId = CurrentUser.UserId == 0 ? (int?)null : CurrentUser.UserId,
                MeetingDate = selectedDateTime,
                Format = format,
                Location = location,
                Result = result,
                Notes = notes
            };

            try
            {
                savemeet.Enabled = false;

                ApiResponseDto response =
                    await meetingApiClient.CreateMeetingAsync(request);

                MessageBox.Show(response.Message);

                if (!response.Success)
                {
                    return;
                }

                await LoadDataAsync();

                locationT.Clear();
                notesT.Clear();
                formatC.SelectedIndex = 0;
                resultC.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка створення зустрічі через сервер: " + ex.Message);
            }
            finally
            {
                savemeet.Enabled = true;
            }
        }
    }
}