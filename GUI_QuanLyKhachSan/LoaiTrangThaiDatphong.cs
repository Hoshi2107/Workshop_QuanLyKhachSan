using BLL_QuanLyKhachSan;
using DAL_QuanLyKhachSan;
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
    public partial class LoaiTrangThaiDatphong : Form
    {
        public LoaiTrangThaiDatphong()
        {
            InitializeComponent();
        }

        private void LoadLoaiTrangThaiDatPhong()
        {

        }
        private void LoaiTrangThaiDatphong_Load(object sender, EventArgs e)
        {

        }

        private void LoaiTrangThaiDatphong_Load_1(object sender, EventArgs e)
        {
            loadtrangthaidatphong();
            ClearForm();
        }
        private void ClearForm()
        {
            gntxtMaLoaiPhong.Clear();
            gntxtTenLoaiPhong.Clear();
            gntxtMaLoaiPhong.Enabled = true;
            gnbtnThem.Enabled = true;
            gnbtnSua.Enabled = true;
            gnbtnXoa.Enabled = true;
            gntxtMaLoaiPhong.Enabled = false;
        }
        private void loadtrangthaidatphong()
        {
            BUSLoaiTrangThaiDatPhong busLoaiTrangThaiDatPhong = new BUSLoaiTrangThaiDatPhong();
            guna2DataGridView1.DataSource = busLoaiTrangThaiDatPhong.GetLoaiTrangThaiDatPhongList();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            gntxtMaLoaiPhong.Text = row.Cells["LoaiTrangThaiID"].Value.ToString();
            gntxtTenLoaiPhong.Text = row.Cells["TenTrangThai"].Value.ToString();
        }

        private void gnbtnThem_Click(object sender, EventArgs e)
        {
            string maLoaiTrangThai = gntxtMaLoaiPhong.Text.Trim();
            string tenLoaiTrangThai = gntxtTenLoaiPhong.Text.Trim();
            if (string.IsNullOrEmpty(tenLoaiTrangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTO_LoaiTrangThaiDatPhong loaitrangThaiDatPhong = new DTO_LoaiTrangThaiDatPhong
            {
                LoaiTrangThaiID = maLoaiTrangThai,
                TenTrangThai = tenLoaiTrangThai
            };
            BUSLoaiTrangThaiDatPhong busLoaiTrangThaiDatPhong = new BUSLoaiTrangThaiDatPhong();
            string result = busLoaiTrangThaiDatPhong.insertLoaiTrangThaiDatPhong(loaitrangThaiDatPhong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                loadtrangthaidatphong();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void gnbtnSua_Click(object sender, EventArgs e)
        {
            string maLoaiTrangThai = gntxtMaLoaiPhong.Text.Trim();
            string tenLoaiTrangThai = gntxtTenLoaiPhong.Text.Trim();
            if (string.IsNullOrEmpty(tenLoaiTrangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DTO_LoaiTrangThaiDatPhong loaitrangThaiDatPhong = new DTO_LoaiTrangThaiDatPhong
            {
                LoaiTrangThaiID = maLoaiTrangThai,
                TenTrangThai = tenLoaiTrangThai
            };
            BUSLoaiTrangThaiDatPhong busLoaiTrangThaiDatPhong = new BUSLoaiTrangThaiDatPhong();
            string result = busLoaiTrangThaiDatPhong.updateLoaiTrangThaiDatPhong(loaitrangThaiDatPhong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật trạng thái đặt phòng thành công!");
                loadtrangthaidatphong();
                ClearForm();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void gnbtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void gnbtnXoa_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã nhân viên từ dòng đang chọn
                string maLoai = guna2DataGridView1.SelectedRows[0].Cells["LoaiTrangThaiID"].Value.ToString();

                // Gọi hàm xóa trong BUS
                BUSLoaiTrangThaiDatPhong busLoai = new BUSLoaiTrangThaiDatPhong();
                string result = busLoai.deleteLoaiTrangThaiDatPhong(new DTO_LoaiTrangThaiDatPhong { LoaiTrangThaiID = maLoai });

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa thành công!");
                    loadtrangthaidatphong(); // load lại danh sách sau khi xóa
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa: " + result);
                }

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string keyword = guna2TextBox9.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                loadtrangthaidatphong();
            }
            else
            {
                TimKiemLoaiTrangThai(keyword);
            }

        }
        private void TimKiemLoaiTrangThai(string keyword)
        {
            BUSLoaiTrangThaiDatPhong bUsLoaiTT = new BUSLoaiTrangThaiDatPhong();

            guna2DataGridView1.DataSource = bUsLoaiTT.SearchLoaiTrangThaiDatPhong(keyword);
        }


    }
}
