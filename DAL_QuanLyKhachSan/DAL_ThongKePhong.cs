using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLyKhachSan
{
    public class DAL_ThongKePhong
    {
        public List<DTO_ThongKePhong> SelectBySql(string sql, List<object> args)
        {
            List<DTO_ThongKePhong> list = new List<DTO_ThongKePhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_ThongKePhong entity = new DTO_ThongKePhong();
                    entity.PhongID = reader["PhongID"].ToString();
                    entity.TenPhong = reader["TenPhong"].ToString();
                    entity.MaLoaiPhong = reader["MaLoaiPhong"].ToString();
                    entity.GiaPhong = Convert.ToInt32(reader["GiaPhong"]);
                    entity.NgayBatDau = DateTime.Parse(reader["NgayBatDau"].ToString());
                    entity.NgayKetThuc = DateTime.Parse(reader["NgayKetThuc"].ToString());
                    entity.TinhTrang = Convert.ToBoolean(reader["TinhTrang"]);
                    entity.GhiChu = reader["GhiChu"].ToString();

                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<DTO_ThongKePhong> LayThongKePhong(string phongID, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            string sql = @"SELECT p.PhongID, p.TenPhong, p.MaLoaiPhong, p.GiaPhong, 
                                  dp.NgayDen AS NgayBatDau, dp.NgayDi AS NgayKetThuc, 
                                  p.TinhTrang, p.GhiChu
                           FROM Phong p
                           LEFT JOIN DatPhong dp ON p.PhongID = dp.PhongID
                           WHERE p.PhongID = @0 AND 
                                 (dp.NgayDen >= @1 AND dp.NgayDi <= @2)";
            List<object> args = new List<object>
            {
                phongID,
                ngayBatDau,
                ngayKetThuc
            };
            return SelectBySql(sql, args);

        }

    }
}