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
        private void LoadNewKhachHangID()
        {
            BusKhachHang busKhachHang = new BusKhachHang();
            txtMaKhachHang.Text = busKhachHang.GenerateNewKhachHangID();
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
        private void ClearForm()
        {
            txtHoaDonTheoID.Clear();
            txtMaKhachHang.Clear();
            cboIDPhong.SelectedIndex = -1;
            cboMaNv.SelectedIndex = -1;
            dtpNgayDen.Value = DateTime.Now;
            dtpNgayDi.Value = DateTime.Now;
            txtGhiChu.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtHoaDonTheoID.Enabled = false;  
        }

        private void guna2DgvDatPhong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DgvDatPhong.Rows[e.RowIndex];
            txtHoaDonTheoID.Text = row.Cells["MaHoaDonThue"].Value.ToString();
            txtMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
            cboIDPhong.Text = row.Cells["MaPhong"].Value.ToString();
            dtpNgayDen.Value = Convert.ToDateTime(row.Cells["NgayDen"].Value);
            dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);
            cboMaNv.Text = row.Cells["MaNV"].Value.ToString();


            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string hoaDonID = txtHoaDonTheoID.Text.Trim();
            string khachHangID = txtMaKhachHang.Text.Trim();
            string phongID = cboIDPhong.SelectedValue?.ToString();
            string nhanVienID = cboMaNv.SelectedValue?.ToString();
            DateTime ngayDen = dtpNgayDen.Value;
            DateTime ngayDi = dtpNgayDi.Value;
            string ghiChu = txtGhiChu.Text.Trim();

            if (string.IsNullOrEmpty(khachHangID) || string.IsNullOrEmpty(phongID) || string.IsNullOrEmpty(nhanVienID))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!");
                return;
            }

            DatPhong dp = new DatPhong
            {
                HoaDonThueID = hoaDonID,
                MaKhachHang = khachHangID,
                MaPhong = phongID,
                MaNV = nhanVienID,
                NgayDen = ngayDen,
                NgayDi = ngayDi,
                GhiChu = ghiChu
            };

            BusDatPhong bus = new BusDatPhong();
            string result = bus.insertDatPhong(dp);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm đặt phòng thành công!");
                LoadDanhSachDatPhong();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDatPhong();
        }
        private void guna2DgvDatPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
