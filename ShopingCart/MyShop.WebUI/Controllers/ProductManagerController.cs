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
        public ActionResult Create(Product p)
        {
            
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            else
            {
                context.Insert(p);
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
        public ActionResult Edit(Product p)
        {
            Product ProductToEdit = context.Find(p.Id);
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
                    ProductToEdit.Name = p.Name;
                    ProductToEdit.Price = p.Price;
                    ProductToEdit.Catagory = p.Catagory;
                    ProductToEdit.Rating = p.Rating;
                    ProductToEdit.Description = p.Description;
                    ProductToEdit.Image = p.Image;
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