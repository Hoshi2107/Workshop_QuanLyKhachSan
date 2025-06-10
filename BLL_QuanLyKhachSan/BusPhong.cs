using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QuanLyKhachSan
{
    public class BusPhong
    {
        DALPhong dalPhong = new DALPhong();
        public List<Phong> GetPhongList()
        {
            return dalPhong.SelectAll();
        }
    }
}
