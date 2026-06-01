using DatingAgency.ApiClients;
using DatingAgency.Dtos;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatingAgency
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerApiClient customerApiClient = new CustomerApiClient();

        public CustomerForm()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(190, Color.White);

            Load += CustomerForm_Load;
        }

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            Text = "Кабінет клієнта";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            AutoScroll = true;
            ClientSize = new Size(1000, 410);

            SetupGrid(partner);
            LoadComboBoxes();

            await LoadAllPartnersAsync();
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

        private void LoadComboBoxes()
        {
            cityC.Items.Clear();
            cityC.Items.Add("Усі міста");
            cityC.Items.Add("Харків");
            cityC.Items.Add("Київ");
            cityC.Items.Add("Львів");
            cityC.Items.Add("Одеса");
            cityC.Items.Add("Дніпро");
            cityC.Items.Add("Запоріжжя");
            cityC.Items.Add("Полтава");
            cityC.Items.Add("Суми");
            cityC.Items.Add("Чернігів");
            cityC.Items.Add("Черкаси");
            cityC.Items.Add("Вінниця");
            cityC.Items.Add("Житомир");
            cityC.Items.Add("Рівне");
            cityC.Items.Add("Луцьк");
            cityC.Items.Add("Тернопіль");
            cityC.Items.Add("Івано-Франківськ");
            cityC.Items.Add("Ужгород");
            cityC.Items.Add("Чернівці");
            cityC.Items.Add("Хмельницький");
            cityC.Items.Add("Миколаїв");
            cityC.SelectedIndex = 0;

            educationC.Items.Clear();
            educationC.Items.Add("Будь-яка");
            educationC.Items.Add("Середня");
            educationC.Items.Add("Незакінчена вища");
            educationC.Items.Add("Вища");
            educationC.Items.Add("Магістр");
            educationC.SelectedIndex = 0;
        }

        private async Task LoadAllPartnersAsync()
        {
            try
            {
                partner.DataSource = await customerApiClient.GetAllPartnersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка завантаження партнерів з сервера. Перевірте, чи запущений DatingAgencyServer.\n\n" +
                    "Деталі помилки: " + ex.Message
                );
            }
        }

        private async void filter_Click(object sender, EventArgs e)
        {
            int ageMin = (int)agemin.Value;
            int ageMax = (int)agemax.Value;
            int heightMin = (int)heightmin.Value;
            int heightMax = (int)heightmax.Value;

            string city = cityC.SelectedItem?.ToString();
            string education = educationC.SelectedItem?.ToString();

            if (ageMin > 0 && ageMax > 0 && ageMin > ageMax)
            {
                MessageBox.Show("Мінімальний вік не може бути більшим за максимальний.");
                return;
            }

            if (heightMin > 0 && heightMax > 0 && heightMin > heightMax)
            {
                MessageBox.Show("Мінімальний зріст не може бути більшим за максимальний.");
                return;
            }

            PartnerFilterRequestDto filter = new PartnerFilterRequestDto
            {
                AgeMin = ageMin,
                AgeMax = ageMax,
                HeightMin = heightMin,
                HeightMax = heightMax,
                City = city,
                Education = education
            };

            try
            {
                this.filter.Enabled = false;

                partner.DataSource = await customerApiClient.FilterPartnersAsync(filter);

                if (partner.Rows.Count == 0)
                {
                    MessageBox.Show("Немає партнерів, які відповідають заданим критеріям.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка пошуку партнерів через сервер: " + ex.Message);
            }
            finally
            {
                this.filter.Enabled = true;
            }
        }

        private async void showAllCandidates_Click(object sender, EventArgs e)
        {
            await LoadAllPartnersAsync();
            MessageBox.Show("Список партнерів оновлено.");
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            Close();
        }
    }
}