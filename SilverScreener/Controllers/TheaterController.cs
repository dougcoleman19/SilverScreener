using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SilverScreener.Dto;
using SilverScreener.Models;
using SilverScreener.ViewModels;

namespace SilverScreener.Controllers
{
    public class TheaterController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Movies
        [HttpGet]
        public ActionResult Index()
        {
            var model = TheaterManager.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int? theaterId)
        {
            if (!theaterId.HasValue)
            {
                return HttpNotFound();
            }
            
            var model = TheaterManager.GetByTheaterId(theaterId.Value);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TheaterViewModel model)
        {
            TheaterManager.Add(model);

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Search(string theaterSearch)
        //{
        //    var results = TheaterManager.Get(theaterSearch);

        //     return PartialView("Partials/_SearchResults", results);
        // }
    }
}