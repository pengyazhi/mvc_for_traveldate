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
        public List<ProductCategory> fCategories { get; set; } = new List<ProductCategory>();
        public List<ProductTagDetails> fTagDetails { get; set; } = new List<ProductTagDetails>();
    }
}
