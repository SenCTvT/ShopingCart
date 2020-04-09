using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyShop.core.Models
{
    public  class ProductCategory
    {
        [Required]
        public String Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }
        public string Description { get; set; }
         

        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
