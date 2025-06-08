using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyKhachSan;
namespace UTIL_QuanLyKhachSan
{
    public class AuthUtil
    {
        public static DTO_NhanVien user = null;
        public static bool IsLogin()
        {
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.MaNV))
            {
                return false;
            }
            return true;
        }
    }
}
