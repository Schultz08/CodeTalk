using Microsoft.AspNet.Identity;
using Models.ProfileModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace Brain_code.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = GetProfileService();
            var profile = service.GetByID(userId);
            if (profile.FirstName == null)
                return RedirectToAction(nameof(Create));

            return View(service.GetByID(userId));
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