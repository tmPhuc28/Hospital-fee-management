using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyVienPhi.DAL
{
    public class DS
    {
        SqlConnection conn;

        public DataSet GetAccountGroup()
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SELECT MaLoai, TenLoai FROM Loai", conn);
                    comm.CommandType = CommandType.Text;
                    var dat = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    dat.Fill(ds);

                    return ds;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetDepartment()
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SELECT MAPK, TenPhongKham FROM PhongKham", conn);
                    comm.CommandType = CommandType.Text;
                    var dat = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    dat.Fill(ds);

                    return ds;

                } catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetExpenses()
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SELECT MaKhoanCP, TenKhoanCP FROM KhoanCP", conn);
                    comm.CommandType = CommandType.Text;
                    var dat = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    dat.Fill(ds);
                    return ds;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetFaculty()
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SELECT MaKhoa, TenKhoa FROM Khoa", conn);
                    comm.CommandType = CommandType.Text;
                    var dat = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    dat.Fill(ds);

                    return ds;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetEmloyee()
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SELECT MANV, TenNV FROM NhanVien", conn);
                    comm.CommandType = CommandType.Text;
                    var dat = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    dat.Fill(ds);

                    return ds;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
