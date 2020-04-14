using Models.CategoryModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTalk.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var service = new CategoryServices();
            return View(service.GetCategories());

        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if(ModelState.IsValid)
            {
                var service = new CategoryServices();
                if (service.CreateCategory(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var service = new CategoryServices();

            if(service.GetById((int)id) == null)
            {
                return View();
            }
            var model = service.GetById((int)id);
        
            return View(model);
        }

        public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var service = new CategoryServices();

            if(service.GetById((int)id) == null)
            {
                return View();
            }
            var detail = service.GetById((int)id);
            var model = new CategoryUpdate
            {
                CategoryId = detail.CategoryId,
                CategoryName = detail.CategoryName,
                CategoryDiscription = detail.CategoryDiscription
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);
                
            var service = new CategoryServices();

            if(!service.UpdateCategory(model))
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var service = new CategoryServices();
            if (!service.GetByIdTest(id))
            {
                TempData["SaveResult"] = "The item you were looking for was not found";
                return RedirectToAction(nameof(Index));
            }
            var detail = service.GetById(id);
            var model = new CategoryDelete
            {
                CategoryId = detail.CategoryId,
                CategoryName = detail.CategoryName,
                CategoryDiscription = detail.CategoryDiscription
            };
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            var service = new CategoryServices();
            service.DeleteCategory(id);
            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult GetSearch(string stringSearch)
        {
            if (string.IsNullOrEmpty(stringSearch) || string.IsNullOrWhiteSpace(stringSearch))
                return View();

            TempData["SearchString"] = stringSearch;

            return RedirectToAction("DefualtSearch", "Search", stringSearch);
        }
    }
}