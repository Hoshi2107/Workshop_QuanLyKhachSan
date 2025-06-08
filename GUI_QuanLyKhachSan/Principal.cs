using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyKhachSan
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNhanVien());

        }
        private Form currentFormChild;

        private void openChildForm(Form formChild)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            guna2Panel_container.Controls.Add(formChild);
            guna2Panel_container.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();


        }
        private void container(object _form)
        {



        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmQuanLyDatPhong());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            openChildForm(new LoaiDichVu());
        }

        private void guna2Panel_container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmQuanLyKhachHang());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmQuanLyPhong());
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
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

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận đăng xuất tài khoản?",
                                                 "Đăng xuất",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new fromDichVu());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            openChildForm(new ChiTietDichVu());
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            openChildForm(new LoaiPhong());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            openChildForm(new TrangThaiDatphong());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            openChildForm(new LoaiTrangThaiDatphong());
        }
    }
}
