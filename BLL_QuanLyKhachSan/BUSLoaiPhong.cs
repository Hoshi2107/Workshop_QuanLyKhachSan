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
        public List<DTO_LoaiPhong> GetLoaiPhong()
        {
            return dalloaiPhong.selectAll();
        }
        public string insertLoaiPhong(DTO_LoaiPhong loaiPhong)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loaiPhong.MaLoaiPhong))
                {
                    loaiPhong.MaLoaiPhong = dalloaiPhong.generateLoaiPhong();
                }
                if (string.IsNullOrEmpty(loaiPhong.TenLoaiPhong))
                {
                    return "Tên loại phòng không được để trống.";
                }
                dalloaiPhong.Insert(loaiPhong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string updateLoaiPhong(DTO_LoaiPhong loaiPhong)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiPhong.MaLoaiPhong))
                {
                    return "Mã loại phòng không được để trống.";
                }
                dalloaiPhong.Update(loaiPhong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string deleteLoaiPhong(string maLoaiPhong)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maLoaiPhong))
                {
                    return "Chưa chọn loại phòng để xóa.";
                }
                dalloaiPhong.Delete(maLoaiPhong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<DTO_LoaiPhong> SearchByKeyWord(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return dalloaiPhong.selectAll();
                }
                keyword = keyword.Trim().ToLower();
                return dalloaiPhong.SearchByKeyWord(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm loại phòng: " + ex.Message);
            }

        }

    }
}
