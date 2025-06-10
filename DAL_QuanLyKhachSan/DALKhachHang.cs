using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLyKhachSan
{
    public class DALKhachHang
    {
        public List<KhachHang> SelectBySql(string sql, List<object> args)
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    KhachHang entity = new KhachHang();
                    entity.KhachHangID = reader["KhachHangID"].ToString();
                    entity.HoTen = reader["HoTen"].ToString();
                    entity.DiaChi = reader["DiaChi"].ToString();
                    entity.GioiTinh = reader["GioiTinh"].ToString();
                    entity.SoDienThoai = reader["SoDienThoai"].ToString(); 
                    entity.CCCD = reader["CCCD"].ToString();
                    entity.NgayTao = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgayTao"]) : DateTime.MinValue;
                    entity.TrangThai = reader["TrangThai"] != DBNull.Value ? Convert.ToBoolean(reader["TrangThai"]) : false;
                    entity.GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : "";
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<KhachHang> SelectAll()
        {
            string sql = "SELECT * FROM KhachHang";
            return SelectBySql(sql, new List<object>());
        }

    }
}
