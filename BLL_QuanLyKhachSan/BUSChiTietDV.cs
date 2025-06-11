using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QuanLyKhachSan
{
    public class BUSChiTietDV
    {
        DALChiTietDv dALchitietDichVu = new DALChiTietDv();
        public List<ChiTietDichVu> GetchitietDichVuList()
        {
            return dALchitietDichVu.SelectAll();
        }
    }
}
