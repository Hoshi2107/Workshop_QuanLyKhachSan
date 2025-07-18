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
            BUSLoaiPhong bUSLoaiPhong = new BUSLoaiPhong();

            dgvloaiphong.DataSource = bUSLoaiPhong.GetLoaiPhong();
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
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
          
        }
        private void ClearForm()
        {
            // Reset trạng thái nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

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
