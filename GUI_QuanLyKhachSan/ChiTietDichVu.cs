using BLL_QuanLyKhachSan;
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
    public partial class ChiTietDichVu : Form
    {
        public ChiTietDichVu()
        {
            InitializeComponent();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChiTietDichVu_Load(object sender, EventArgs e)
        {
            LoadchitetdichVu();
            loadCombobox();
            clearForm();
        }
        private void clearForm()
        {
            txtchitietdv.Clear();
            txtghichu.Clear();
            txtSoLuong.Clear();
            dtpngaybatdau.Value = DateTime.Now;
            dtpngayketthuc.Value = DateTime.Now;
            cbxDichVuID.SelectedIndex = -1;
            cbx_HoaDonThue.SelectedIndex = -1;
            cbx_LoaiDichVu.SelectedIndex = -1;
            txtchitietdv.Enabled = false;
        }
        private void loadCombobox()
        {
            BusDatPhong busDatPhong = new BusDatPhong();
            cbx_HoaDonThue.DataSource = busDatPhong.GetDatPhongList();
            cbx_HoaDonThue.DisplayMember = "HoaDonThueID";
            cbx_HoaDonThue.ValueMember = "HoaDonThueID";
            BUSDichVu bUSDichVu = new BUSDichVu();
            cbxDichVuID.DataSource = bUSDichVu.GetDichVuList();
            cbxDichVuID.DisplayMember = "TenDichVu";
            cbxDichVuID.ValueMember = "DichVuID";
            BUSLoaiDV bUSLoaiDichVu = new BUSLoaiDV();
            cbx_LoaiDichVu.DataSource = bUSLoaiDichVu.GetLoaiDVList();
            cbx_LoaiDichVu.DisplayMember = "TenLoaiDichVu";
            cbx_LoaiDichVu.ValueMember = "LoaiDichVuID";

        }
        private void LoadchitetdichVu()
        {
            BUSChiTietDV bUSchitietDichVu = new BUSChiTietDV();
            guna2DataGridView1.DataSource = bUSchitietDichVu.GetchitietDichVuList();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbx_HoaDonThue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txttimkiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadchitetdichVu();
            }
            else
            {
                TimKiemCT(keyword);
            }

        }
        private void TimKiemCT(string keyword)
        {

            BUSChiTietDV bUSChiTietDichVu = new BUSChiTietDV();
            guna2DataGridView1.DataSource = bUSChiTietDichVu.TimKiem(keyword);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string CT = txtchitietdv.Text.Trim();
            string dichVuID = cbxDichVuID.SelectedValue.ToString();
            string hoaDonThueID = cbx_HoaDonThue.SelectedValue.ToString();
            string loaiDichVuID = cbx_LoaiDichVu.SelectedValue.ToString();
            int soLuong = int.Parse(txtSoLuong.Text.Trim());
            DateTime ngayBatDau = dtpngaybatdau.Value;
            DateTime ngayKetThuc = dtpngayketthuc.Value;
            string ghiChu = txtghichu.Text.Trim();
            if (string.IsNullOrEmpty(dichVuID) || string.IsNullOrEmpty(hoaDonThueID) || string.IsNullOrEmpty(loaiDichVuID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTO_ChiTietDichVu chiTietDichVu = new DTO_ChiTietDichVu
            {
                ChiTietDichVuID = CT,
                DichVuID = dichVuID,
                HoaDonThueID = hoaDonThueID,
                LoaiDichVuID = loaiDichVuID,
                SoLuong = soLuong,
                NgayBatDau = ngayBatDau,
                NgayKetThuc = ngayKetThuc,
                GhiChu = ghiChu
            };
            BUSChiTietDV bUSChiTietDichVu = new BUSChiTietDV();
            string result = bUSChiTietDichVu.insertCT(chiTietDichVu);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm chi tiết dịch vụ thành công!");
                LoadchitetdichVu();
                clearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string CT = txtchitietdv.Text.Trim();
            string dichVuID = cbxDichVuID.SelectedValue.ToString();
            string hoaDonThueID = cbx_HoaDonThue.SelectedValue.ToString();
            string loaiDichVuID = cbx_LoaiDichVu.SelectedValue.ToString();
            int soLuong = int.Parse(txtSoLuong.Text.Trim());
            DateTime ngayBatDau = dtpngaybatdau.Value;
            DateTime ngayKetThuc = dtpngayketthuc.Value;
            string ghiChu = txtghichu.Text.Trim();
            if (string.IsNullOrEmpty(dichVuID) || string.IsNullOrEmpty(hoaDonThueID) || string.IsNullOrEmpty(loaiDichVuID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTO_ChiTietDichVu chiTietDichVu = new DTO_ChiTietDichVu
            {
                ChiTietDichVuID = CT,
                DichVuID = dichVuID,
                HoaDonThueID = hoaDonThueID,
                LoaiDichVuID = loaiDichVuID,
                SoLuong = soLuong,
                NgayBatDau = ngayBatDau,
                NgayKetThuc = ngayKetThuc,
                GhiChu = ghiChu
            };
            BUSChiTietDV bUSChiTietDichVu = new BUSChiTietDV();
            string result = bUSChiTietDichVu.UpdateCT(chiTietDichVu);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật chi tiết dịch vụ thành công!");
                LoadchitetdichVu();
                clearForm();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã nhân viên từ dòng đang chọn
                string Ct = guna2DataGridView1.SelectedRows[0].Cells["ChiTietDichVuID"].Value.ToString();

                // Gọi hàm xóa trong BUS
                BUSChiTietDV busCT = new BUSChiTietDV();
                string result = busCT.deleteCT(Ct);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadchitetdichVu(); // load lại danh sách sau khi xóa
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

        private void guna2DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            txtchitietdv.Text = row.Cells["ChiTietDichVuID"].Value.ToString();
            cbx_HoaDonThue.SelectedValue = row.Cells["HoaDonThueID"].Value.ToString();
            cbxDichVuID.SelectedValue = row.Cells["DichVuID"].Value.ToString();
            cbx_LoaiDichVu.SelectedValue = row.Cells["LoaiDichVuID"].Value.ToString();
            txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            DateTime ngayBatDau = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
            DateTime ngayKetThuc = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
            txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
        }

        private void cbx_LoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}