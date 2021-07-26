using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlifSozluk.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        Context c = new Context();
        // GET: Statistics
        public ActionResult Index()
        {
            var deger1 = c.Categories.Count();
            var deger2 = c.Headings.Where(x => x.Category.CategoryName == "yazılım").Count();
            var deger3 = c.Writers.Where(x => x.WriterName.Contains("a")).Count();

            var deger4 = c.Headings.OrderByDescending(x => x.HeadingID).Select(y => y.Category.CategoryName).FirstOrDefault();
            var deger5 = c.Categories.Where(x => x.CategoryStatus == false || x.CategoryStatus==true).Select(y=>y.CategoryID).Sum();
            var deger6 = c.Categories.Where(x => x.CategoryStatus == false ).Count();
            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            return View();
        }
    }
}