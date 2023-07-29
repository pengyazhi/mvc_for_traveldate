using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace prjTravelDateT1.Models
{
    public class CFilteredProduct:ProductList
    {
        #region 會用到的ProductList的屬性
        //public int ProductID { get; set; } 
        //public string ProductName { get; set; } 
        //public Nullable<int> CityID { get; set; }
        //public Nullable<int> ProductTypeID { get; set; }
        //public Nullable<bool> ExamineStatus { get; set; }
        //public Nullable<bool> Discontinued { get; set; }
        //public string OutlineForSearch { get; set; }
        #endregion
        public int fPrice { get; set; }
        public byte[] fPhoto { get; set; }
        public string fDate { get; set; }
        public  List<string> fProductTags { get; set; } =new List<string>();
        public  List<string> fProductCitys { get; set; } = new List<string>();  
        public string fCity { get; set; }
        public string fType { get; set; }
        public double? fCommentAvgScore { get; set; }
        public int fCommentCount { get; set; }
        public string strComment { get; set; }
        public int? fOrederCount { get; set; }

    }
    
}