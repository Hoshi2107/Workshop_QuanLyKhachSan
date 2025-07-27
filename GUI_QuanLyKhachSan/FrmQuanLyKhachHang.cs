using BLL_QuanLyKhachSan;
using DAL_QuanLyKhachSan;
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
    public partial class FrmQuanLyKhachHang : Form
    {
        public FrmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void gnDgv_KhachHang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gnDgv_KhachHang.Rows[e.RowIndex];
            txtIDKhachHang.Text = row.Cells["KhachHangID"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            txtGioiTInh.Text = row.Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
            dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rdoTrue.Checked = true;
            }
            else
            {
                rdoFalse.Checked = true;
            }
            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();




        }

        //private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        //{
        //    LoadDanhSachKhachHang();
        //}
        private void LoadDanhSachKhachHang()
        {
            BLL_QuanLyKhachSan.BusKhachHang busKhachHang = new BLL_QuanLyKhachSan.BusKhachHang();
            gnDgv_KhachHang.DataSource = busKhachHang.GetKhachHangList();
        }

        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
            ClearForm();
        }
        private void ClearForm()
        {
            txtIDKhachHang.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtGioiTInh.Clear();
            txtSDT.Clear();
            dtpNgayTao.Value = DateTime.Now;
            rdoTrue.Checked = false;
            rdoFalse.Checked = false;
            txtGhiChu.Clear();
            txtCCCD.Clear();
            txtIDKhachHang.Enabled = false;
        }


        private void gnDgv_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maKhachHang = txtIDKhachHang.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = txtGioiTInh.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi) ||
                string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            KhachHang khachHang = new KhachHang
            {
                KhachHangID = maKhachHang,
                HoTen = hoTen,
                DiaChi = diaChi,
                GioiTinh = gioiTinh,
                SoDienThoai = soDienThoai,
                NgayTao = dtpNgayTao.Value,
                TrangThai = rdoTrue.Checked,
                GhiChu = txtGhiChu.Text.Trim(),
                CCCD = cccd
            };
            BusKhachHang busKhachHang = new BusKhachHang();
            string result = busKhachHang.insertKhachHang(khachHang);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadDanhSachKhachHang();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKhachHang = txtIDKhachHang.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = txtGioiTInh.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi) ||
                string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            KhachHang khachHang = new KhachHang
            {
                KhachHangID = maKhachHang,
                HoTen = hoTen,
                DiaChi = diaChi,
                GioiTinh = gioiTinh,
                SoDienThoai = soDienThoai,
                NgayTao = dtpNgayTao.Value,
                TrangThai = rdoTrue.Checked,
                GhiChu = txtGhiChu.Text.Trim(),
                CCCD = cccd
            };
            BusKhachHang busKhachHang = new BusKhachHang();
            string result = busKhachHang.UpdateKhachHang(khachHang);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật khách hàng thành công!");
                LoadDanhSachKhachHang();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gnDgv_KhachHang.SelectedRows.Count > 0)
            {
                // Lấy mã nhân viên từ dòng đang chọn
                string maKhachHang = gnDgv_KhachHang.SelectedRows[0].Cells["KhachHangID"].Value.ToString();

                // Gọi hàm xóa trong BUS
                BusKhachHang busKh = new BusKhachHang();
                string result = busKh.deletekhachhang(maKhachHang);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDanhSachKhachHang(); // load lại danh sách sau khi xóa
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachKhachHang();
            }
            else
            {
                TimKiemKhachHangID(keyword);
            }

        }
        private void TimKiemKhachHangID(string keyword)
        {
            BusKhachHang bUSKH = new BusKhachHang();

            gnDgv_KhachHang.DataSource = bUSKH.TimKiem(keyword);
        }

    }
}
