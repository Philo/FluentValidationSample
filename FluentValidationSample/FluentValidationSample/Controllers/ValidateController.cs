using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidationSample.Models;

namespace FluentValidationSample.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegistrationModel model)
        {
            if (!ModelState.IsValid) return View();

            return RedirectToAction("Index", "Home");
        }
    }
}