using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using MyShop.core.Models;
using MyShop.DataAccess;
using MyShop.DataAccess.InMemory;


namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProductCatagoryManager
        ProductCategoryRepo context;

        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepo();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> categories = context.Collection().ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategory c)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            else
            {
                Debug.WriteLine(c.Category);
                context.Insert(c);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(String Id)
        {
            ProductCategory ProductCategoryToEdit = context.Find(Id);
            return View(ProductCategoryToEdit);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory p)
        {
            ProductCategory ProductCategoryToEdit = context.Find(p.Id);
            if (ProductCategoryToEdit == null)
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
                    ProductCategoryToEdit.Category = p.Category;
                    ProductCategoryToEdit.Description = p.Description;
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