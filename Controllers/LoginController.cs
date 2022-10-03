using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyVienPhi.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace QuanLyVienPhi.Controllers
{
    public class LoginController : Controller
    {
        DAL.Login login = new DAL.Login();
        DAL.DS ds = new DAL.DS();
        DAL.GetInfo info = new DAL.GetInfo();

        public IActionResult Login()
        {
            DataSet data = ds.GetAccountGroup();
            IList<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["TenLoai"].ToString().Trim(), Value = dr["MaLoai"].ToString().Trim() });
            }
            ViewBag.InfoAccountGroup = list;
            return View(data);
        }

        [HttpPost]
        public IActionResult Login(Account acc)
        {
            try
            {
                DataSet data = ds.GetAccountGroup();
                IList<SelectListItem> list = new List<SelectListItem>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    list.Add(new SelectListItem { Text = dr["TenLoai"].ToString().Trim(), Value = dr["MaLoai"].ToString().Trim() });
                }
                ViewBag.InfoAccountGroup = list;

                Account account = info.GetAccount(acc);
                if (ModelState.IsValid)
                {
                    var res = login.LoginAccount(acc);
                    if (Int32.Parse(res) == 1)
                    {
                        //TempData["mgs"] = "Đăng nhập thành công";
                        HttpContext.Session.SetString("session", JsonConvert.SerializeObject(account));

                        var ts = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("session"));
                        if (ts._sMaLoai.Trim().ToLower() == "AD".Trim().ToLower())
                        {
                            return RedirectToAction("Admin", "Home");
                        }
                        else if (ts._sMaLoai.ToLower().Trim() == "KT".ToLower().Trim())
                        {
                            return RedirectToAction("KeToan", "Home");
                        }
                        else
                            return RedirectToAction("NhanVien", "Home");
                    }
                    else if (Int32.Parse(res) == 2)
                    {
                        TempData["mgs"] = "Sai quyền đăng nhập";
                    }
                    else
                        TempData["mgs"] = "Sai tài khoản, mật khẩu hoặc quyền truy cập rồi!!!";
                }
            }
            catch (Exception e)
            {
                TempData["mgs"] = e.Message.ToString(); ;
            }
            return View();
        }
    }
}
