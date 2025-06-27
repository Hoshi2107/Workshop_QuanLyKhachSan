using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BLL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
namespace GUI_QuanLyKhachSan
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            loadDanhSachNhanVien();
            ClearForm();
        }
        private void ClearForm()
        {
            txtmanv.Clear();
            txthoten.Clear();
            txtgioitinh.Clear();
            txtemail.Clear();
            txtdiachi.Clear();
            txtmatkhau.Clear();
            rdoquanly.Checked = false;
            rdonhanvien.Checked = false;
            rdoconhoatdong.Checked = false;
            rdongunghoatdong.Checked = false;
            txtmanv.Enabled = false;
        }
        private void guna2DgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadDanhSachNhanVien()
        {
            BLL_NhanVien bUSNhanVien = new BLL_NhanVien();
            guna2DgvNhanVien.DataSource = null;
            guna2DgvNhanVien.DataSource = bUSNhanVien.GetNhanViensList();
            guna2DgvNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            guna2DgvNhanVien.Columns["HoTen"].HeaderText = "Họ Và Tên";
            guna2DgvNhanVien.Columns["GioiTinh"].HeaderText = "Gioi Tinh";
            guna2DgvNhanVien.Columns["Email"].HeaderText = "Email";
            guna2DgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            guna2DgvNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
            guna2DgvNhanVien.Columns["VaiTroText"].HeaderText = "Vai Trò";
            guna2DgvNhanVien.Columns["TinhTrangText"].HeaderText = "Tình Trạng";
            guna2DgvNhanVien.Columns["vaiTro"].Visible = false;
            guna2DgvNhanVien.Columns["TinhTrang"].Visible = false;
            guna2DgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            string hoTen = txthoten.Text.Trim();
            string gioiTinh = txtgioitinh.Text.Trim();
            string email = txtemail.Text.Trim();
            string diaChi = txtdiachi.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();
            
            bool tinhTrang;
            if (rdoconhoatdong.Checked)
            {
                tinhTrang = true; // Hoạt động
            }
            else if (rdongunghoatdong.Checked)
            {
                tinhTrang = false; // Ngừng hoạt động
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tình trạng cho nhân viên.");
                return;
            }
            bool vaiTro;
            if (rdoquanly.Checked)
            {
                vaiTro = true; // Quản lý
            }
            else if (rdonhanvien.Checked)
            {
                vaiTro = false; // Nhân viên
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò cho nhân viên.");
                return;
            }
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(gioiTinh) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                return;
            }
           
            DTO_NhanVien nv = new DTO_NhanVien
            {
                 // Tự động sinh mã nhân viên
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                Email = email,
                DiaChi = diaChi,
                MatKhau = matKhau,
                TinhTrang = tinhTrang,
                VaiTro = vaiTro
                
            };
            BLL_NhanVien bUSNhanVien = new BLL_NhanVien();
            string result = bUSNhanVien.InsertNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm nhân viên thành công.");
                loadDanhSachNhanVien();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            

            string hoTen = txthoten.Text.Trim();
            string gioiTinh = txtgioitinh.Text.Trim();
            string email = txtemail.Text.Trim();
            string diaChi = txtdiachi.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();
            bool vaiTro;
            if (rdoquanly.Checked)
            {
                vaiTro = true; // Quản lý
            }
            else if (rdonhanvien.Checked)
            {
                vaiTro = false; // Nhân viên
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò cho nhân viên.");
                return;
            }
            bool tinhTrang;
            if (rdoconhoatdong.Checked)
            {
                tinhTrang = true; // Hoạt động
            }
            else if (rdongunghoatdong.Checked)
            {
                tinhTrang = false; // Ngừng hoạt động
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tình trạng cho nhân viên.");
                return;
            }
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(gioiTinh) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                return;
            }
            DTO_NhanVien nv = new DTO_NhanVien
            {
               
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                Email = email,
                DiaChi = diaChi,
                MatKhau = matKhau,
                VaiTro = vaiTro,
                TinhTrang = tinhTrang
            };
            BLL_NhanVien bUSNhanVien = new BLL_NhanVien();
            string result = bUSNhanVien.UpdateNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật nhân viên thành công.");
                loadDanhSachNhanVien();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }
    }
}
