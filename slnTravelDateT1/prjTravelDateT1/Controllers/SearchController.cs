using prjTravelDateT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjTravelDateT1.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult SearchList()
        {
            CFilterProductFactory products = new CFilterProductFactory();
            List<CFilterProduct> datas = products.qureyFilterProductsInfo();
            return View(datas);
        }
        public ActionResult Test() {
            CFilterProductFactory products = new CFilterProductFactory();
            List<CFilterProduct> datas = products.qureyFilterProductsInfo();
            return View(datas);
        }
    }
}