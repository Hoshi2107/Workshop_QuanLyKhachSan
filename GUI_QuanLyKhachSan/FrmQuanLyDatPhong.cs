using BLL_QuanLyKhachSan;
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
    public partial class FrmQuanLyDatPhong : Form
    {
        public FrmQuanLyDatPhong()
        {
            InitializeComponent();
        }

        private void FrmQuanLyDatPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachDatPhong();
        }
        private void LoadDanhSachDatPhong()
        {
            BusDatPhong bUSDatPhong = new BusDatPhong();
            guna2DgvDatPhong.DataSource = bUSDatPhong.GetDatPhongList();

        }

        private void guna2DgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DgvDatPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DgvDatPhong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DgvDatPhong.Rows[e.RowIndex];

        }
    }
}
