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
            setViewBagKhoaThi();
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


        //======================================================================================================

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

            return View(edit);
        }


        //======================================================================================================
        public ActionResult GiayChungNhan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiayChungNhan(ThiSinhBUS model)
        {
            return RedirectToAction("ThongTinGiayChungNhan", new { sbd = model.SoBaoDanh });
        }

        public ActionResult ThongTinGiayChungNhan(string sbd)
        {
            var con = new ThiSinhBUS();
            var edit = ThiSinhBUS.findBy_SBD(con.getAll(), sbd);

            return View(edit);
        }


        //======================================================================================================
        public ActionResult DanhSachThiSinh()
        {
            setViewBagKhoaThi();
            setViewBagPhongThi();

            return View();
        }

        [HttpPost]
        public ActionResult DanhSachThiSinh(ThiSinhBUS model)
        {
            return RedirectToAction("DanhSachThiSinh_KetQua", new { khoathi = model.MaKhoaThi, phongthi = model.TenPhongThi });
        }

        public ActionResult DanhSachThiSinh_KetQua(string khoathi, string phongthi)
        {
            var con = new ThiSinhBUS().getAll();
            var edit = ThiSinhBUS.findBy_MaKhoaThi_TenPhongThi(con, khoathi, phongthi);

            return View(edit);
        }

        //======================================================================================================












        //======================================================================================================
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

        public void setViewBagKhoaThi(long? selected = null)
        {
            var dao = new KhoaThiBUS();
            ViewBag.MaKhoaThi = new SelectList(dao.getAll(), "MaKhoaThi", "TenKhoaThi", selected);
        }

        public void setViewBagPhongThi(long? selected = null)
        {
            var dao = new PhongThiBUS();
            ViewBag.TenPhongThi = new SelectList(dao.getAll(), "TenPhongThi", "TenPhongThi", selected);
        }
        //======================================================================================================
    }
}