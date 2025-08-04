using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyKhachSan
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            //frmMainForm _load = new frmMainForm();
            //_load.Show();
            string user = txttennguoidung.Text.Trim();
            string pass = txtmatkhau.Text.Trim();

            //DTO_NhanVien nhanVien = DAL_NhanVien.CheckLogin(user, pass);
            DAL_NhanVien dal = new DAL_NhanVien();
            DTO_NhanVien nhanVien = dal.GetNhanVien1(user, pass);

            if (nhanVien != null)
            {
                frmMainForm main = new frmMainForm(nhanVien);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thoát chương trình?",
                                      "Thoát",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
