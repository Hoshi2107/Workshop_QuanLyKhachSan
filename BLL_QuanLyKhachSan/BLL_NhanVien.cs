using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;

namespace BLL_QuanLyKhachSan
{
    
    public class BLL_NhanVien
    {
        public List<DTO_NhanVien> GetNhanViensList()
        {
            return dalNhanVien.seletAll();
        }
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public DTO_NhanVien DangNhap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            return dalNhanVien.GetNhanVien1(username, password);
        }

        public string UpdateNhanVien(DTO_NhanVien nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.MaNV))
                {
                    return "Mã nhân viên không hợp lệ ! ! !";
                }

                dalNhanVien.updateNhanVien(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string InsertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                nv.MaNV = dalNhanVien.generateMaNhanVien();
                if (string.IsNullOrEmpty(nv.MaNV))
                {
                    return "Mã nhân viên không hợp lệ.";
                }
                dalNhanVien.insertNhanVien(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<DTO_NhanVien> GetNhanVienList()
        {
            return dalNhanVien.selectAll();
        }

        public string DeleteNhanVien(string maNV)
        {
            try
            {
                if (string.IsNullOrEmpty(maNV))
                {
                    return "Mã nhân viên không hợp lệ.";
                }

                dalNhanVien.deleteNhanVien(maNV);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
