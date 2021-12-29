using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BUS;

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
            return View();
        }









        public void setViewBagDiaDiem(long? selected = null)
        {
            var dao = new DiaDiem();
            ViewBag.NoiSinh = new SelectList(dao.getAll(), "NoiSinh", "TenDiaDiem", selected);
        }
    }
}