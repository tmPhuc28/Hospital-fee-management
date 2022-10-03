using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyVienPhi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace QuanLyVienPhi.Controllers
{
    public class TaiKhoanController : Controller
    {
        DAL.DS ds = new DAL.DS();
        DAL.InsertData inData = new DAL.InsertData();
        DAL.GetInfo getI = new DAL.GetInfo();
        DAL.UpdateData upData = new DAL.UpdateData();

        public IActionResult LoaiTaiKhoan(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (ViewBag.Session == "AD".ToLower().Trim())
            {
                IList<AccountGroup> listGroups = (List<AccountGroup>)getI.GetAllAccountGroup();
                const int pageSize = 5;// danh sach hien thi
                if (page < 1)
                    page = 1;
                int recsCount = listGroups.Count;
                var pager = new PageList(recsCount, page, pageSize);
                int recSkip = (page - 1) * pageSize;
                var listData = listGroups.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(listData);
            }
            else
            {
                return NotFound();
            }

        }
        public IActionResult ThemLoaiTaiKhoan()
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".ToLower().Trim())
            {
                // Lát chạy thử cái này coi có lỗi ko nha
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult ThemLoaiTaiKhoan([Bind] AccountGroup acGr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inData.InsertAccountGroup(acGr);
                    return RedirectToAction("LoaiTaiKhoan");
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }

        public IActionResult SuaLoaiTaiKhoan(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (ViewBag.Session == "AD".ToLower().Trim())
            {
                if (id == null) return NotFound();
                AccountGroup aGroup = getI.GetAccountGroupByID(id);
                return View(aGroup);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaLoaiTaiKhoan(string id, [Bind] AccountGroup aGroup)
        {
            try
            {
                if (id == null) return NotFound();
                if (ModelState.IsValid)
                {
                    upData.UpdateAccountGroup(id, aGroup);
                    return RedirectToAction("LoaiTaiKhoan");
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return View(upData);
        }
        //---------------- Tài khoản nhân viên
        public IActionResult DSTaiKhoan(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (ViewBag.Session == "AD".ToLower().Trim())
            {
                List<VAccount> listAcc = (List<VAccount>)getI.GetAllAccount();
                const int pageSize = 5;// danh sach hien thi
                if (page < 1)
                    page = 1;
                int recsCount = listAcc.Count;
                var pager = new PageList(recsCount, page, pageSize);
                int recSkip = (page - 1) * pageSize;
                var listData = listAcc.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(listData);
            }
            else
            {
                return NotFound();
            }

        }
        public IActionResult ThemTaiKhoan()
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (ViewBag.Session == "AD".ToLower().Trim())
            {

                DataSet accGr = ds.GetAccountGroup();
                List<SelectListItem> listAccGr = new List<SelectListItem>();
                foreach (DataRow dr in accGr.Tables[0].Rows)
                    listAccGr.Add(new SelectListItem { Text = dr["TenLoai"].ToString().Trim(), Value = dr["MaLoai"].ToString().Trim() });
                ViewBag.InfoAccGr = listAccGr;

                DataSet ee = ds.GetEmloyee();
                List<SelectListItem> listEmp = new List<SelectListItem>();
                foreach (DataRow dr in ee.Tables[0].Rows)
                    listEmp.Add(new SelectListItem { Text = dr["TenNV"].ToString().Trim(), Value = dr["MANV"].ToString().Trim() });
                ViewBag.InfoEmp = listEmp;
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult ThemTaiKhoan([Bind] Account acc)
        {
            try
            {
                DataSet accGr = ds.GetAccountGroup();
                List<SelectListItem> listAccGr = new List<SelectListItem>();
                foreach (DataRow dr in accGr.Tables[0].Rows)
                    listAccGr.Add(new SelectListItem { Text = dr["TenLoai"].ToString().Trim(), Value = dr["MaLoai"].ToString().Trim() });
                ViewBag.InfoAccGr = listAccGr;

                DataSet ee = ds.GetEmloyee();
                List<SelectListItem> listEmp = new List<SelectListItem>();
                foreach (DataRow dr in ee.Tables[0].Rows)
                    listEmp.Add(new SelectListItem { Text = dr["TenNV"].ToString().Trim(), Value = dr["MANV"].ToString().Trim() });
                ViewBag.InfoEmp = listEmp;

                if (ModelState.IsValid)
                {
                    inData.InsertAccount(acc);
                    return RedirectToAction("DSTaiKhoan");
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }

        public IActionResult SuaTaiKhoan(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (ViewBag.Session == "AD".ToLower().Trim())
            {
                if (id == null) return NotFound();
                Account ac = getI.GetAccountById(id);
                try
                {
                    DataSet accGr = ds.GetAccountGroup();
                    List<SelectListItem> listAccGr = new List<SelectListItem>();
                    foreach (DataRow dr in accGr.Tables[0].Rows)
                        listAccGr.Add(new SelectListItem { Text = dr["TenLoai"].ToString().Trim(), Value = dr["MaLoai"].ToString().Trim() });
                    ViewBag.InfoAccGr = listAccGr;

                    DataSet ee = ds.GetEmloyee();
                    List<SelectListItem> listEmp = new List<SelectListItem>();
                    foreach (DataRow dr in ee.Tables[0].Rows)
                        listEmp.Add(new SelectListItem { Text = dr["TenNV"].ToString().Trim(), Value = dr["MANV"].ToString().Trim() });
                    ViewBag.InfoEmp = listEmp;
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return View(ac);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaTaiKhoan(string id, [Bind] Account acc)
        {
            try
            {
                if (id == null) return NotFound();

                if (ModelState.IsValid)
                {
                    upData.UpdateAccount(id, acc);
                    return RedirectToAction("DSTaiKhoan");
                }
                return View(upData);
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }
    }
}
