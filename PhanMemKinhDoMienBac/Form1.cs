using PhanMemKinhDoMienBac.Class;
using System;
using System.Windows.Forms;

namespace PhanMemKinhDoMienBac
{
    public partial class Form1 : Form
    {
        private string currentUser;
        public Form1(string username)
        {
            InitializeComponent();
            currentUser = username;
            LoadUserPermissions();
            QuanLi ql = new QuanLi();
            openChildForm(ql);

        }

        private Form currentFormchild;

        private void openChildForm(Form formchild)
        {
            currentFormchild?.Close();
            currentFormchild = formchild;
            formchild.TopLevel = false;
            formchild.FormBorderStyle = FormBorderStyle.None;
            formchild.Dock = DockStyle.Fill;
            pnBody.Controls.Add(formchild);
            pnBody.Tag = formchild;
            formchild.BringToFront();
            formchild.Show();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void standardControl10_Load(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                Application.Exit();
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLi());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            openChildForm(new BaoCao());
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void LoadUserPermissions()
        {
            Connection con = new Connection();
            string query = "SELECT Role FROM Users WHERE UserName = '" + currentUser + "'";
            var reader = con.SelectSql(query);
            while (reader.Read())
            {
                var role = (string)reader["Role"];
                // Thiết lập quyền dựa trên vai trò
                SetPermissions(role);
            }



        }

        private void SetPermissions(string role)
        {
            switch (role)
            {
                case "admin":
                    btnBaoCao.Visible = false;
                    btnTaiKhoan.Visible = true;
                    break;
                case "user":
                    // Cấp quyền User
                    btnBaoCao.Visible = false;

                    break;
                default:
                    // Không cấp quyền
                    btnBaoCao.Visible = false;
                    btnQuanLy.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new DangKi());
        }
    }
}
