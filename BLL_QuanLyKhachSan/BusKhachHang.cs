using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QuanLyKhachSan
{
    public class BusKhachHang
    {
        DALKhachHang dalKhachHang = new DALKhachHang();
        public List<KhachHang> GetKhachHangList()
        {
            return dalKhachHang.SelectAll();
        }
        public string UpdateKhachHang(KhachHang kh)
        {
            try
            {
                if (string.IsNullOrEmpty(kh.KhachHangID))
                {
                    return "Mã nhân viên không hợp lệ ! ! !";
                }

                dalKhachHang.updateKhachHang(kh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string insertKhachHang(KhachHang kh)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(kh.KhachHangID))
                {
                    kh.KhachHangID = dalKhachHang.generateKhachHangID();
                }
                if (string.IsNullOrEmpty(kh.HoTen))
                {
                    return "Họ tên không được để trống.";
                }
                dalKhachHang.insertKhachHang(kh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string deletekhachhang(KhachHang QlKH)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(QlKH.KhachHangID))
                {
                    return "Chưa chọn dòng để xóa";
                }
                dalKhachHang.deleteKhachHang(QlKH);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<KhachHang> TimKiem(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return dalKhachHang.selectAll();
                }
                keyword = keyword.Trim().ToLower();
                return dalKhachHang.searchByKeyword(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
        }

    }

}
