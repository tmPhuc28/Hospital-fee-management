using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyVienPhi.Models;

namespace QuanLyVienPhi.DAL
{
    public class GetInfo
    {
        SqlConnection conn;

        // Lấy thông tin tài khoản đăng nhập
        public Account GetAccount(Account acc)
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    Account account = new Account();
                    string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", acc._sTaiKhoan);
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        account._sTaiKhoan = sdr["TenDangNhap"].ToString().Trim();
                        account._sMatKhau = sdr["MatKhau"].ToString().Trim();
                        account._sMaLoai = sdr["MaLoai"].ToString().Trim();
                        account._sMANV = sdr["MANV"].ToString().Trim();
                    }
                    return account;
                }
                catch (Exception)
                {
                    conn.Close();
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Lấy danh sách tất cả bệnh nhân
        public IEnumerable<Patients> GetAllPatients()
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                var list = new List<Patients>();
                try
                {
                    string sql =    "SELECT * FROM BenhNhan";
                    conn.Open();
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        Patients pat = new Patients();
                        pat._sMaBN = sdr["MABN"].ToString();
                        pat._sSoCMND = sdr["SoCMND"].ToString();
                        pat._sHoTen = sdr["HoTen"].ToString();
                        pat._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        pat._sGioiTinh = sdr["GioiTinh"].ToString();
                        pat._sDiaChi = sdr["DiaChi"].ToString();
                        pat._nPhongKham = (int)sdr["MAPK"];
                        pat._sSDT = sdr["SDT"].ToString();
                        pat._dNgayKham = (DateTime)sdr["NgayKham"];

                        list.Add(pat);
                    }

                    return list;
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

        // lấy thông tin bệnh nhân theo mã bệnh nhân
        public Patients GetPatientsByID(string ID)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                Patients pat = new Patients();
                try
                {
                    string sql = "SELECT * FROM BenhNhan WHERE MABN = @id";
                    conn.Open();
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", ID);
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        pat._sMaBN = sdr["MABN"].ToString();
                        pat._sSoCMND = sdr["SoCMND"].ToString();
                        pat._sHoTen = sdr["HoTen"].ToString();
                        pat._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        pat._sGioiTinh = sdr["GioiTinh"].ToString();
                        pat._sDiaChi = sdr["DiaChi"].ToString();
                        pat._nPhongKham = (int)sdr["MAPK"];
                        pat._sSDT = sdr["SDT"].ToString();
                        pat._dNgayKham = (DateTime)sdr["NgayKham"];
                    }

                    return pat;
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

        // lấy thông tin bệnh nhân theo mã bệnh nhân
        public VPatients GetVPatientsByID(string ID)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                VPatients pat = new VPatients();
                try
                {
                    string sql = "SELECT * FROM VBenhNhan WHERE MABN = @id";
                    conn.Open();
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", ID);
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        pat._sMaBN = sdr["MABN"].ToString();
                        pat._sSoCMND = sdr["SoCMND"].ToString();
                        pat._sHoTen = sdr["HoTen"].ToString();
                        pat._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        pat._sGioiTinh = sdr["GioiTinh"].ToString();
                        pat._sDiaChi = sdr["DiaChi"].ToString();
                        pat._sTenPK = sdr["TenPhongKham"].ToString().Trim();
                        pat._sSDT = sdr["SDT"].ToString();
                        pat._dNgayKham = (DateTime)sdr["NgayKham"];
                    }

                    return pat;
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

        // Lấy danh sách tất cả bác sĩ có trong database
        public IEnumerable<Physician> GetAllPhysician()
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    IList<Physician> list = new List<Physician>();
                    conn.Open();
                    string sql = "SELECT * FROM BacSi";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        Physician phy = new Physician();
                        phy._sMaBS = sdr["MABS"].ToString().Trim();
                        phy._sHoTen = sdr["TenBS"].ToString().Trim();
                        phy._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        phy._sDiaChi = sdr["DiaChi"].ToString().Trim();
                        phy._sGioiTinh = sdr["GioiTinh"].ToString().Trim();
                        phy._sSDT = sdr["SDT"].ToString().Trim();
                        phy._sEmail = sdr["Email"].ToString().Trim();
                        phy._nPhongKham = (int)sdr["MAPK"];
                        phy._sKhoa = sdr["MaKhoa"].ToString().Trim();

                        list.Add(phy);
                    }

                    return list;
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

        // Lấy danh thông tin bác sĩ theo mã bác sĩ
        public Physician GetPhysicianByID(string id)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                Physician phy = new Physician();
                try
                {
                    string sql = "SELECT * FROM BacSi WHERE MABS = @id";
                    conn.Open();
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        phy._sMaBS = sdr["MABS"].ToString().Trim();
                        phy._sHoTen = sdr["TenBS"].ToString().Trim();
                        phy._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        phy._sDiaChi = sdr["DiaChi"].ToString().Trim();
                        phy._sGioiTinh = sdr["GioiTinh"].ToString().Trim();
                        phy._sSDT = sdr["SDT"].ToString().Trim();
                        phy._sEmail = sdr["Email"].ToString().Trim();
                        phy._nPhongKham = (int)sdr["MAPK"];
                        phy._sKhoa = sdr["MaKhoa"].ToString().Trim();
                    }

                    return phy;
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

        // Lấy danh thông tin bác sĩ theo mã bác sĩ
        public VPhysician GetVPhysicianByID(string id)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                VPhysician phy = new VPhysician();
                try
                {
                    string sql = "SELECT * FROM VBacSi WHERE MABS = @id";
                    conn.Open();
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        phy._sMaBS = sdr["MABS"].ToString().Trim();
                        phy._sHoTen = sdr["TenBS"].ToString().Trim();
                        phy._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        phy._sDiaChi = sdr["DiaChi"].ToString().Trim();
                        phy._sGioiTinh = sdr["GioiTinh"].ToString().Trim();
                        phy._sSDT = sdr["SDT"].ToString().Trim();
                        phy._sEmail = sdr["Email"].ToString().Trim();
                        phy._sTenPK = sdr["TenPhongKham"].ToString();
                        phy._sTenKhoa = sdr["TenKhoa"].ToString().Trim();
                    }

                    return phy;
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

        // Lấy danh sách nhân viên
        public IEnumerable<Employee> GetAllEmployee()
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    IList<Employee> list = new List<Employee>();
                    conn.Open();
                    string sql = "SELECT * FROM NhanVien";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        Employee emp = new Employee();
                        emp._sMaNV = sdr["MANV"].ToString().Trim();
                        emp._sHoTen = sdr["TenNV"].ToString().Trim();
                        emp._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        emp._sDiaChi = sdr["DiaChi"].ToString().Trim();
                        emp._sGioiTinh = sdr["GioiTinh"].ToString().Trim();
                        emp._sSDT = sdr["SDT"].ToString().Trim();
                        emp._sEmail = sdr["Email"].ToString().Trim();

                        list.Add(emp);
                    }

                    return list;
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

        // Lấy danh thong tin nhân viên theo mã nhân viên
        public Employee GetEmployeeByID(string id)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    Employee emp = new Employee();
                    conn.Open();
                    string sql = "SELECT * FROM NhanVien WHERE MANV = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        emp._sMaNV = sdr["MANV"].ToString().Trim();
                        emp._sHoTen = sdr["TenNV"].ToString().Trim();
                        emp._dNgaySinh = (DateTime)sdr["NgaySinh"];
                        emp._sDiaChi = sdr["DiaChi"].ToString().Trim();
                        emp._sGioiTinh = sdr["GioiTinh"].ToString().Trim();
                        emp._sSDT = sdr["SDT"].ToString().Trim();
                        emp._sEmail = sdr["Email"].ToString().Trim();
                    }

                    return emp;
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

        //Lấy loại tài khoản theo mã loại
        public AccountGroup GetAccountGroupByID(string id)
        {
            AccountGroup acc = new AccountGroup();
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var sql = "SELECT * FROM Loai WHERE MaLoai = @MaLoai";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@MaLoai", id);
                    SqlDataReader sdr = comm.ExecuteReader();
                    while (sdr.Read())
                    {
                        acc._sMaLoai = sdr["MaLoai"].ToString().Trim();
                        acc._sTenLoai = sdr["TenLoai"].ToString().Trim();
                    }

                    return acc;
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

        // Lấy danh sách khoa
        public IEnumerable<Faculty> GetAllFaculty()
        {
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                IList<Faculty> list = new List<Faculty>();
                try
                {
                    conn.Open();
                    string sql = "SELECT MaKhoa, TenKhoa, SoLuong FROM Khoa";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    var sda = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Faculty faculty = new Faculty();

                        faculty._sMaKhoa = dr["MaKhoa"].ToString().Trim();
                        faculty._sTenKhoa = dr["TenKhoa"].ToString().Trim();
                        faculty._nSoLuong = (int)dr["SoLuong"];

                        list.Add(faculty);
                    }

                    return list;
                }
                catch (Exception)
                {
                    return list;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Lấy thông tin khoa theo mã khoa
        public Faculty GetFacultyByID(string id)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                Faculty fal = new Faculty();
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM Khoa WHERE MaKhoa = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = comm.ExecuteReader();
                    while (sdr.Read())
                    {
                        fal._sMaKhoa = sdr["MaKhoa"].ToString().Trim();
                        fal._sTenKhoa = sdr["TenKhoa"].ToString().Trim();
                        //fal._dSoLuong = (int)sdr["SoLuong"];
                    }

                    return fal;
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

        // Lấy danh sách phòng khám
        public IEnumerable<Department> GetAllDepartment()
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                IList<Department> list = new List<Department>();
                try
                {
                    conn.Open();
                    //var sql = ;
                    var comm = new SqlCommand("SELECT MAPK, TenPhongKham FROM PhongKham", conn);
                    comm.CommandType = CommandType.Text;
                    var sda = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        Department dept = new Department();
                        dept._nMaPK = (int)dr["MAPK"];
                        dept._sTenPK = dr["TenPhongKham"].ToString();

                        list.Add(dept);
                    }
                    return list;
                }
                catch (Exception)
                {
                    return list;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Lấy danh sách phòng khám
        public Department GetDepartmentByID(int id)
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                Department dept = new Department();
                try
                {
                    conn.Open();
                    //var sql = ;
                    var comm = new SqlCommand("SELECT * FROM PhongKham WHERE MAPK = @id", conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = comm.ExecuteReader();
                    while (sdr.Read())
                    {
                        dept._nMaPK = (int)sdr["MAPK"];
                        dept._sTenPK = sdr["TenPhongKham"].ToString();
                    }
                    return dept;
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

        //Lấy loại tài khoản theo mã loại
        public IEnumerable<AccountGroup> GetAllAccountGroup()
        {
            IList<AccountGroup> listGroups = new List<AccountGroup>();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var sql = "SELECT * FROM Loai";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    SqlDataReader sdr = comm.ExecuteReader();
                    while (sdr.Read())
                    {
                        AccountGroup acc = new AccountGroup();
                        acc._sMaLoai = sdr["MaLoai"].ToString().Trim();
                        acc._sTenLoai = sdr["TenLoai"].ToString().Trim();

                        listGroups.Add(acc);
                    }

                    return listGroups;
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

        // Lấy tài khoản theo tên đăng nhập
        public Account GetAccountById(string _sTaiKhoan)
        {
            Account acc = new Account();
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", _sTaiKhoan);
                    SqlDataReader sdr = comm.ExecuteReader();
                    while (sdr.Read())
                    {
                        acc._sTaiKhoan = sdr["TenDangNhap"].ToString().Trim();
                        acc._sMatKhau = sdr["MatKhau"].ToString().Trim();
                        acc._sMANV = sdr["MANV"].ToString().Trim();
                        acc._sMaLoai = sdr["MaLoai"].ToString().Trim();
                    }
                    return acc;
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
        
        // Lấy tất cả tài khoản có trong database
        public IEnumerable<VAccount> GetAllAccount()
        {
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                var list = new List<VAccount>();
                try
                {
                    string sql = "SELECT * FROM VTaiKhoan";
                    conn.Open();
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        VAccount vAcc= new VAccount();
                        vAcc._sTaiKhoan = sdr["TenDangNhap"].ToString();
                        vAcc._sMatKhau = sdr["MatKhau"].ToString();
                        vAcc._sMANV = sdr["MANV"].ToString();
                        vAcc._sTenLoai = sdr["TenLoai"].ToString();
                        vAcc._sHoTen = sdr["TenNV"].ToString();
                        list.Add(vAcc);
                    }

                    return list;
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
    
        // Lấy danh sách khoản chi phí
        public IEnumerable<Expenses> GetAllExpenses()
        {
            IList<Expenses> list = new List<Expenses>();
            using(conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var sql = "SELECT MaKhoanCP, TenKhoanCP FROM KhoanCP";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    SqlDataReader sdr = comm.ExecuteReader();
                    while (sdr.Read())
                    {
                        Expenses exp = new Expenses();

                        exp._nKhoanCP = (int)sdr["MaKhoanCP"];
                        exp._sTenCP = sdr["TenKhoanCP"].ToString().Trim();

                        list.Add(exp);
                    }

                    return list;
                }
                catch (Exception)
                {
                    return list;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Lấy thông tin khoản chi phí theo mã khoản chi phí
        public Expenses GetExpensesByID(int id)
        {
            Expenses exp = new Expenses();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();

                    var sql = "SELECT MaKhoanCP, TenKhoanCP FROM KhoanCP WHERE MaKhoanCP = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = comm.ExecuteReader();
                    while (sdr.Read())
                    {
                        exp._nKhoanCP = (int)sdr["MaKhoanCP"];
                        exp._sTenCP = sdr["TenKhoanCP"].ToString().Trim();
                    }

                    return exp;
                }
                catch (Exception)
                {
                    return exp;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Receipts GetReceiptsByIDBenhNhan(string id)
        {
            Receipts rec = new Receipts();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var sql = "SELECT * FROM BienLai WHERE MABN = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {

                        rec._nSoBienLai = (int)sdr["SoBienLai"];
                        rec._sMaBN = sdr["MABN"].ToString();
                        rec._dNgayThanhToan = (DateTime)sdr["NgayThanhToan"];
                        rec._fTongTien = (float)sdr["TongTien"];
                        rec._sTaiKhoan = sdr["TaiKhoan"].ToString();
                    }

                    return rec;
                }
                catch (Exception)
                {
                    conn.Close();
                    return rec;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public IEnumerable<Receipts> GetAllReceipts()
        {
            IList<Receipts> list = new List<Receipts>();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var sql = "SELECT * FROM BienLai INNER JOIN BenhNhan ON BienLai.MABN = BenhNhan.MABN";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    SqlDataReader sdr = comm.ExecuteReader();

                    while (sdr.Read())
                    {
                        Receipts rec = new Receipts();
                        rec._sMaBN = sdr["MABN"].ToString();
                        rec._nSoBienLai = (int)sdr["SoBienLai"];
                        rec._sHoTen = sdr["HoTen"].ToString();
                        rec._dNgayThanhToan = (DateTime)sdr["NgayThanhToan"];
                        rec._fTongTien = (double)sdr["TongTien"];
                        rec._sTaiKhoan = sdr["TaiKhoan"].ToString();

                        list.Add(rec);
                    }

                    return list;
                }
                catch (Exception)
                {
                    return list;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Receipts GetReceiptsByID(int id)
        {
            Receipts rec = new Receipts();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var sql = "SELECT * FROM BienLai WHERE SoBienLai = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    var adt = new SqlDataAdapter(comm);
                    var tb = new DataSet();
                    adt.Fill(tb);
                    foreach(DataRow sdr in tb.Tables[0].Rows )
                    {
                        rec._nSoBienLai = (int)sdr["SoBienLai"];
                        rec._sMaBN = sdr["MABN"].ToString();
                        rec._dNgayThanhToan = (DateTime)sdr["NgayThanhToan"];
                        rec._fTongTien = (double)sdr["TongTien"];
                        rec._sTaiKhoan = sdr["TaiKhoan"].ToString();
                    }

                    return rec;
                }
                catch (Exception)
                {
                    conn.Close();
                    return rec;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public IEnumerable<VReceiptsDetails> GetVReceiptsDetails(int id)
        {
            IList<VReceiptsDetails> list = new List<VReceiptsDetails>();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    var sql = "SELECT * FROM VCT_BienLai WHERE MABL = @id";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    var sda = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        VReceiptsDetails details = new VReceiptsDetails();
                        details._nSoBienLai = (int)dr["MABL"];
                        details._nKhoanCP = (int)dr["MACP"];
                        details._sTenCP = dr["TenKhoanCP"].ToString();
                        details._fSoTien = (double)dr["SoTien"];

                        list.Add(details);
                    }
                    return list;
                }
                catch (Exception)
                {
                    return list;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public VReceiptsDetails GetVReceiptsDetailsByID(int id, int idCP)
        {
            VReceiptsDetails details = new VReceiptsDetails();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    var sql = "SELECT * FROM VCT_BienLai WHERE MABL = @id AND MACP = @idCP";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@idCP", idCP);
                    var sda = new SqlDataAdapter(comm);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        details._nSoBienLai = (int)dr["MABL"];
                        details._nKhoanCP = (int)dr["MACP"];
                        details._sTenCP = dr["TenKhoanCP"].ToString();
                        details._fSoTien = (double)dr["SoTien"];
                    }
                    return details;
                }
                catch (Exception)
                {
                    return details;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public ReceiptsDetails GetReceiptsDetailsByID(int id, int idCP)
        {
            ReceiptsDetails rec = new ReceiptsDetails();
            using (conn = new SqlConnection(ConnectionString.g_sConnection))
            {
                try
                {
                    conn.Open();
                    var sql = "SELECT * FROM CT_BienLai WHERE MABL = @id AND MACP = @idCP";
                    var comm = new SqlCommand(sql, conn);
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@idCP", idCP);
                    var adt = new SqlDataAdapter(comm);
                    var tb = new DataSet();
                    adt.Fill(tb);
                    foreach (DataRow sdr in tb.Tables[0].Rows)
                    {
                        rec._nSoBienLai = (int)sdr["MABL"];
                        rec._nKhoanCP = (int)sdr["MACP"];
                        rec._fSoTien = (double)sdr["SoTien"];
                    }

                    return rec;
                }
                catch (Exception)
                {
                    conn.Close();
                    return rec;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
