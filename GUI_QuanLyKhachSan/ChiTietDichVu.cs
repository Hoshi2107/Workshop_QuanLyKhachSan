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
    public partial class ChiTietDichVu : Form
    {
        public ChiTietDichVu()
        {
            InitializeComponent();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChiTietDichVu_Load(object sender, EventArgs e)
        {
            LoadchitetdichVu();
        }
        private void LoadchitetdichVu()
        {
            BUSChiTietDV bUSchitietDichVu = new BUSChiTietDV();
            guna2DataGridView1.DataSource = bUSchitietDichVu.GetchitietDichVuList();
        }
    }
}