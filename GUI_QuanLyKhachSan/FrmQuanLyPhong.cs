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
    public partial class FrmQuanLyPhong : Form
    {
        public FrmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void guna2DgvPhong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DgvPhong.Rows[e.RowIndex];
            txtIDPhong.Text = row.Cells["MaPhong"].Value.ToString();
            txtTenPhong.Text = row.Cells["TenPhong"].Value.ToString();
            cboMaLoaiPhong.Text = row.Cells["MaLoaiPhong"].Value.ToString();
            txtGiaPhong.Text = row.Cells["GiaPhong"].Value.ToString();
            dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            bool tinhTrang = Convert.ToBoolean(row.Cells["TinhTrang"].Value);
            if (tinhTrang)
            {
                rdoDangHoatDong.Checked = true;
            }
            else
            {
                rdoKhongHoatDong.Checked = true;
            }
            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();

        }

        private void FrmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
            LoadCombobox();
            ClearForm();
        }
        private void ClearForm()
        {
            txtIDPhong.Clear();
            txtTenPhong.Clear();
            cboMaLoaiPhong.SelectedIndex = -1;
            txtGiaPhong.Clear();
            dtpNgayTao.Value = DateTime.Now;
            rdoDangHoatDong.Checked = false;
            rdoKhongHoatDong.Checked = false;
            txtGhiChu.Clear();
            txtIDPhong.Enabled = false;
        }
        private void LoadCombobox()
        {
            BUSLoaiPhong bllLoaiPhong = new BUSLoaiPhong();
            cboMaLoaiPhong.DataSource = bllLoaiPhong.GetLoaiPhong();
            cboMaLoaiPhong.DisplayMember = "MaLoaiPhong";
            cboMaLoaiPhong.ValueMember = "MaLoaiPhong";


        }
        private void LoadDanhSachPhong()
        {
            BusPhong bllPhong = new BusPhong();
            guna2DgvPhong.DataSource = bllPhong.GetPhongList();
        }

        private void guna2DgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maPhong = txtIDPhong.Text.Trim();
            string tenPhong = txtTenPhong.Text.Trim();
            string maLoaiPhong = cboMaLoaiPhong.SelectedValue.ToString();
            string giaPhong = txtGiaPhong.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            bool tinhTrang = rdoDangHoatDong.Checked;
            string ghiChu = txtGhiChu.Text.Trim();
            if (string.IsNullOrEmpty(tenPhong) || string.IsNullOrEmpty(maLoaiPhong) || string.IsNullOrEmpty(giaPhong))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            Phong phong = new Phong
            {
                MaPhong = maPhong,
                TenPhong = tenPhong,
                MaLoaiPhong = maLoaiPhong,
                GiaPhong = decimal.Parse(giaPhong),
                NgayTao = ngayTao,
                TinhTrang = tinhTrang,
                GhiChu = ghiChu
            };
            BusPhong bllPhong = new BusPhong();
            string result = bllPhong.InsertPhong(phong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm phòng thành công.");
                LoadDanhSachPhong();
                LoadCombobox();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm phòng: " + result);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string maPhong = txtIDPhong.Text.Trim();
            string tenPhong = txtTenPhong.Text.Trim();
            string maLoaiPhong = cboMaLoaiPhong.SelectedValue.ToString();
            string giaPhong = txtGiaPhong.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            bool tinhTrang = rdoDangHoatDong.Checked;
            string ghiChu = txtGhiChu.Text.Trim();
            if (string.IsNullOrEmpty(tenPhong) || string.IsNullOrEmpty(maLoaiPhong) || string.IsNullOrEmpty(giaPhong))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            Phong phong = new Phong
            {
                MaPhong = maPhong,
                TenPhong = tenPhong,
                MaLoaiPhong = maLoaiPhong,
                GiaPhong = decimal.Parse(giaPhong),
                NgayTao = ngayTao,
                TinhTrang = tinhTrang,
                GhiChu = ghiChu
            };
            BusPhong bllPhong = new BusPhong();
            string result = bllPhong.UpdatePhong(phong);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật phòng thành công.");
                LoadDanhSachPhong();
                LoadCombobox();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật phòng: " + result);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DgvPhong.SelectedRows.Count > 0)
            {
                // Lấy mã nhân viên từ dòng đang chọn
                string maPhong = guna2DgvPhong.SelectedRows[0].Cells["MaPhong"].Value.ToString();

                // Gọi hàm xóa trong BUS
                BusPhong busPhong = new BusPhong();
                string result = busPhong.deletePhong(new Phong { MaPhong = maPhong });

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDanhSachPhong(); // load lại danh sách sau khi xóa
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachPhong();
            }
            else
            {
                TimKiemPhongID(keyword);
            }

        }
        private void TimKiemPhongID(string keyword)
        {
            BusPhong busPhong = new BusPhong();

            guna2DgvPhong.DataSource = busPhong.SearchPhong(keyword);
        }


    }
}
