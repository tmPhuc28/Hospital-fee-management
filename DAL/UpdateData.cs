using QuanLyVienPhi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyVienPhi.DAL
{
    public class UpdateData
    {
        SqlConnection conn;
        public string UpdatePatients(string id,Patients bn)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_UpdateBN", conn);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@MABN", id);
                    com.Parameters.AddWithValue("@SoCMND", bn._sSoCMND);
                    com.Parameters.AddWithValue("@HoTen", bn._sHoTen);
                    com.Parameters.AddWithValue("@NgaySinh", bn._dNgaySinh);
                    com.Parameters.AddWithValue("@GioiTinh", bn._sGioiTinh);
                    com.Parameters.AddWithValue("@SDT", bn._sSDT);
                    com.Parameters.AddWithValue("@DiaChi", bn._sDiaChi);
                    com.Parameters.AddWithValue("@PhongKham", bn._nPhongKham);
                    com.Parameters.AddWithValue("@NgayKham", bn._dNgayKham);
                    conn.Open();

                    com.ExecuteNonQuery();
                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdatePhysician(string id,Physician bs)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_UpdateBS", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MABS", id);
                    comm.Parameters.AddWithValue("@TenBS", bs._sHoTen);
                    comm.Parameters.AddWithValue("@NgaySinh", bs._dNgaySinh);
                    comm.Parameters.AddWithValue("@DiaChi", bs._sDiaChi);
                    comm.Parameters.AddWithValue("@GioiTinh", bs._sGioiTinh);
                    comm.Parameters.AddWithValue("@SDT", bs._sSDT);
                    comm.Parameters.AddWithValue("@Email", bs._sEmail);
                    comm.Parameters.AddWithValue("@MAPK", bs._nPhongKham);
                    comm.Parameters.AddWithValue("@MaKhoa", bs._sKhoa);

                    comm.ExecuteNonQuery();
                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateEmployee(string id,Employee ee)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_UpdateNV", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MANV", id);
                    comm.Parameters.AddWithValue("@TenNV", ee._sHoTen);
                    comm.Parameters.AddWithValue("@NgaySinh", ee._dNgaySinh);
                    comm.Parameters.AddWithValue("@DiaChi", ee._sDiaChi);
                    comm.Parameters.AddWithValue("@GioiTinh", ee._sGioiTinh);
                    comm.Parameters.AddWithValue("@SDT", ee._sSDT);
                    comm.Parameters.AddWithValue("@Email", ee._sEmail);

                    comm.ExecuteNonQuery();
                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateAccountGroup(string id,AccountGroup ag)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_UpdateLoai", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MaLoai", id);
                    comm.Parameters.AddWithValue("@TenLoai", ag._sTenLoai);

                    comm.ExecuteNonQuery();
                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateDepartment(int id,Department dpm)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_UpdatePK", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@MAPK", id);
                    comm.Parameters.AddWithValue("@TenPK", dpm._sTenPK);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateExpenses(int id,Expenses ex)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_UpdateCP", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@MACP", id);
                    comm.Parameters.AddWithValue("@TenCP", ex._sTenCP);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateAccount(string id,Account acc)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_UpdateTaiKhoan", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@TaiKhoan", id);
                    comm.Parameters.AddWithValue("@MatKhau", acc._sMatKhau);
                    comm.Parameters.AddWithValue("@MANV", acc._sMANV);
                    comm.Parameters.AddWithValue("@MaLoai", acc._sMaLoai);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateFaculty(string id,Faculty fal)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_UpdateKhoa", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@MaKhoa", id);
                    comm.Parameters.AddWithValue("@TenKhoa", fal._sTenKhoa);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateReceipts(string id, string user, Receipts rec)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_UpdateBL", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@SoBienLai", rec._nSoBienLai);
                    comm.Parameters.AddWithValue("@MABN", id);
                    comm.Parameters.AddWithValue("@NgayThanhToan", rec._dNgayThanhToan);
                    comm.Parameters.AddWithValue("@TaiKhoan", user);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string UpdateReceiptsDetails(int id, ReceiptsDetails rd)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();


                    var comm = new SqlCommand("SP_UpdateCTBL", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@MABL", rd._nSoBienLai);
                    comm.Parameters.AddWithValue("@MACP", id);
                    comm.Parameters.AddWithValue("@SoTien", rd._fSoTien);

                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
                }
                catch (Exception e)
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
