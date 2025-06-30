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
        public List<LoaiPhong> GateLoaiPhong()
        {
            return dalloaiPhong.selectAll();
        }

        public string XoaLoaiPhong(string maLoaiPhong)
        {
            try
            {
                if (string.IsNullOrEmpty(maLoaiPhong))
                {
                    return "Mã loại phòng không hợp lệ.";
                }

                dalloaiPhong.Delete(maLoaiPhong);
                return null; // thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS khi xóa loại phòng: " + ex.Message);
                return "Có lỗi xảy ra khi xóa loại phòng: " + ex.Message;
            }
        }

    }
}
