using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using Backend;

namespace Webform.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            setViewBagDiaDiem();
            setViewBagGioiTinh();
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(ThiSinhBUS model)
        {
            try
            {
                model.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TimKiemThongTin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimKiemThongTin(ThiSinhBUS model)
        {
            return RedirectToAction("ThongTinTimKiem", new { hoten = model.HoTen, sdt = model.SDT });
        }

        public ActionResult ThongTinTimKiem(string hoten, string sdt)
        {
            var con = new ThiSinhBUS();      
            var edit = ThiSinhBUS.findBy_HoTen_SDT(con.getAll(), hoten, sdt);

            //return RedirectToAction("Index", new { id = edit.GioiTinh });
            return View(edit);
        }




        public void setViewBagDiaDiem(long? selected = null)
        {
            var dao = new DiaDiemBUS();
            ViewBag.NoiSinh = new SelectList(dao.getAll(), "MaDiaDiem", "TenDiaDiem", selected);
        }

        public void setViewBagGioiTinh(long? selected = null)
        {
            var dao = new GioiTinhBUS();
            ViewBag.GioiTinh = new SelectList(dao.getAll(), "GioiTinh", "GioiTinh", selected);
        }

    }
}