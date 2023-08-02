using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace prjTravelDateT1.Models
{
    public class CFilteredProductFactory
    {
        TraveldateEntities db = new TraveldateEntities();
        #region qureyConfirmedID
        public List<int> qureyConfirmedID()
        {
            return db.Trip.AsEnumerable()
                .Where(n => n.ProductList.ProductTypeID == 1
                && n.ProductList.Discontinued == false
                && n.ProductID == n.ProductList.ProductID)
                .Select(n => (int)n.ProductID).ToList();
        }
        #endregion
        public List<CFilteredProductItem> qureyFilterProductsInfo()
        {
            List<CFilteredProductItem> list = new List<CFilteredProductItem>();
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
                CFilteredProductItem x = new CFilteredProductItem();
                x.ProductID =t.商品ID;
                x.ProductName = t.名稱.FirstOrDefault();
                x.OutlineForSearch = t.商品敘述.FirstOrDefault();
                if (t.城市.FirstOrDefault().Trim().Substring(t.城市.FirstOrDefault().Length - 1, 1) == "縣"
                    || t.城市.FirstOrDefault().Trim().Substring(t.城市.FirstOrDefault().Length - 1, 1) == "市")
                {
                    x.city = t.城市.FirstOrDefault().Substring(0, t.城市.FirstOrDefault().Length - 1);
                }

                x.date = t.日期.Value.ToString("yyyy/MM/dd");
                x.price = (int)t.價格;
                x.type = t.類型.FirstOrDefault();
                //標籤
                var datas_productTagsList = db.ProductTagList.AsEnumerable()
                    .Where(n => n.ProductID == t.商品ID /*&& n.ProductTagDetailsID == n.ProductTagDetails.ProductTagDetailsID*/)
                    .Select(n => n.ProductTagDetails.ProductTagDetailsName);

                foreach (var tag in datas_productTagsList)
                {
                    if (!x.productTags.Contains(tag))
                        x.productTags.Add(tag);
                }
                //照片
                var datas_productPhotoList = db.ProductPhotoList.Where(p => t.商品ID == p.ProductID).Select(p => p.Photo);
                x.photo = datas_productPhotoList.FirstOrDefault();
                //評分總分/次數
                var datas_commentList = db.CommentList.Where(c => c.ProductID == t.商品ID).Select(c => c.CommentScore);
                x.commentAvgScore = datas_commentList.Average();
                x.commentCount = datas_commentList.Count();
                x.strComment = datas_commentList.Any() ? $"{datas_commentList.Average():0.0} ({datas_commentList.Count()})" : "No comment";
                //購買次數
                var datas_orderDetais_Count = db.OrderDetails.Where(o => o.Trip.ProductList.ProductID == t.商品ID).Select(o => o.Quantity).Sum();
                x.orederCount = datas_orderDetais_Count.HasValue ? datas_orderDetais_Count : 0;
                //x.fOrederCount = 29999; //要做10 K+以上
                list.Add(x);
            }
            return list;
        }
        public List<CCategoryAndTags> qureyFilterCategories()
        {
            List<CCategoryAndTags> list = new List<CCategoryAndTags>();
            var data_category = db.ProductTagList.AsEnumerable()
                .Where(c => qureyConfirmedID().Contains((int)c.ProductID))
                .GroupBy(c => c.ProductTagDetails.ProductCategory.ProductCategoryName)
                .Select(g =>
                new
                {
                    分類名稱 = g.Key,
                    分類下的標籤 = g.Select(t=>t.ProductTagDetails.ProductTagDetailsName)
                }) ;
            foreach(var i in data_category)
            {
                CCategoryAndTags x = new CCategoryAndTags();
                x.category = i.分類名稱;
                x.tags = i.分類下的標籤;
                list.Add(x);
            }
            return list;
        }
        public List<CCountryAndCity> qureyFilterCountry()
        {
            List<CCountryAndCity> list = new List<CCountryAndCity>();
            var data_region = db.ProductList.AsEnumerable()
                .Where(c => qureyConfirmedID().Contains((int)c.ProductID))
                .GroupBy(r => r.CityList.CountryList.Country)
                .Select(g => new
                {
                    國家 = g.Key,
                    縣市 = g.Select(c=>c.CityList.City)
                });
            foreach(var c in data_region)
            {
                CCountryAndCity x = new CCountryAndCity();
                x.country = c.國家;
                x.citys = c.縣市;
                list.Add(x);
            }
            return list;
        }
            public List<string> qureyFilterTypes()
        {
            List<string> list = new List<string>();
            IEnumerable<string> datas_types = db.ProductList.AsEnumerable()
                .Where(t => qureyConfirmedID().Contains((int)t.ProductID))
                .Select(t => t.ProductTypeList.ProductType);
            list.AddRange(datas_types);
            return list;
        }
    }
}