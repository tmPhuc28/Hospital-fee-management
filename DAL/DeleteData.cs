using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyVienPhi.DAL
{
    public class DeleteData
    {
        SqlConnection conn;

        // xóa bác sĩ
        public void DeletePhysician(string id)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_XoaBS", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MABS", id);
                    comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // xóa nhân viên
        public void DeleteEmployee(string id)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_XoaNV", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MANV", id);
                    comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // xóa nhân viên
        public void DeletePatient(string id)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_XoaBN", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MABN", id);
                    comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // xóa nhân viên
        public void DeleteReceiptsDetails(int id, int idCP)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_XoaCTBL", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MABL", id);
                    comm.Parameters.AddWithValue("@MACP", idCP);
                    comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
