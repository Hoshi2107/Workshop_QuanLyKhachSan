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
                ldv.LoaiDichVuID = dalloaisp.genereteMaLoaiDV();

                if (string.IsNullOrEmpty(ldv.LoaiDichVuID))
                {
                    return "Mã Loại không hợp lệ!";
                }

                dalloaisp.addLoaiDichVu(ldv); 
                return "Thêm loại dịch vụ thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm loại dịch vụ: " + ex.Message);
                return "Có lỗi xảy ra! Vui lòng kiểm tra lại.";
            }
        }
        public string UpdateLoaiDichVu(DTO_LoaiDichVu ldv)
        {
            try
            {
                if (string.IsNullOrEmpty(ldv.LoaiDichVuID)) 
                {
                    return "Mã loại dịch vụ không hợp lệ!";
                }

                dalloaisp.updateLoaiDichVu(ldv); 
                return "Cập nhật loại dịch vụ thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật loại dịch vụ: " + ex.Message);
                return "Có lỗi xảy ra! Vui lòng kiểm tra lại.";
            }
        }
        public string DeleteLoaiDichVu(string loaiDichVuID)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiDichVuID))
                {
                    return "Mã loại dịch vụ không hợp lệ.";
                }

                dalloaisp.deleteLoaiDichVu(loaiDichVuID); 
                return "Xóa loại dịch vụ thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa loại dịch vụ: " + ex.Message);
                return "Có lỗi xảy ra! Vui lòng kiểm tra lại.";
            }
        }
       
    }
}
