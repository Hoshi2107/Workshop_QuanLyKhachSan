using BLL_QuanLyKhachSan;
using Guna.UI2.WinForms;
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
    public partial class FrmQuanLyDatPhong : Form
    {
        public FrmQuanLyDatPhong()
        {
            InitializeComponent();

        }

        private void FrmQuanLyDatPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachDatPhong();
            LoadComboBox();
        }
        private void LoadDanhSachDatPhong()
        {
            BusDatPhong bUSDatPhong = new BusDatPhong();
            guna2DgvDatPhong.DataSource = bUSDatPhong.GetDatPhongList();

        }
        private void LoadComboBox()
        {
            BLL_NhanVien bllNhanVien = new BLL_NhanVien();
            gnCbo_MaNV.DataSource = bllNhanVien.GetNhanVienList();
            gnCbo_MaNV.DisplayMember = "HoTen";
            gnCbo_MaNV.ValueMember = "MaNV";
            BusPhong bllPhong = new BusPhong();
            gnCbo_PhongID.DataSource = bllPhong.GetPhongList();
            gnCbo_PhongID.DisplayMember = "TenPhong";
            gnCbo_PhongID.ValueMember = "MaPhong";
        }


        private void guna2DgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DgvDatPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DgvDatPhong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DgvDatPhong.Rows[e.RowIndex];
            gnTxt_HoaDonTheoID.Text = row.Cells["MaHoaDonThue"].Value.ToString();
            gnCbo_KhachHangID.Text = row.Cells["MaKhachHang"].Value.ToString();
            gnCbo_PhongID.Text = row.Cells["MaPhong"].Value.ToString();
            gnDtp_NgayDen.Value = Convert.ToDateTime(row.Cells["NgayDen"].Value);
            gnDtp_NgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);
            gnCbo_MaNV.Text = row.Cells["MaNV"].Value.ToString();
            
            
            gnTxt_GhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            
        }
    }
}
