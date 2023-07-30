using prjTravelDateT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjTravelDateT1.ViewModels
{
    public class CSearchListViewModel
    {
        public List<CFilteredProduct> fFilterProducts { get; set; } = new List<CFilteredProduct>();
        public List<CCategoryAndTags> fCategoryAndTags { get; set; } = new List<CCategoryAndTags>();
        public List<CCountryAndCity> fCountryAndCities { get; set; } = new List<CCountryAndCity>();
        //public List<string> fTags { get; set; } = new List<string>();
        public List<string> fTypes { get; set; } = new List<string>();
    }
}
