using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.core.Models
{
    public class Product
    {
        public string Id { get; set; }
        
        [Required]
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [StringLength(140)]
        public string Description { get; set; }

        [Range(0, 20000)]
        public int Price { get; set; }
        public string Catagory { get; set; }

        public string Image { get; set; }
        [Range(0,5)]
        public int Rating { get; set; }



        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
