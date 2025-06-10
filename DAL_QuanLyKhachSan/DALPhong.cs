using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLyKhachSan
{
    public class DALPhong
    {
        public List<Phong> SelectAll()
        {
            string sql = "SELECT * FROM Phong";
            return SelectBySql(sql, new List<object>());
        }
        public List<Phong> SelectBySql(string sql, List<object> args)
        {
            List<Phong> list = new List<Phong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    Phong entity = new Phong();
                    entity.MaPhong = reader["PhongID"].ToString();
                    entity.TenPhong = reader["TenPhong"].ToString();
                    entity.MaLoaiPhong = reader["MaLoaiPhong"].ToString();
                    entity.GiaPhong = reader["GiaPhong"] != DBNull.Value ? Convert.ToDecimal(reader["GiaPhong"]) : 0;
                    entity.NgayTao = reader["NgayTao"] != DBNull.Value ? Convert.ToDateTime(reader["NgayTao"]) : DateTime.MinValue;
                    entity.TinhTrang = reader["TinhTrang"] != DBNull.Value ? Convert.ToBoolean(reader["TinhTrang"]) : false;
                    entity.GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : "";

                    list.Add(entity);
                }
                reader.Close(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách Phòng: " + ex.Message);
            }
            return list;
        }


    }
}
