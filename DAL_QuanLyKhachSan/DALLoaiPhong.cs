using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;

namespace DAL_QuanLyKhachSan
{
    public class DALLoaiPhong
    {
        public List<LoaiPhong> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<LoaiPhong> list = new List<LoaiPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    LoaiPhong entity = new LoaiPhong();
                    entity.MaLoaiPhong = reader.GetString("MaLoaiPhong");
                    entity.TenLoaiPhong = reader.GetString("TenLoaiPhong");              
                    entity.NgayTao = reader.GetDateTime("NgayTao");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    entity.GhiChu = reader.GetString("GhiChu");
                    list.Add(entity);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<LoaiPhong> selectAll()
        {
            String sql = "SELECT * FROM LoaiPhong";
            return SelectBySql(sql, new List<object>());
        }

        public void Delete(string maLoaiPhong)
        {
            try
            {
                string sql = "DELETE FROM LoaiPhong WHERE MaLoaiPhong = @0";
                DBUtil.Update(sql, new List<object> { maLoaiPhong });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL khi xóa loại phòng: " + ex.Message);
                throw; // Để BUS bắt lỗi xử lý
            }
        }

    }
}
