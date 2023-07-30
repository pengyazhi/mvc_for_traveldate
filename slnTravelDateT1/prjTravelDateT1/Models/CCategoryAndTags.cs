using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTravelDateT1.Models
{
    public class CCategoryAndTags
    {
        public string fCategory { get; set; }
        public IEnumerable<string> fTags { get; set; }
    }
}