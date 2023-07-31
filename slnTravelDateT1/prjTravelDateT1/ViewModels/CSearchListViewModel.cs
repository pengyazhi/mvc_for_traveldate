﻿using prjTravelDateT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjTravelDateT1.ViewModels
{
    public class CSearchListViewModel
    {
        public List<CFilteredProductItem> filterProducts { get; set; } = new List<CFilteredProductItem>();
        public List<CCategoryAndTags> categoryAndTags { get; set; } = new List<CCategoryAndTags>();
        public List<CCountryAndCity> countryAndCities { get; set; } = new List<CCountryAndCity>();
        //public List<string> fTags { get; set; } = new List<string>();
        public List<string> types { get; set; } = new List<string>();
    }
}
