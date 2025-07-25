using BLL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Devices;
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
            BusKhachHang bllKhachHang = new BusKhachHang();
            cboMaKhachHang.DataSource = bllKhachHang.GetKhachHangList();
            cboMaKhachHang.DisplayMember = "TenKhachHang";
            cboMaKhachHang.ValueMember = "MaKhachHang";


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
            cboMaKhachHang.SelectedIndex = -1;
            cboIDPhong.SelectedIndex = -1;
            cboMaNv.SelectedIndex = -1;
            dtpNgayDen.Value = DateTime.Now;
            dtpNgayDi.Value = DateTime.Now;
            txtGhiChu.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void guna2DgvDatPhong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DgvDatPhong.Rows[e.RowIndex];
            txtHoaDonTheoID.Text = row.Cells["HoaDonThueID"].Value.ToString();
            cboMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
            cboIDPhong.Text = row.Cells["MaPhong"].Value.ToString();
            dtpNgayDen.Value = Convert.ToDateTime(row.Cells["NgayDen"].Value);
            dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);
            cboMaNv.Text = row.Cells["MaNV"].Value.ToString();


            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string hoaDonID = txtHoaDonTheoID.Text.Trim();
            string khachHangID = cboMaKhachHang.Text.Trim();
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
            string hoaDonThueID = txtHoaDonTheoID.Text.Trim();
            string maKhachHang = cboMaKhachHang.Text.Trim();
            string maPhong = cboIDPhong.Text.Trim();
            string maNV = cboMaNv.SelectedValue?.ToString();
            DateTime ngayDen = dtpNgayDen.Value;
            DateTime ngayDi = dtpNgayDi.Value;
            string ghiChu = txtGhiChu.Text.Trim();

            if (string.IsNullOrEmpty(maKhachHang) || string.IsNullOrEmpty(maPhong) ||
                string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin đặt phòng!");
                return;
            }

            DatPhong datPhong = new DatPhong
            {
                HoaDonThueID = hoaDonThueID,
                MaKhachHang = maKhachHang,
                MaPhong = maPhong,
                MaNV = maNV,
                NgayDen = ngayDen,
                NgayDi = ngayDi,
                GhiChu = ghiChu
            };
            BusDatPhong busDatPhong = new BusDatPhong();
            string result = busDatPhong.updateDatPhong(datPhong);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật đặt phòng thành công!");
                LoadDanhSachDatPhong();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DgvDatPhong.SelectedRows.Count > 0)
            {
                string hoaDonThueID = guna2DgvDatPhong.SelectedRows[0].Cells["HoaDonThueID"].Value.ToString();
                BusDatPhong busDatPhong = new BusDatPhong();
                string result = busDatPhong.deleteDatPhong(new DatPhong { HoaDonThueID = hoaDonThueID });

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa đặt phòng thành công!");
                    LoadDanhSachDatPhong();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa: " + result);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDatPhong();
        }
        private void guna2DgvDatPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachDatPhong();
            }
            else
            {
                TimKiemKhachHangID(keyword);
            }
        }
        private void TimKiemKhachHangID(string keyword)
        {
            BusDatPhong bUSDP = new BusDatPhong();

            guna2DgvDatPhong.DataSource = bUSDP.TimKiem(keyword);
        }
    }
}
