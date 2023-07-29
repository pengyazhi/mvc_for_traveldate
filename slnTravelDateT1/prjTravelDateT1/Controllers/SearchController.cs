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
            CFilteredProductFactory products = new CFilteredProductFactory();
            List<CFilteredProduct> datas = products.qureyFilterProductsInfo();
            //List<CCategory> datas1 = products.qureyFilterProductsCategory();
            return View(datas);
        }
        public ActionResult Test() {
            CFilteredProductFactory products = new CFilteredProductFactory();
            List<CFilteredProduct> datas = products.qureyFilterProductsInfo();
            return View(datas);
        }
    }
}