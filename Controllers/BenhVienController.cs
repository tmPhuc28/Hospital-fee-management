using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyVienPhi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace QuanLyVienPhi.Controllers
{
    public class BenhVienController : Controller
    {
        DAL.DS ds = new DAL.DS();
        DAL.InsertData inData = new DAL.InsertData();
        DAL.GetInfo getI = new DAL.GetInfo();
        DAL.UpdateData upData = new DAL.UpdateData();
        DAL.DeleteData delData = new DAL.DeleteData();

        //--------------------BACSI---------------------------
        public IActionResult BacSi(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                IList<Physician> listPhy = (List<Physician>)getI.GetAllPhysician();
                const int pageSize = 5;// danh sach hien thi
                if (page < 1)
                    page = 1;
                int recsCount = listPhy.Count;
                var pager = new PageList(recsCount, page, pageSize);
                int recSkip = (page - 1) * pageSize;
                var listData = listPhy.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(listData);
            }
            else
            {
                return NotFound();
            }

        }
        public ActionResult ThemBacSi()
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                DataSet department = ds.GetDepartment();
                List<SelectListItem> listDepartment = new List<SelectListItem>();
                foreach (DataRow dr in department.Tables[0].Rows)
                {
                    listDepartment.Add(new SelectListItem { Text = dr["TenPhongKham"].ToString().Trim(), Value = dr["MAPK"].ToString() });
                }
                ViewBag.InfoDepartment = listDepartment;

                DataSet faculty = ds.GetFaculty();
                List<SelectListItem> listFaculty = new List<SelectListItem>();
                foreach (DataRow dr in faculty.Tables[0].Rows)
                {
                    listFaculty.Add(new SelectListItem { Text = dr["TenKhoa"].ToString().Trim(), Value = dr["MaKhoa"].ToString().Trim() });
                }
                ViewBag.InfoFaculty = listFaculty;
                return View();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult ThemBacSi([Bind] Physician phy)
        {
            try
            {
                DataSet department = ds.GetDepartment();
                List<SelectListItem> listDepartment = new List<SelectListItem>();
                foreach (DataRow dr in department.Tables[0].Rows)
                {
                    listDepartment.Add(new SelectListItem { Text = dr["TenPhongKham"].ToString().Trim(), Value = dr["MAPK"].ToString() });
                }
                ViewBag.InfoDepartment = listDepartment;

                DataSet faculty = ds.GetFaculty();
                List<SelectListItem> listFaculty = new List<SelectListItem>();
                foreach (DataRow dr in faculty.Tables[0].Rows)
                {
                    listFaculty.Add(new SelectListItem { Text = dr["TenKhoa"].ToString().Trim(), Value = dr["MaKhoa"].ToString().Trim() });
                }
                ViewBag.InfoFaculty = listFaculty;

                if (ModelState.IsValid)
                {
                    inData.InsertPhysician(phy);
                    return RedirectToAction("BacSi");
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }

        public ActionResult SuaBacSi(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                if (id == null) return NotFound();
                Physician physician = getI.GetPhysicianByID(id);
                return View(physician);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaBacSi(string id, [Bind] Physician phy)
        {
            try
            {
                if (id == null) return NotFound();
                if (ModelState.IsValid)
                {
                    upData.UpdatePhysician(id, phy);
                    return RedirectToAction("BacSi");
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return View(upData);
        }

        public ActionResult ChiTietBacSi(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                if (id == null) return NotFound();
                VPhysician physician = getI.GetVPhysicianByID(id);
                return View(physician);
            }
            else
            {
                return NotFound();
            }

        }

        public ActionResult XoaBacSi(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                if (id == null) return NotFound();
                VPhysician physician = getI.GetVPhysicianByID(id);
                return View(physician);
            }
            else
            {
                return NotFound();
            }

        }

        public ActionResult XacNhan(string id)
        {
            if (id != null)
                delData.DeletePhysician(id);
            return RedirectToAction("BacSi");
        }
        //-------------------NHANVIEN--------------------
        public ActionResult NhanVien(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                IList<Employee> listEmp = (List<Employee>)getI.GetAllEmployee();
                const int pageSize = 5;// danh sach hien thi
                if (page < 1)
                    page = 1;
                int recsCount = listEmp.Count;
                var pager = new PageList(recsCount, page, pageSize);
                int recSkip = (page - 1) * pageSize;
                var listData = listEmp.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(listData);
            }
            else
            {
                return NotFound();
            }

        }
        public ActionResult ThemNhanVien()
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                return View();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult ThemNhanVien([Bind] Employee ee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inData.InsertEmployee(ee);
                    return RedirectToAction("NhanVien");
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }

        public ActionResult SuaNhanVien(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                if (id == null) return NotFound();
                Employee emp = getI.GetEmployeeByID(id);
                return View(emp);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaNhanVien(string id, [Bind] Employee ee)
        {
            try
            {
                if (id == null) return NotFound();
                if (ModelState.IsValid)
                {
                    upData.UpdateEmployee(id, ee);
                    return RedirectToAction("NhanVien");
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return View(upData);
        }

        public ActionResult XoaNhanVien(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                if (id == null) return NotFound();
                Employee emp = getI.GetEmployeeByID(id);
                return View(emp);
            }
            else
            {
                return NotFound();
            }

        }

        public ActionResult XacNhanXoaNV(string id)
        {
            if (id != null)
                delData.DeleteEmployee(id);
            return RedirectToAction("NhanVien");
        }

        //-----------------KHOA-----------------------
        public ActionResult Khoa(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                IList<Faculty> listFaculty = (List<Faculty>)getI.GetAllFaculty();
                const int pageSize = 5;// danh sach hien thi
                if (page < 1)
                    page = 1;
                int recsCount = listFaculty.Count;
                var pager = new PageList(recsCount, page, pageSize);
                int recSkip = (page - 1) * pageSize;
                var listData = listFaculty.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(listData);
            }
            else
            {
                return NotFound();
            }

        }

        public ActionResult ThemKhoa()
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                return View();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult ThemKhoa([Bind] Faculty fal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inData.InsertFaculty(fal);
                    return RedirectToAction("Khoa");
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }

        public ActionResult SuaKhoa(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                Faculty fal = getI.GetFacultyByID(id);
                return View(fal);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaKhoa(string id, [Bind] Faculty fal)
        {
            if (id == null) return NotFound();
            if (ModelState.IsValid)
            {
                upData.UpdateFaculty(id, fal);
                return RedirectToAction("Khoa");
            }
            return View();
        }
        //-----------------PHONGKHAM-------------------------
        public ActionResult PhongKham(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                IList<Department> listDept = (List<Department>)getI.GetAllDepartment();
                const int pageSize = 5;// danh sach hien thi
                if (page < 1)
                    page = 1;
                int recsCount = listDept.Count;
                var pager = new PageList(recsCount, page, pageSize);
                int recSkip = (page - 1) * pageSize;
                var listData = listDept.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(listData);
            }
            else
            {
                return NotFound();
            }

        }
        public ActionResult ThemPhongKham()
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                return View();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult ThemPhongKham([Bind] Department dep)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inData.InsertDepartment(dep);
                    return RedirectToAction("PhongKham");
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }

        public ActionResult SuaPhongKham(int id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                if (id < 0) return NotFound();
                Department dept = getI.GetDepartmentByID(id);
                return View(dept);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaPhongKham(int id, [Bind] Department dept)
        {
            if (id < 0) return NotFound();
            if (ModelState.IsValid)
            {
                upData.UpdateDepartment(id, dept);
                return RedirectToAction("PhongKham");
            }
            return View();
        }
    }
}
