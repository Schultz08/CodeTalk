using Data;
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
            var profile = service.GetById(userId);

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

        public ActionResult Edit(string id)
        {

            var service = GetProfileService();
            if (!service.GetByIdTest(id))
            {
                return RedirectToAction(nameof(Index));
            }
            var detail = service.GetById(id);
            var profile = new ProfileUpdate
            {
                ProfileId = detail.ProfileId,
                UserName = detail.UserName,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Email = detail.Email
            };
            return View(profile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileUpdate model)
        {
            if (!ModelState.IsValid)
                return View();

            var service = GetProfileService();

            if (!service.ProfileEdit(model))
            {
                ModelState.AddModelError("", "Internal server error");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
        private ProfileServices GetProfileService()
        {
            var userId = User.Identity.GetUserId();
            var service = new ProfileServices(userId);
            return service;
        }
    }
}