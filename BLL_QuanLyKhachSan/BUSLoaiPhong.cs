using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;

namespace BLL_QuanLyKhachSan
{
    public class BUSLoaiPhong
    {
        DALLoaiPhong dalloaiPhong = new DALLoaiPhong();
        public List<LoaiPhong> GetLoaiPhong()
        {
            return dalloaiPhong.selectAll();
        }

       

    }
}
