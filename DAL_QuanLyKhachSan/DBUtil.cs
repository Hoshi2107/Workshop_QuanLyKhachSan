using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO_QuanLyKhachSan;
namespace DAL_QuanLyKhachSan
{
    public class DBUtil
    {
        public static string connectionString = @"Data Source=DESKTOP-NTO91QO\DUC08;Initial Catalog=QL_KhachSan;Integrated Security=True;Trust Server Certificate=True";
        public static SqlCommand GetCommand(string sql, List<object> args, CommandType cmdType)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;
            if (args != null)
            {
                for (int i = 0; i < args.Count; i++)
                {
                    if (args[i] is SqlParameter param)
                    {
                        cmd.Parameters.Add(param);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue($"@{i}", args[i]);
                    }
                }

            }
            return cmd;

        }


        public static void Update(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            SqlCommand cmd = GetCommand(sql, args, cmdType);
            cmd.Connection.Open();
            cmd.Transaction = cmd.Connection.BeginTransaction();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();
                }

                throw new Exception("Lỗi thực hiện câu lệnh SQL: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public static SqlDataReader Query(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql, args, cmdType);
                Console.WriteLine("SQL = " + cmd.CommandText);
                cmd.Connection.Open();
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu lệnh SQL3: " + ex.Message);
            }
        }

        public static object Value(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            try
            {
                using (SqlCommand cmd = GetCommand(sql, args, cmdType))
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader[0]; // hoặc reader["TenCot"]
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu lệnh SQL: " + ex.Message);
            }
        }
        public static object ScalarQuery(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql, args, cmdType);
                cmd.Connection.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
