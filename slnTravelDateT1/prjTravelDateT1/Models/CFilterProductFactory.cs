using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace prjTravelDateT1.Models
{
    public class CFilterProductFactory
    {
        TraveldateEntities db = new TraveldateEntities();
        #region qureyConfirmedID
        public List<int> qureyConfirmedID()
        {
            return db.Trip.AsEnumerable()
                .Where(n => n.ProductList.ExamineStatus == true
                && n.ProductList.Discontinued == false
                && n.ProductID == n.ProductList.ProductID)
                .Select(n => (int)n.ProductID).ToList();
        }
        #endregion
        public List<CFilterProduct> qureyFilterProductsInfo()
        {
            List<CFilterProduct> list = new List<CFilterProduct>();
            var datas_trip_productList = db.Trip.AsEnumerable()
                .Where(t => qureyConfirmedID().Contains(t.ProductID))
                .GroupBy(t => t.ProductID)
                .Select(g =>
                new
                {
                    商品ID = g.Key,
                    名稱 = g.Select(n => n.ProductList.ProductName),
                    商品敘述 = g.Select(n => n.ProductList.OutlineForSearch),
                    城市 = g.Select(n => n.ProductList.CityList.City).Distinct(),
                    日期 = g.Select(n => n.Date).Max(),
                    價格 = g.Select(n => n.UnitPrice).Min(),
                    類型 = g.Select(n => n.ProductList.ProductTypeList.ProductType).Distinct()
                }
                 ).ToList();
            foreach (var t in datas_trip_productList)
            {
                CFilterProduct x = new CFilterProduct();
                x.ProductID = t.商品ID;
                x.ProductName = t.名稱.FirstOrDefault();
                x.OutlineForSearch = t.商品敘述.FirstOrDefault();
                x.fCity = t.城市.FirstOrDefault();
                x.fDate = t.日期;
                x.fPrice = (int)t.價格;
                x.fType = t.類型.FirstOrDefault();
                //標籤
                var datas_productTagsList = db.ProductTagList.AsEnumerable()
                    .Where(n => n.ProductID == t.商品ID /*&& n.ProductTagDetailsID == n.ProductTagDetails.ProductTagDetailsID*/)
                    .Select(n => n.ProductTagDetails.ProductTagDetailsName);
                foreach(var tag in datas_productTagsList)
                {
                    if(!x.fProductTags.Contains(tag))
                        x.fProductTags.Add(tag);
                }
                //照片
                var datas_productPhotoList = db.ProductPhotoList.Where(p => t.商品ID == p.ProductID).Select(p => p.Photo);
                x.fPhoto = datas_productPhotoList.FirstOrDefault();

                list.Add(x);
            }
            return list;
        }
    }
}