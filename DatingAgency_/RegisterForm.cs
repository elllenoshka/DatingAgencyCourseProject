using DatingAgency.ApiClients;
using DatingAgency.Dtos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DatingAgency
{
    public partial class RegisterForm : Form
    {
        private readonly ClientApiClient clientApiClient = new ClientApiClient();

        public RegisterForm()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(190, Color.White);
            panel1.Location = new Point(
                (ClientSize.Width - panel1.Width) / 2,
                (ClientSize.Height - panel1.Height) / 2
            );

            Load += RegisterForm_Load;
        }

        private async void register_Click(object sender, EventArgs e)
        {
            string fullName = nametxt.Text.Trim();
            string gender = genderC.SelectedItem?.ToString();
            int age = (int)ageA.Value;
            int height = (int)heightT.Value;
            string city = cityC.SelectedItem?.ToString();
            string education = educationC.SelectedItem?.ToString();
            string occupation = occupationT.Text.Trim();
            string interests = interestsT.Text.Trim();
            string aboutMe = aboutMeT.Text.Trim();
            string emailValue = email.Text.Trim();
            string password = passwrd.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(education) ||
                string.IsNullOrWhiteSpace(occupation) ||
                string.IsNullOrWhiteSpace(interests) ||
                string.IsNullOrWhiteSpace(aboutMe) ||
                string.IsNullOrWhiteSpace(emailValue) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            if (age < 18)
            {
                MessageBox.Show("Реєстрація доступна тільки від 18 років.");
                return;
            }

            if (height < 120 || height > 230)
            {
                MessageBox.Show("Некоректно вказаний зріст.");
                return;
            }

            RegisterClientRequestDto request = new RegisterClientRequestDto
            {
                FullName = fullName,
                Gender = gender,
                Age = age,
                Height = height,
                City = city,
                Education = education,
                Occupation = occupation,
                Interests = interests,
                AboutMe = aboutMe,
                Email = emailValue,
                Password = password
            };

            try
            {
                register.Enabled = false;

                RegisterClientResponseDto response =
                    await clientApiClient.RegisterClientAsync(request);

                if (!response.Success)
                {
                    MessageBox.Show(response.Message);
                    return;
                }

                MessageBox.Show(response.Message);

                Form1 loginForm = new Form1();
                loginForm.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не вдалося підключитися до сервера. Перевірте, чи запущений DatingAgencyServer.\n\n" +
                    "Деталі помилки: " + ex.Message
                );
            }
            finally
            {
                register.Enabled = true;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            genderC.Items.Clear();
            genderC.Items.Add("Чоловік");
            genderC.Items.Add("Жінка");

            cityC.Items.Clear();
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

            educationC.Items.Clear();
            educationC.Items.Add("Середня");
            educationC.Items.Add("Незакінчена вища");
            educationC.Items.Add("Вища");
            educationC.Items.Add("Магістр");

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Реєстрація";

            passwrd.UseSystemPasswordChar = true;

            register.FlatStyle = FlatStyle.Flat;
            register.FlatAppearance.BorderSize = 0;
            register.BackColor = Color.MistyRose;
            register.ForeColor = Color.Black;

            back.FlatStyle = FlatStyle.Flat;
            back.FlatAppearance.BorderSize = 0;
            back.BackColor = Color.WhiteSmoke;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            Close();
        }
    }
}