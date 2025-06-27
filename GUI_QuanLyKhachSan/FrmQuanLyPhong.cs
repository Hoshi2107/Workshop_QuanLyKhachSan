using BLL_QuanLyKhachSan;
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
            txtIDPhong.Text = row.Cells["PhongID"].Value.ToString();
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
        }
        private void LoadDanhSachPhong()
        {
            BusPhong bllPhong = new BusPhong();
            guna2DgvPhong.DataSource = bllPhong.GetPhongList();
        }

        private void guna2DgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
