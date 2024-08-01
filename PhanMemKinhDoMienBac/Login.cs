using PhanMemKinhDoMienBac.Class;
using System;
using System.Windows.Forms;

namespace PhanMemKinhDoMienBac
{
    public partial class Login : Form
    {



        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string username = txtDangNhap.Text;
            string password = txtMatKhau.Text;
            if (AuthenticateUser(username, password))
            {
                Form1 mainForm = new Form1(username);

                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void cbAnMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbAnMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false; // Hiện mật khẩu
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            Connection con = new Connection();

            string query = "SELECT COUNT(*) AS SoLuong FROM Users WHERE UserName = '" + username + "'  AND Password =  '" + password + "' ";
            var reader = con.SelectSql(query);
            while (reader.Read())
            {
                var soLuong = reader["SoLuong"] as int? ?? default(int?);
                isAuthenticated = soLuong > 0;
            }

            return isAuthenticated;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                Application.Exit();
        }
    }
}
