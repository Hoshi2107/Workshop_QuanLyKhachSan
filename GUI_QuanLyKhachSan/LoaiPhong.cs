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
    }
}
