using BLL_QuanLyKhachSan;
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
    public partial class LoaiTrangThaiDatphong : Form
    {
        public LoaiTrangThaiDatphong()
        {
            InitializeComponent();
        }

        private void LoadLoaiTrangThaiDatPhong()
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
        private void LoaiTrangThaiDatphong_Load(object sender, EventArgs e)
        {
            
        }
    }
}
