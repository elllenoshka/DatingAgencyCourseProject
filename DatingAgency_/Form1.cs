using DatingAgency.ApiClients;
using DatingAgency.Dtos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DatingAgency
{
    public partial class Form1 : Form
    {
        private readonly AuthApiClient authApiClient = new AuthApiClient();

        public Form1()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(180, Color.White);
            panel1.Location = new Point(
                (ClientSize.Width - panel1.Width) / 2,
                (ClientSize.Height - panel1.Height) / 2
            );

            passwrd.UseSystemPasswordChar = true;
        }

        private async void log_Click(object sender, EventArgs e)
        {
            string userEmail = email.Text.Trim();
            string userPassword = passwrd.Text.Trim();

            if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(userPassword))
            {
                MessageBox.Show("Введіть email та пароль.");
                return;
            }

            try
            {
                log.Enabled = false;

                LoginResponseDto response = await authApiClient.LoginAsync(userEmail, userPassword);

                if (!response.Success)
                {
                    MessageBox.Show(response.Message);
                    return;
                }

                CurrentUser.UserId = response.UserId ?? 0;
                CurrentUser.FullName = response.FullName;
                CurrentUser.RoleName = response.RoleName;

                MessageBox.Show($"Ласкаво просимо, {response.FullName}!");

                OpenFormByRole(response.RoleName);
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
                log.Enabled = true;
            }
        }

        private void OpenFormByRole(string roleName)
        {
            if (roleName == "Administrator")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
            }
            else if (roleName == "Employee")
            {
                EmployeeForm employeeForm = new EmployeeForm();
                employeeForm.Show();
            }
            else if (roleName == "Client")
            {
                CustomerForm customerForm = new CustomerForm();
                customerForm.Show();
            }
            else
            {
                MessageBox.Show("Для цієї ролі не налаштовано форму.");
                return;
            }

            Hide();
        }

        private void reg_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            Hide();
        }
    }
}