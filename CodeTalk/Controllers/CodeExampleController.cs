﻿using Data;
using Microsoft.AspNet.Identity;
using Models.CodeExampleModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTalk.Controllers
{
    public class CodeExampleController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: CodeExample
        public ActionResult Index()
        {
            var service = GetCodeExampleService();
            var model = service.GetAllExamples();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExampleCreate model)
        {
          /*  if(!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }*/

            var service = GetCodeExampleService();

            if(service.CreateExample(model))
            {
                TempData["SaveResult"] = "Your Example was created";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            var service = GetCodeExampleService();
            var detail = service.GetById(id);
            if(detail == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            var model = new ExampleUpdate
            {
                CodeExampleId = detail.CodeExampleId,
                CategoryId = detail.CategoryId,
                ProfileId = detail.ProfileId,
                UserName = detail.UserName,
                ExampleCode = detail.ExampleCode,
                ExampleDiscription = detail.ExampleDiscription,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExampleUpdate model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something is wrong with the Data!");
                return View(model);
            }

            var service = GetCodeExampleService();
            
            if(service.UpdateExample(model))
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Something went wrong internally. Please Report the problem");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = GetCodeExampleService();
            var detail = service.GetById(id);
            if(detail == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(detail);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteExample(int id)
        {
            var service = GetCodeExampleService();
           
            if(service.DeleteExample(id))
                return RedirectToAction(nameof(Index));

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }

        private CodeExampleServices GetCodeExampleService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CodeExampleServices(userId);
            return service;
        }
    }
}
