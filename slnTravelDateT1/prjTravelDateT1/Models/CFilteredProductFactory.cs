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
                .Where(n => n.ProductList.ExamineStatus == true
                && n.ProductList.Discontinued == false
                && n.ProductID == n.ProductList.ProductID)
                .Select(n => (int)n.ProductID).ToList();
        }
        #endregion
        public List<CFilteredProduct> qureyFilterProductsInfo()
        {
            List<CFilteredProduct> list = new List<CFilteredProduct>();
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
                CFilteredProduct x = new CFilteredProduct();
                x.ProductID = t.商品ID;
                x.ProductName = t.名稱.FirstOrDefault();
                x.OutlineForSearch = t.商品敘述.FirstOrDefault();
                if(t.城市.FirstOrDefault().Trim().Substring(t.城市.FirstOrDefault().Length-1,1) == "縣" 
                    || t.城市.FirstOrDefault().Trim().Substring(t.城市.FirstOrDefault().Length - 1, 1) == "市")
                {
                    x.fCity = t.城市.FirstOrDefault().Substring(0, t.城市.FirstOrDefault().Length-1);
                }
                
                x.fDate = t.日期.Value.ToString("yyyy/MM/dd");
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
                //評分總分/次數
                var datas_commentList = db.CommentList.Where(c => c.ProductID == t.商品ID).Select(c => c.CommentScore);
                x.fCommentAvgScore = datas_commentList.Average();
                x.fCommentCount = datas_commentList.Count();
                x.strComment = datas_commentList.Any()?$"{datas_commentList.Average():0.0} ({datas_commentList.Count()})":"No comment";
                //購買次數
                var datas_orderDetais_Count = db.OrderDetails.Where(o => o.Trip.ProductList.ProductID == t.商品ID).Select(o => o.Quantity).Sum();
                x.fOrederCount = datas_orderDetais_Count.HasValue ? datas_orderDetais_Count : 0;
                //x.fOrederCount = 29999; //要做10 K+以上
                list.Add(x);
            }
            return list;
        }
    }
}