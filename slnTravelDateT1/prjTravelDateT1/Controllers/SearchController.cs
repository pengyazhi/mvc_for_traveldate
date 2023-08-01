using prjTravelDateT1.Models;
using prjTravelDateT1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace prjTravelDateT1.Controllers
{
    public class SearchController : Controller
    {
        
        // GET: Search
        public ActionResult SearchList()
        {
            CFilteredProductFactory products = new CFilteredProductFactory();
            CSearchListViewModel vm = new CSearchListViewModel();
            vm.filterProducts = products.qureyFilterProductsInfo();//商品cards
            vm.categoryAndTags = products.qureyFilterCategories();//商品類別&標籤,左邊篩選列
            vm.countryAndCities = products.qureyFilterCountry();  //商品國家&縣市,左邊篩選列
            vm.types = products.qureyFilterTypes();//商品類型,左邊篩選列

            return View(vm);
        }
        
    }
}