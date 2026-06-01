using DatingAgency.ApiClients;
using DatingAgency.Dtos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DatingAgency
{
    public partial class AddEmployeeForm : Form
    {
        private readonly AdminApiClient adminApiClient = new AdminApiClient();

        public AddEmployeeForm()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(190, Color.White);

            Load += AddEmployeeForm_Load;
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            Text = "Додавання працівника";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            txtPassword.UseSystemPasswordChar = true;

            roleemployeer.Items.Clear();
            roleemployeer.Items.Add("Менеджер");
            roleemployeer.Items.Add("Консультант");

            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = Color.MistyRose;
            btnSave.ForeColor = Color.Black;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string position = roleemployeer.SelectedItem?.ToString();
            string phone = phoneT.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(position) ||
                string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            AddEmployeeRequestDto request = new AddEmployeeRequestDto
            {
                FullName = fullName,
                Email = email,
                Password = password,
                Phone = phone,
                Position = position
            };

            try
            {
                btnSave.Enabled = false;

                ApiResponseDto response =
                    await adminApiClient.AddEmployeeAsync(request);

                MessageBox.Show(response.Message);

                if (!response.Success)
                {
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка додавання працівника через сервер. Перевірте, чи запущений DatingAgencyServer.\n\n" +
                    "Деталі помилки: " + ex.Message
                );
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}