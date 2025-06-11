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
    public class DALLoaiTrangThaiDatPhong
    {
        public List<LoaiTrangThaiDatPhong> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<LoaiTrangThaiDatPhong> list = new List<LoaiTrangThaiDatPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    LoaiTrangThaiDatPhong entity = new LoaiTrangThaiDatPhong();
                    entity.LoaiTrangThaiID = reader.GetString("LoaiTrangThaiID");
                    entity.TenTrangThai = reader.GetString("TenTrangThai");
                               
                    list.Add(entity);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<LoaiTrangThaiDatPhong> selectAll()
        {
            String sql = "SELECT * FROM LoaiTrangThaiDatPhong";
            return SelectBySql(sql, new List<object>());
        }
    }
}
