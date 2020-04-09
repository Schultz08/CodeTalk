using Models.Search;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTalk.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchFilter model)
        {
            TempData["SearchModel"] = model;

            return RedirectToAction("SearchResults");
        }

        public ActionResult SearchResults()
        {
            var model = TempData["SearchModel"] as SearchFilter;
            if (model == null)
                return RedirectToAction("Index");
            var service = new SearchService();

           var result = service.AdvanceSearch(model);

            if (result == null)
                return View(model);
            //  ViewData["Result"] = result;
           // ViewBag.Results = result;
            return View(result);
        }

      /*  public ActionResult SearchTest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchTest(SearchString str)
        {
           TempData["SearchModel"] = str;
            
            return RedirectToAction("RunSearchTest");
        }

        public ActionResult RunSearchTest()
        {
            var model = TempData["SearchModel"] as SearchString;
            var service = new SearchService();
            var result = service.GetSearch(model);
            return View(result);
        }*/
    }
}