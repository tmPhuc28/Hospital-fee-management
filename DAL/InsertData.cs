using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using QuanLyVienPhi.Models;

namespace QuanLyVienPhi.DAL
{
    public class InsertData
    {
        SqlConnection conn;
        public string InsertPatients(Patients bn)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    SqlCommand com = new SqlCommand("SP_ThemBN", conn);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@MABN", ConnectionString.g_sRandomString("BN"));
                    com.Parameters.AddWithValue("@SoCMND", bn._sSoCMND);
                    com.Parameters.AddWithValue("@HoTen", bn._sHoTen);
                    com.Parameters.AddWithValue("@NgaySinh", bn._dNgaySinh);
                    com.Parameters.AddWithValue("@GioiTinh", bn._sGioiTinh);
                    com.Parameters.AddWithValue("@SDT", bn._sSDT);
                    com.Parameters.AddWithValue("@DiaChi", bn._sDiaChi);
                    com.Parameters.AddWithValue("@PhongKham", (int)bn._nPhongKham);
                    com.Parameters.AddWithValue("@NgayKham", bn._dNgayKham);
                    com.ExecuteNonQuery();
                    return ("Successful!!!");
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

        public string InsertPhysician(Physician bs)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_ThemBS", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MABS", ConnectionString.g_sRandomString("BS"));
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

        public string InsertEmployee(Employee ee)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_ThemNV", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MANV", ConnectionString.g_sRandomString("NV"));
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

        public string InsertAccountGroup(AccountGroup ag)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_ThemLoai", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@MaLoai", ag._sMaLoai);
                    comm.Parameters.AddWithValue("@TenLoai", ag._sTenLoai);

                    comm.ExecuteNonQuery();
                    return ("Successful!!!");
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

        public string InsertDepartment(Department dpm)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_ThemPK", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@TenPK", dpm._sTenPK);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
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

        public string InsertExpenses(Expenses ex)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_ThemCP", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@TenCP", ex._sTenCP);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
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

        public string InsertAccount(Account acc)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_ThemTaiKhoan", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@TaiKhoan", acc._sTaiKhoan);
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

        public string InsertFaculty(Faculty fal)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var comm = new SqlCommand("SP_ThemKhoa", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@MaKhoa", fal._sMaKhoa);
                    comm.Parameters.AddWithValue("@TenKhoa", fal._sTenKhoa);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
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

        public string InsertReceipts(Receipts rec)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_ThemBienLai", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@MABN", rec._sMaBN);
                    comm.Parameters.AddWithValue("@TaiKhoan", rec._sTaiKhoan);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
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

        public string InsertReceiptsDetails(int id,ReceiptsDetails rd)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var comm = new SqlCommand("SP_TongTien", conn);
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@MABL", rd._nSoBienLai);
                    comm.Parameters.AddWithValue("@MACP", rd._nKhoanCP);
                    comm.Parameters.AddWithValue("@Gia", rd._fSoTien);
                    comm.ExecuteNonQuery();

                    return ("Successful!!!");
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
