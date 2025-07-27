using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using Microsoft.Identity.Client;
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
        public List<DTO_Phong> GetPhongList()
        {
            return dalPhong.SelectAll();
        }
        public string UpdatePhong(DTO_Phong phong)
        {
            try
            {
                if (string.IsNullOrEmpty(phong.MaPhong))
                {
                    return "Mã phòng không hợp lệ ! ! !";
                }
                dalPhong.updatePhong(phong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string InsertPhong(DTO_Phong phong)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phong.MaPhong))
                {
                    phong.MaPhong = dalPhong.generateMaPhong();
                }
                if (string.IsNullOrEmpty(phong.TenPhong))
                {
                    return "Tên phòng không được để trống.";
                }
                dalPhong.insertPhong(phong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string deletePhong(string phong)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phong))
                {
                    return "Mã phòng không hợp lệ ! ! !";
                }
                dalPhong.deletephong(phong);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<DTO_Phong> SearchPhong(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return dalPhong.selectAll();
                }
                keyword = keyword.Trim().ToLower();
                return dalPhong.searchByKeyword(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm phòng: " + ex.Message);
            }

        }

    }
}
