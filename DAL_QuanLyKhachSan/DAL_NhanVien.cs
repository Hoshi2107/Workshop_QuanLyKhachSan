using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace DAL_QuanLyKhachSan
{
    public class DAL_NhanVien
    {
        public DTO_NhanVien? GetNhanVien1(string email, string password)
        {
            string sql = "SELECT Top 1 * FROM NhanVien WHERE Email=@0 AND MatKhau=@1";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            thamSo.Add(password);
            SqlDataReader reader = DBUtil.Query(sql, thamSo);
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    DTO_NhanVien nv = new DTO_NhanVien();
                    nv.MaNV = reader["MaNV"].ToString();
                    nv.HoTen = reader["HoTen"].ToString();
                    nv.GioiTinh = reader["GioiTinh"].ToString();    
                    nv.Email = reader["Email"].ToString();
                    nv.DiaChi = reader["DiaChi"].ToString();
                    nv.MatKhau = reader["MatKhau"].ToString();
                    nv.VaiTro = bool.Parse(reader["VaiTro"].ToString());
                    nv.TinhTrang = bool.Parse(reader["TinhTrang"].ToString());

                    return nv;
                }
            }
            return null;
        }
        public List<DTO_NhanVien> seletAll()
        {
            string sql = "SELECT * FROM NhanVien";
            return SelectBySql(sql, new List<object>());
        }

        public List<DTO_NhanVien> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<DTO_NhanVien> list = new List<DTO_NhanVien>();
            using (SqlDataReader reader = DBUtil.Query(sql, args, cmdType))
            {
                
                while (reader.Read())
                {
                    DTO_NhanVien entity = new DTO_NhanVien()
                    {
                        MaNV = reader["MaNV"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        Email = reader["Email"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        VaiTro = bool.Parse(reader["VaiTro"].ToString()),
                        TinhTrang = bool.Parse(reader["TinhTrang"].ToString()),
                    };
                    
                    list.Add(entity);
                }
            }
            
            return list;
        }

        public List<DTO_NhanVien> selectAll()
        {
            String sql = "SELECT * FROM NhanVien";
            return SelectBySql(sql, new List<object>());
        }

        public void updateNhanVien(DTO_NhanVien nv)
        {
            try
            {
                string sql = @"UPDATE NhanVien
                                   SET HoTen = @1, GioiTinh = @2, Email = @3, DiaChi = @4, MatKhau = @5, VaiTro = @6, TrangThai = @7
                                    WHERE MaNhanVien = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaNV);
                thamSo.Add(nv.HoTen);
                thamSo.Add(nv.GioiTinh);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.DiaChi);
                thamSo.Add(nv.MatKhau);
                thamSo.Add(nv.VaiTro);
                thamSo.Add(nv.TinhTrang);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void insertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                string sql = @"INSERT INTO NhanVien (MaNV, HoTen,GioiTinh, Email,DiaChi, MatKhau, VaiTro, TinhTrang) 
                   VALUES (@MaNV, @HoTen, @GioiTinh, @Email, @DiaChi, @MatKhau, @VaiTro, @TinhTrang)";
                List<object> thamSo = new List<object>()
                {
                    new SqlParameter("@MaNV", nv.MaNV),
                    new SqlParameter("@HoTen", nv.HoTen),
                    new SqlParameter("@GioiTinh", nv.GioiTinh),
                    new SqlParameter("@Email", nv.Email),
                    new SqlParameter("@DiaChi", nv.DiaChi),
                    new SqlParameter("@MatKhau", nv.MatKhau),
                    new SqlParameter("@VaiTro", nv.VaiTro),
                    new SqlParameter("@TinhTrang", nv.TinhTrang)
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        
        public void deleteNhanVien(string maNv)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maNv);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public string generateMaNhanVien()
        {
            string prefix = "NV";
            string sql = "SELECT MAX(MaNhanVien) FROM NhanVien";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
    }
}
