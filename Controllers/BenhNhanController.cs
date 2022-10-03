using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyVienPhi.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace QuanLyVienPhi.Controllers
{
    public class BenhNhanController : Controller
    {
        DAL.InsertData inData = new DAL.InsertData();
        DAL.DS ds = new DAL.DS();
        DAL.GetInfo info = new DAL.GetInfo();
        DAL.UpdateData upData = new DAL.UpdateData();
        DAL.DeleteData delData = new DAL.DeleteData();

        public IActionResult BenhNhan(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            List<Patients> list = (List<Patients>)info.GetAllPatients();
            const int pageSize = 5;// danh sach hien thi
            if (page < 1)
                page = 1;
            int recsCount = list.Count;
            var pager = new PageList(recsCount, page, pageSize);
            int recSkip = (page - 1) * pageSize;
            var listData = list.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(listData);
        }

        public IActionResult ThemBenhNhan()
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            DataSet data = ds.GetDepartment();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["TenPhongKham"].ToString().Trim(), Value = dr["MAPK"].ToString() });
            }
            ViewBag.InfoDepartment = list;
            return View();
        }

        [HttpPost]
        public IActionResult ThemBenhNhan([Bind] Patients pat)
        {
            try
            {
                DataSet data = ds.GetDepartment();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    list.Add(new SelectListItem { Text = dr["TenPhongKham"].ToString().Trim(), Value = dr["MAPK"].ToString() });
                }
                ViewBag.InfoDepartment = list;

                if (ModelState.IsValid)
                {
                    inData.InsertPatients(pat);
                    return RedirectToAction("BenhNhan");
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString();
            }
            return View();
        }

        public IActionResult SuaBenhNhan(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (id == null) return NotFound();
            Patients patients = info.GetPatientsByID(id);
            return View(patients);
        }

        [HttpPost]
        public IActionResult SuaBenhNhan(string id, [Bind] Patients pat)
        {
            try
            {
                if (id == null) return NotFound();
                if (ModelState.IsValid)
                {
                    upData.UpdatePatients(id, pat);
                    return RedirectToAction("BenhNhan");
                }
            }
            catch (Exception)
            {

            }
            return View();
        }

        public IActionResult ChiTietBenhNhan(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            VPatients vPatients = info.GetVPatientsByID(id);
            return View(vPatients);
        }

        public IActionResult XoaBenhNhan(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (id == null) return NotFound();
            VPatients vPatients = info.GetVPatientsByID(id);
            return View(vPatients);
        }

        public IActionResult XacNhan(string id)
        {
            if (id != null)
                delData.DeletePatient(id);
            return RedirectToAction("BenhNhan");
        }

        public IActionResult BienLai(string id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".ToLower().Trim() || ViewBag.Session == "KT".ToLower().Trim())
            {
                DataSet data = ds.GetExpenses();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (DataRow dr in data.Tables[0].Rows)
                    list.Add(new SelectListItem { Text = dr["TenKhoanCP"].ToString().Trim(), Value = dr["MaKhoanCP"].ToString().Trim() });
                ViewBag.InfoExpenses = list;

                Receipts receipts = info.GetReceiptsByIDBenhNhan(id);
                return View(receipts);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult BienLai(string id, [Bind] Receipts rec, [Bind] ReceiptsDetails rd)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            DataSet data = ds.GetExpenses();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in data.Tables[0].Rows)
                list.Add(new SelectListItem { Text = dr["TenKhoanCP"].ToString().Trim(), Value = dr["MaKhoanCP"].ToString().Trim() });
            ViewBag.InfoExpenses = list;

            try
            {
                if (id == null) return NotFound();
                if (ModelState.IsValid)
                {
                    upData.UpdateReceipts(id, ts._sTaiKhoan, rec);
                    inData.InsertReceiptsDetails(rec._nSoBienLai, rd);
                    return View();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return View();
        }

        public IActionResult DSBienLai(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                IList<Receipts> list = (List<Receipts>)info.GetAllReceipts();
                const int pageSize = 5;// danh sach hien thi
                if (page < 1)
                    page = 1;
                int recsCount = list.Count;
                var pager = new PageList(recsCount, page, pageSize);
                int recSkip = (page - 1) * pageSize;
                var listData = list.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(listData);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult ThanhToan(int id, string MaBN)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (ViewBag.Session == "AD".ToLower().Trim() || ViewBag.Session == "KT".Trim().ToLower())
            {
                Patients patients = info.GetPatientsByID(MaBN);
                ViewBag.CMND = patients._sSoCMND;
                ViewBag.MABN = patients._sMaBN;
                ViewBag.HoTen = patients._sHoTen;
                ViewBag.NgayKham = patients._dNgayKham;
                ViewBag.GioiTinh = patients._sGioiTinh;
                ViewBag.DiaChi = patients._sDiaChi;
                ViewBag.SDT = patients._sSDT;
                Receipts rd = info.GetReceiptsByID(id);
                ViewBag.SoBL = rd._nSoBienLai;
                ViewBag.NgayThanhToan = rd._dNgayThanhToan;
                ViewBag.TongTien = rd._fTongTien;
                IList<VReceiptsDetails> list = (List<VReceiptsDetails>)info.GetVReceiptsDetails(id);
                return View(list);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult XoaChiTietBienLai(int id, int idCP)
        {
            if (id < 0 && idCP < 0) return NotFound();
            delData.DeleteReceiptsDetails(id, idCP);
            return RedirectToAction("DSBienLai");
        }

        public IActionResult SuaChiTietBienLai(int id, int idBL)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (ViewBag.Session == "AD".ToLower().Trim() || ViewBag.Session == "KT".ToLower().Trim())
            {
                if (id < 0 && idBL < 0) return NotFound();
                ReceiptsDetails receipts = info.GetReceiptsDetailsByID(idBL, id);
                return View(receipts);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult SuaChiTietBienLai(int id, int idBL, [Bind] ReceiptsDetails receipts)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();

            if (id < 0 && idBL < 0) return NotFound();
            if (ModelState.IsValid)
            {
                upData.UpdateReceiptsDetails(id, receipts);
                return RedirectToAction("DSBienLai");
            }
            return View(upData);
        }
    }
}
