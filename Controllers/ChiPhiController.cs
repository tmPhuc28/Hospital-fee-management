using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyVienPhi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace QuanLyVienPhi.Controllers
{
    public class ChiPhiController : Controller
    {
        DAL.GetInfo getI = new DAL.GetInfo();
        DAL.InsertData inData = new DAL.InsertData();
        DAL.UpdateData upData = new DAL.UpdateData();

        public IActionResult ChiPhi(int page = 1)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                IList<Expenses> list = (List<Expenses>)getI.GetAllExpenses();
                const int pageSize = 3;// danh sach hien thi
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

        public IActionResult ThemChiPhi()
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
        public IActionResult ThemChiPhi([Bind] Expenses exp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inData.InsertExpenses(exp);
                    return RedirectToAction("ChiPhi");
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return View();
        }

        public IActionResult SuaChiPhi(int id)
        {
            // khai báo và lấy thông tin từ sesstion
            var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
            ViewBag.Session = ts._sMaLoai.ToLower().Trim();
            if (ViewBag.Session == "AD".Trim().ToLower() || ViewBag.Session == "KT".ToLower())
            {
                if (id < 0) return NotFound();
                Expenses exp = getI.GetExpensesByID(id);
                return View(exp);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaChiPhi(int id, [Bind] Expenses exp)
        {
            try
            {
                if (id < 0) return NotFound();
                if (ModelState.IsValid)
                {
                    upData.UpdateExpenses(id, exp);
                    return RedirectToAction("ChiPhi");
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return View(exp);
        }
    }
}
