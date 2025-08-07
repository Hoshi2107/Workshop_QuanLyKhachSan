using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;

namespace GUI_QuanLyKhachSan
{
    public partial class TrangThaiDatphong : Form
    {

        public TrangThaiDatphong()
        {
            InitializeComponent();
        }
        private void TrangThaiDatPhong_Load(object sender, EventArgs e)
        {


        }

        private void LoadTrangThaiDatPhong()
        {
            BLLTrangThaiDatPhong bllTrangThai = new BLLTrangThaiDatPhong();




            dgvTrangThaiDatPhong.DataSource = bllTrangThai.GetAllTrangThai();

        }

        private void dgvTrangThaiDatPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTrangThaiDatPhong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dgvTrangThaiDatPhong.Rows[e.RowIndex];
            gntxtTrangThaiID.Text = row.Cells["TrangThaiID"].Value.ToString();
            gnCbo_HoaDonThueID.Text = row.Cells["HoaDonThueID"].Value.ToString();
            gnCbo_LoaiTrangThaiID.Text = row.Cells["LoaiTrangThaiID"].Value.ToString();
            gnDtpNgayCapNhat.Value = Convert.ToDateTime(row.Cells["NgayCapNhat"].Value);

        }

        private void TrangThaiDatphong_Load_1(object sender, EventArgs e)
        {
            LoadTrangThaiDatPhong();
            LoadCombobox();
            ClearForm();
        }
        private void ClearForm()
        {
            gntxtTrangThaiID.Clear();
            gnCbo_HoaDonThueID.SelectedIndex = -1;
            gnCbo_LoaiTrangThaiID.SelectedIndex = -1;
            gnDtpNgayCapNhat.Value = DateTime.Now;
            gntxtTrangThaiID.Enabled = true;
            gntxtTrangThaiID.Enabled = false;
        }
        private void LoadCombobox()
        {
            BUSLoaiTrangThaiDatPhong bllLoaiTrangThai = new BUSLoaiTrangThaiDatPhong();
            gnCbo_LoaiTrangThaiID.DataSource = bllLoaiTrangThai.GetLoaiTrangThaiDatPhongList();
            gnCbo_LoaiTrangThaiID.DisplayMember = "TenLoai";
            gnCbo_LoaiTrangThaiID.ValueMember = "LoaiTrangThaiID";
            BusDatPhong busDatPhong = new BusDatPhong();
            gnCbo_HoaDonThueID.DataSource = busDatPhong.GetDatPhongList();
            gnCbo_HoaDonThueID.DisplayMember = "HoaDonThueID";
            gnCbo_HoaDonThueID.ValueMember = "HoaDonThueID";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string trangThaiID = gntxtTrangThaiID.Text.Trim();
            string hoaDonThueID = gnCbo_HoaDonThueID.SelectedValue.ToString();
            string loaiTrangThaiID = gnCbo_LoaiTrangThaiID.SelectedValue.ToString();
            DateTime ngayCapNhat = gnDtpNgayCapNhat.Value;
            if (string.IsNullOrEmpty(hoaDonThueID) || string.IsNullOrEmpty(loaiTrangThaiID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            DTO_TrangThaiDatPhong trangThaiDatPhong = new DTO_TrangThaiDatPhong
            {
                TrangThaiID = trangThaiID,
                HoaDonThueID = hoaDonThueID,
                LoaiTrangThaiID = loaiTrangThaiID,
                NgayCapNhat = ngayCapNhat
            };
            BLLTrangThaiDatPhong bllTrangThai = new BLLTrangThaiDatPhong();
            string result = bllTrangThai.insertTrangThai(trangThaiDatPhong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm trạng thái đặt phòng thành công");
                LoadTrangThaiDatPhong();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string trangThaiID = gntxtTrangThaiID.Text.Trim();
            string hoaDonThueID = gnCbo_HoaDonThueID.SelectedValue.ToString();
            string loaiTrangThaiID = gnCbo_LoaiTrangThaiID.SelectedValue.ToString();
            DateTime ngayCapNhat = gnDtpNgayCapNhat.Value;
            if (string.IsNullOrEmpty(hoaDonThueID) || string.IsNullOrEmpty(loaiTrangThaiID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            DTO_TrangThaiDatPhong trangThaiDatPhong = new DTO_TrangThaiDatPhong
            {
                TrangThaiID = trangThaiID,
                HoaDonThueID = hoaDonThueID,
                LoaiTrangThaiID = loaiTrangThaiID,
                NgayCapNhat = ngayCapNhat
            };
            BLLTrangThaiDatPhong bllTrangThai = new BLLTrangThaiDatPhong();
            string result = bllTrangThai.updateTrangThai(trangThaiDatPhong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật trạng thái đặt phòng thành công");
                LoadTrangThaiDatPhong();
                ClearForm();
                return;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dgvTrangThaiDatPhong.SelectedRows.Count > 0)
            {
                string trangthaidatphong = dgvTrangThaiDatPhong.SelectedRows[0].Cells["TrangThaiID"].Value.ToString();
                BLLTrangThaiDatPhong bustrangthai = new BLLTrangThaiDatPhong();
                string result = bustrangthai.deleteTrangThai(trangthaidatphong);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa trạng thái đặt phòng thành công!");
                    LoadTrangThaiDatPhong();
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string keyword = guna2TextBox9.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadTrangThaiDatPhong();
            }
            else
            {
                TimKiemTrangThai(keyword);
            }

        }
        private void TimKiemTrangThai(string keyword)
        {
            BLLTrangThaiDatPhong bllTrangThai = new BLLTrangThaiDatPhong();
            dgvTrangThaiDatPhong.DataSource = bllTrangThai.TimKiem(keyword);
            if (dgvTrangThaiDatPhong.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào với từ khóa: " + keyword);
            }
        }

        private void dgvTrangThaiDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

