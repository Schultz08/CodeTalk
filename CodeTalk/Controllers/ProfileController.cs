using Microsoft.AspNet.Identity;
using Models.ProfileModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTalk.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = GetProfileService();
            var profile = service.GetByID(userId);

            return View(profile);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = GetProfileService();

            if (service.CreateProfile(model))
                return RedirectToAction(nameof(Index));

            return View(model);
        }
        private ProfileServices GetProfileService()
        {
            var userId = User.Identity.GetUserId();
            var service = new ProfileServices(userId);
            return service;
        }
    }
}