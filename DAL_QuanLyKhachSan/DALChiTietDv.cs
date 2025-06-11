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
    public class DALChiTietDv
    {
        public List<ChiTietDichVu> SelectBySql(string sql, List<object> args)
        {
            List<ChiTietDichVu> list = new List<ChiTietDichVu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    ChiTietDichVu entity = new ChiTietDichVu();
                    entity.ChiTietDichVuID = reader.GetString("ChiTietDichVuID");
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
                    entity.DichVuID = reader.GetString("DichVuID");
                    entity.LoaiDichVuID = reader.GetString("LoaiDichVuID");
                    entity.SoLuong = reader.GetInt32("SoLuong");
                    entity.NgayBatDau = reader.GetDateTime("NgayBatDau");
                    entity.NgayKetThuc = reader.GetDateTime("NgayKetThuc");
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

        public List<ChiTietDichVu> SelectAll()
        {
            string sql = "SELECT * FROM ChiTietDichVu";
            return SelectBySql(sql, new List<object>());
        }
    }
}


