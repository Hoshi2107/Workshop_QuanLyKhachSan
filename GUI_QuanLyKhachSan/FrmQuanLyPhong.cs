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
            gnTxt_PhongID.Text = row.Cells["PhongID"].Value.ToString();
            gnTxt_TenPhong.Text = row.Cells["TenPhong"].Value.ToString();
            gnCbo_MaLoaiPhong.Text = row.Cells["MaLoaiPhong"].Value.ToString();
            gnTxt_GiaPhong.Text = row.Cells["GiaPhong"].Value.ToString();
            gnDtp_NgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            bool tinhTrang = Convert.ToBoolean(row.Cells["TinhTrang"].Value);
            if (tinhTrang)
            {
                gnRdo_ĐHđộng.Checked = true;
            }
            else
            {
                gnRdo_KHĐộng.Checked = true;
            }
            gnTxt_GhiChu.Text = row.Cells["GhiChu"].Value.ToString();

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
