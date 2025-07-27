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
using DTO_QuanLyKhachSan;
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
            ClearForm();
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

        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvloaiphong.SelectedRows.Count > 0)
            {
                string loaiPhong = dgvloaiphong.SelectedRows[0].Cells["MaLoaiPhong"].Value.ToString();
                BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
                string result = busLoaiPhong.deleteLoaiPhong(loaiPhong);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa loại phòng thành công!");
                    Loadloaiphong();
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
        private void ClearForm()
        {


            // Xóa dữ liệu các TextBox
            txtMaLoaiPhong.Clear();
            txtTenLoaiPhong.Clear();
            txtGhiChu.Clear();
            
            guna2TextBox9.Clear();


            dtpNgayTao.Value = DateTime.Now;


            gn2rdo_ConPhong.Checked = false;
            gnRdo_HetPhong.Checked = false;


            txtTenLoaiPhong.Focus();
            txtMaLoaiPhong.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaLoaiPhong.Text.Trim();
            string tenLoaiPhong = txtTenLoaiPhong.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;

            bool trangThai = gn2rdo_ConPhong.Checked;
            string ghiChu = txtGhiChu.Text.Trim();
            
            if (string.IsNullOrEmpty(tenLoaiPhong))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTO_LoaiPhong loaiPhong = new DTO_LoaiPhong
            {
                MaLoaiPhong = maLoaiPhong,
                TenLoaiPhong = tenLoaiPhong,
                NgayTao = ngayTao,
                GhiChu = ghiChu,
                TrangThai = trangThai
            };
            BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
            string result = busLoaiPhong.insertLoaiPhong(loaiPhong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loadloaiphong();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm loại phòng: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaLoaiPhong.Text.Trim();
            string tenLoaiPhong = txtTenLoaiPhong.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            string ghiChu = txtGhiChu.Text.Trim();
            bool trangThai = gn2rdo_ConPhong.Checked;
            if (string.IsNullOrEmpty(tenLoaiPhong))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTO_LoaiPhong loaiPhong = new DTO_LoaiPhong
            {
                MaLoaiPhong = maLoaiPhong,
                TenLoaiPhong = tenLoaiPhong,
                NgayTao = ngayTao,
                GhiChu = ghiChu,
                TrangThai = trangThai
            };
            BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
            string result = busLoaiPhong.updateLoaiPhong(loaiPhong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loadloaiphong();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật loại phòng: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string keyword = guna2TextBox9.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                Loadloaiphong();
            }
            else
            {
                TimKiemLoaiPhong(keyword);
            }

        }
        private void TimKiemLoaiPhong(string keyword)
        {
            BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
            dgvloaiphong.DataSource = busLoaiPhong.SearchByKeyWord(keyword);
        }

        private void dgvloaiphong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvloaiphong.Rows[e.RowIndex];
            txtMaLoaiPhong.Text = row.Cells["MaLoaiPhong"].Value.ToString();
            txtTenLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
            DateTime ngayTao = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
        }
    }
}
