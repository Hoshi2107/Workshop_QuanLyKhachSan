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
    public class DALTrangThaiDatPhong
    {
        public List<TrangThaiDatPhong> SelectBySql(string sql, List<object> args)
        {
            List<TrangThaiDatPhong> list = new List<TrangThaiDatPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    TrangThaiDatPhong entity = new TrangThaiDatPhong();
                    
                        entity.TrangThaiID = reader.GetString("TrangThaiID");
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
                    entity.LoaiTrangThaiID = reader.GetString("LoaiTrangThaiID");
                    entity.NgayCapNhat = reader.GetDateTime("NgayCapNhat");
                    
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return list;
        }

        public List<TrangThaiDatPhong> SelectAll()
        {
            string sql = "SELECT * FROM TrangThaiDatPhong";
            return SelectBySql(sql, new List<object>());
        }
    }
}