using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace prjTravelDateT1.Models
{
    public class CFilteredProductItem: ProductList
    {
        #region 會用到的ProductList的屬性
        //public ProductList productID { get; set; } 
        //public ProductList ProductName { get; set; }
        //public ProductList CityID { get; set; }
        //public ProductList ProductTypeID { get; set; }
        //public ProductList ExamineStatus { get; set; }
        //public ProductList Discontinued { get; set; }
        //public ProductList OutlineForSearch { get; set; }
        #endregion
        public int price { get; set; }
        public byte[] photo { get; set; }
        public string date { get; set; }
        public  List<string> productTags { get; set; } =new List<string>();
        public  List<string> productCitys { get; set; } = new List<string>();  
        public string city { get; set; }
        public string type { get; set; }
        public double? commentAvgScore { get; set; }
        public int commentCount { get; set; }
        public string strComment { get; set; }
        public int? orederCount { get; set; }

    }
    
}