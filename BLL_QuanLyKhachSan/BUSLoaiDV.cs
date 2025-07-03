using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
namespace BLL_QuanLyKhachSan
{
    public class BUSLoaiDV
    {
        DALLoaiDV dalloaisp = new DALLoaiDV();
        public List<DTO_LoaiDichVu> GetLoaiDVList()
        {
            return dalloaisp.selectAll();
        }
        public string AddLoaiDichVu(DTO_LoaiDichVu ldv)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ldv.LoaiDichVuID))
                {
                    ldv.LoaiDichVuID = dalloaisp.genereteMaLoaiDV();
                }
                if (string.IsNullOrEmpty(ldv.TenDichVu))
                {
                    return "Tên dịch vụ không được để trống.";
                }
                dalloaisp.addLoaiDichVu(ldv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string UpdateLoaiDichVu(DTO_LoaiDichVu ldv)
        {
            try
            {
                if (string.IsNullOrEmpty(ldv.LoaiDichVuID))
                {
                    return "Mã dịch vụ không hợp lệ ! ! !";
                }

                dalloaisp.updateLoaiDichVu(ldv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string DeleteLoaiDichVu(DTO_LoaiDichVu ldv)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ldv.LoaiDichVuID))
                {
                    return "Chưa chọn dòng để xóa";
                }
                dalloaisp.deleteLoaiDichVu(ldv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string GenerateNewLoaiDichVuID()
        {
            string prefix = "LDV";  // Đặt ở đây để cả try và catch đều dùng được

            try
            {
                string sql = "SELECT MAX(LoaiDichVuID) FROM LoaiDichVu";
                object result = DBUtil.ScalarQuery(sql, new List<object>());

                if (result != null && result.ToString().StartsWith(prefix))
                {
                    string numberPart = result.ToString().Substring(prefix.Length);
                    if (int.TryParse(numberPart, out int number))
                    {
                        return $"{prefix}{(number + 1):D3}";
                    }
                }

                return $"{prefix}001";
            }
            catch (Exception ex)
            {
                return $"{prefix}001"; // Bây giờ prefix có thể dùng được
            }
        }

    }
}
