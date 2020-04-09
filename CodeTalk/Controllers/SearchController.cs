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
        [HttpGet]
        public ActionResult SearchResults()
        {
            var model = TempData["SearchModel"] as SearchFilter;
            if (model == null)
                return RedirectToAction("Index");
            var service = new SearchService();

           var result = service.AdvanceSearch(model);

            if (result == null)
                return View(model);

            return View(result);
        }

        
        [HttpGet]
        public ActionResult DefualtIndex(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString) || string.IsNullOrEmpty(searchString))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
                return View();
            }

            TempData["SearchString"] = searchString;

            return RedirectToAction("DefualtSearch");
        }
        public ActionResult DefualtSearch(string searchString)
        {
            //var searchString = TempData["SearchString"] as string;

            var model = new SearchFilter
            {
                SearchCategory = true,
                SearchCodeExample = true,
                SearchProfile = true,
                SearchRequest = searchString
            };
            
            var service = new SearchService();

            var result = service.AdvanceSearch(model);

            if(result == null)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
                return View();
            }

            return View("SearchResults", result);
        }
    }
}