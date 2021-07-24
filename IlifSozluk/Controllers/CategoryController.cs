using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlifSozluk.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        // GET: Category
        //Ornek
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetAllBL();
            return View(categoryValues);
        }
    }
}