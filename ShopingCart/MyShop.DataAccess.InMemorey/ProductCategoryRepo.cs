using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.core.Models;


namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepo
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories;

        public ProductCategoryRepo()
        {
            categories = cache["categories"] as List<ProductCategory>;
            if (categories == null)
            {
                categories = new List<ProductCategory>(); 
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory p)
        {
            categories.Add(p);
        }

        public void Update(ProductCategory category)
        {
            ProductCategory productCategoryToUpdate = categories.Find(p => p.Id == category.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = category;
            }
            else
            {
                throw new Exception("Category no found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory category = categories.Find(c => c.Id == Id);

            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("category no found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = categories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                categories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("category no found");
            }
        }
    }
}