using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyVienPhi.Models;

namespace QuanLyVienPhi.DAL
{
    public class Login
    {
        public string LoginAccount(Account acc)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("DangNhap", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@TaiKhoan", acc._sTaiKhoan);
                    comm.Parameters.AddWithValue("@MatKhau", acc._sMatKhau);
                    comm.Parameters.AddWithValue("@MaLoai", acc._sMaLoai);

                    comm.ExecuteNonQuery();

                    object res = comm.ExecuteScalar();

                    int code = Convert.ToInt32(res);
                    return code.ToString();
                }catch(Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
