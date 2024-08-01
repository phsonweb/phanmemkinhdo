using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhanMemKinhDoMienBac
{
    public partial class DangKi : Form
    {
        public DangKi()
        {
            InitializeComponent();
            List<string> data = new List<string>
        {
            "admin",
            "user",
        };
            // Thêm dữ liệu vào ComboBox
            cbRole.Items.AddRange(data.ToArray());
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            string userName = txtSoDienThoai.Text;
            string password = txtPassword.Text;
            string hovaten = txtHoVaTen.Text;
            string diachi = txtDiaChi.Text;
            int sodienthoai = int.Parse(txtSoDienThoai.Text);
            string role = cbRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            AddUserToDatabase(userName, password, role, hovaten, diachi, sodienthoai);
        }

        private void AddUserToDatabase(string userName, string password, string role, string hovaten, string diachi, int sodienthoai)
        {
            string connectionString = @"Data Source=MSI\MAY1;Initial Catalog=PhanMemKinhDoMienBac;Integrated Security=True"; // Chuỗi kết nối tới cơ sở dữ liệu
            string query = "INSERT INTO Users (UserName, Password, Role,HoVaTen,DiaChi,SoDienThoai) VALUES (@userName, @pass, @role,@hovaten,@diachi,@sodienthoai)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@pass", password);
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@hovaten", hovaten);
                    command.Parameters.AddWithValue("@diachi", diachi);
                    command.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("User added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error adding user.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                Application.Exit();
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (!long.TryParse(txtSoDienThoai.Text, out _))
            {
                lbValidSoDienThoai.Text = "Phone number must be numeric.";
                btnThem.Enabled = false;

            }
            else
            {
                lbValidSoDienThoai.Text = string.Empty;
                btnThem.Enabled = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                lbValidEmail.Text = "Invalid email address.";
                btnThem.Enabled = false;
            }
            else
            {
                lbValidEmail.Text = string.Empty;
                btnThem.Enabled = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
