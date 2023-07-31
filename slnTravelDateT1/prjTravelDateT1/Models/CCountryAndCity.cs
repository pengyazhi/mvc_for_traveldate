using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTravelDateT1.Models
{
    public class CCountryAndCity
    {
        public string country { get; set; }
        public IEnumerable<string> citys { get; set; }
    }
}