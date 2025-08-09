using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                    entity.MaLoaiPhong = reader["MaLoaiPhong"].ToString();
                    entity.TenLoaiPhong = reader["TenLoaiPhong"].ToString();
                    entity.SoLuongPhong = Convert.ToInt32(reader["SoLuongPhong"]);
                    entity.SoLuongDat = Convert.ToInt32(reader["SoLuongDat"]);
                    //entity.NgayBatDau = DateTime.Parse(reader["NgayBatDau"].ToString());
                    //entity.NgayKetThuc = DateTime.Parse(reader["NgayKetThuc"].ToString());
                    //entity.TinhTrang = Convert.ToBoolean(reader["TinhTrang"]);
                    entity.DoanhThu = Convert.ToDecimal(reader["DoanhThu"]);

                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        //public List<DTO_ThongKePhong> LayThongKePhong(DateTime ngayBatDau, DateTime ngayKetThuc)
        //{
        //    string sql = @"SELECT p.PhongID, p.TenPhong, p.MaLoaiPhong, p.GiaPhong, 
        //                          dp.NgayDen AS NgayBatDau, dp.NgayDi AS NgayKetThuc, 
        //                          p.TinhTrang, p.GhiChu
        //                   FROM Phong p
        //                   LEFT JOIN DatPhong dp ON p.PhongID = dp.PhongID
        //                   WHERE p.PhongID = @0 AND 
        //                         (dp.NgayDen >= @1 AND dp.NgayDi <= @2)";
        //    List<object> args = new List<object>
        //    {
        //        phongID,
        //        ngayBatDau,
        //        ngayKetThuc
        //    };
        //    return SelectBySql(sql, args);

        //}
            public List<DTO_ThongKePhong> LayThongKeTheoLoaiPhong(DateTime ngayBD, DateTime ngayKT, string maLoaiPhong)
            {
            List<DTO_ThongKePhong> list = new List<DTO_ThongKePhong>();

            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ThongKeTheoLoaiPhong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBD);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKT);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DTO_ThongKePhong
                    {
                        MaLoaiPhong = reader["MaLoaiPhong"].ToString().Trim(),
                        TenLoaiPhong = reader["TenLoaiPhong"].ToString(),
                        SoLuongPhong = Convert.ToInt32(reader["SoLuongPhong"]),
                        SoLuongDat = Convert.ToInt32(reader["SoLuongDat"]),
                        DoanhThu = Convert.ToDecimal(reader["DoanhThu"])
                    });
                }
                reader.Close();
            }

            return list;
            }
    }
}
