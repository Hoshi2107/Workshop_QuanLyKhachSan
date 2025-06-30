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
using DAL_QuanLyKhachSan;
using Guna.UI2.WinForms;

namespace GUI_QuanLyKhachSan
{
    public partial class LoaiPhong : Form
    {
        public LoaiPhong()
        {
            InitializeComponent();
        }

        private void LoaiPhong_Load(object sender, EventArgs e)
        {
            Loadloaiphong();
        }
        private void Loadloaiphong()
        {
            BUSLoaiPhong bUSDichVu = new BUSLoaiPhong();

            dgvloaiphong.DataSource = bUSDichVu.GateLoaiPhong();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            Loadloaiphong();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click vào dòng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dgvloaiphong.Rows.Count)
            {
                DataGridViewRow row = dgvloaiphong.Rows[e.RowIndex];

                // Lấy dữ liệu từ từng cột, chỉnh tên cột nếu cần
                txtMaLoaiPhong.Text = row.Cells["MaLoaiPhong"].Value?.ToString();
                txtTenLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
                dtpNgayTao.Value = DateTime.TryParse(row.Cells["NgayTao"].Value?.ToString(), out DateTime ngayTao) ? ngayTao : DateTime.Now;

                // Nếu có cột Trạng Thái dạng 0/1, thiết lập RadioButton
                if (row.Cells["TrangThai"].Value != null)
                {
                    string trangThai = row.Cells["TrangThai"].Value.ToString();
                    if (trangThai == "0")
                    {
                        guna2RadioButton1.Checked = true;
                    }
                    else if (trangThai == "1")
                    {
                        guna2RadioButton2.Checked = true;
                    }
                    else
                    {
                        guna2RadioButton1.Checked = false;
                        guna2RadioButton2.Checked = false;
                    }
                }

                // Cập nhật trạng thái nút
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaLoaiPhong.Text.Trim();

            if (string.IsNullOrEmpty(maLoaiPhong))
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa loại phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
                string result = busLoaiPhong.XoaLoaiPhong(maLoaiPhong);

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Lỗi: " + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loadloaiphong();
                ClearForm();
            }
        }
        private void ClearForm()
        {
            // Reset trạng thái nút
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Xóa dữ liệu các TextBox
            txtMaLoaiPhong.Clear();
            txtTenLoaiPhong.Clear();
            txtGhiChu.Clear();
            txtDichVuID.Clear();
            guna2TextBox9.Clear(); // Đây là textbox tìm kiếm, nếu muốn giữ lại, có thể bỏ clear

            // Reset DateTimePicker về ngày hiện tại
            dtpNgayTao.Value = DateTime.Now;

            // Bỏ chọn RadioButton
            guna2RadioButton1.Checked = false;
            guna2RadioButton2.Checked = false;

            // Đặt lại focus cho TextBox nhập tên
            txtTenLoaiPhong.Focus();
        }

    }
}
