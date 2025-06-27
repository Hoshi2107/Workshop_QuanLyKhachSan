using BLL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
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
            cboMaNv.DataSource = bllNhanVien.GetNhanVienList();
            cboMaNv.DisplayMember = "HoTen";
            cboMaNv.ValueMember = "MaNV";
            BusPhong bllPhong = new BusPhong();
            cboIDPhong.DataSource = bllPhong.GetPhongList();
            cboIDPhong.DisplayMember = "TenPhong";
            cboIDPhong.ValueMember = "MaPhong";
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
            txtHoaDonTheoID.Text = row.Cells["MaHoaDonThue"].Value.ToString();
            cboKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
            cboIDPhong.Text = row.Cells["MaPhong"].Value.ToString();
            dtpNgayDen.Value = Convert.ToDateTime(row.Cells["NgayDen"].Value);
            dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);
            cboMaNv.Text = row.Cells["MaNV"].Value.ToString();


            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            LoadDanhSachDatPhong();
        }

        private void LamMoiForm()
        {
            txtHoaDonTheoID.Clear(); // TextBox
            txtGhiChu.Clear();

            // ComboBox
            cboKhachHang.SelectedIndex = -1;
            cboIDPhong.SelectedIndex = -1;
            cboMaNv.SelectedIndex = -1;

            // DateTimePicker
            dtpNgayDen.Value = DateTime.Now;
            dtpNgayDi.Value = DateTime.Now.AddDays(1);

            // Xóa chọn dòng trong DataGridView
            guna2DgvDatPhong.ClearSelection();
        }

    }
}
