using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;

namespace BLL_QuanLyKhachSan
{
    public class BUSLoaiTrangThaiDatPhong
    {
        DALLoaiTrangThaiDatPhong dalloaiTrangThaiDatPhong = new DALLoaiTrangThaiDatPhong();
        public List<LoaiTrangThaiDatPhong> GetLoaiTrangThaiDatPhongList()
        {
            return dalloaiTrangThaiDatPhong.selectAll();
        }
    }
}
