using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.core.Models;
namespace MyShop.core.ViewModels
{
    public class ProductCategoryViewModel
    {
        public Product product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
