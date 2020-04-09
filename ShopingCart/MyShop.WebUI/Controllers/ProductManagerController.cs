using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.core.Models;
using MyShop.core.ViewModels;
using MyShop.DataAccess;
using MyShop.DataAccess.InMemory;
namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {

        ProductRepo context;
        ProductCategoryRepo categories;
        public ProductManagerController()
        {
            context = new ProductRepo();
            categories = new ProductCategoryRepo();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel();
            viewModel.product = new Product();
            viewModel.ProductCategories = categories.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(ProductCategoryViewModel c)
        {
            Debug.WriteLine(c.product.Name);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            else
            {    
                context.Insert(c.product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(String Id)
        {
            Product ProductToEdit = context.Find(Id);
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel();
            viewModel.product = ProductToEdit;
            viewModel.ProductCategories = categories.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategoryViewModel p)
        {
            Product ProductToEdit = context.Find(p.product.Id);
            if(ProductToEdit == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Edit");
                }
                else
                {
                    ProductToEdit.Name = p.product.Name;
                    ProductToEdit.Price = p.product.Price;
                    ProductToEdit.Catagory = p.product.Catagory;
                    ProductToEdit.Rating = p.product.Rating;
                    ProductToEdit.Description = p.product.Description;
                    ProductToEdit.Image = p.product.Image;
                    context.Commit();
                    return RedirectToAction("Index");
                }
                
            }
        }
        public ActionResult Delete(String Id)
        {
            context.Delete(Id);
            return RedirectToAction("Index");
        }


    }
}