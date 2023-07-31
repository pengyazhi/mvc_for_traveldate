using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTravelDateT1.Models
{
    public class CCategoryAndTags
    {
        public string category { get; set; }
        public IEnumerable<string> tags { get; set; }
    }
}