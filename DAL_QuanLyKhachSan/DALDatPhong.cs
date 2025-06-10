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
    public class DALDatPhong
    {
        public List<DatPhong> SelectBySql(string sql, List<object> args)
        {
            List<DatPhong> list = new List< DatPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DatPhong entity = new DatPhong();
                    entity.MaHoaDonThue = reader.GetString("HoaDonThueID");
                    entity.MaKhachHang = reader.GetString("KhachHangID");
                    entity.MaPhong = reader.GetString("PhongID");
                    entity.NgayDen = reader.GetDateTime("NgayDen");
                    entity.NgayDi = reader.GetDateTime("NgayDi");
                    entity.MaNV = reader.GetString("MaNV");
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

        public List<DatPhong> SelectAll()
        {
            string sql = "SELECT * FROM DatPhong";
            return SelectBySql(sql, new List<object>());
        }

    }
}
