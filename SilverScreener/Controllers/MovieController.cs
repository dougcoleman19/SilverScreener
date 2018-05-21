using SilverScreener.Dto;
using SilverScreener.Models;
using SilverScreener.ViewModels;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Web.Services.Protocols;
using SilverScreener.Helper;

namespace SilverScreener.Controllers
{
    public class MovieController : Controller
    {
        private MovieManager MovieManager;
        private TheaterManager TheaterManager;

        public MovieController()
        {
            if (MovieManager == null) MovieManager = new MovieManager();
            if (TheaterManager == null) TheaterManager = new TheaterManager();
        }

        // GET: Movies
        [HttpGet]
        public ActionResult Index()
        {
           var models = MovieManager.GetAll();

           ViewBag.AvailableGenres = GenreManager.GetAll();
           return View(models);
        }

        [HttpPost]
        public ActionResult SearchByGenre(string genreSearch)
        {
            var models = MovieManager.GetByGenre(genreSearch);

            return PartialView("../Partials/_MovieSearchResults", models);
        }

        // GET: Movies/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = MovieManager.GetById(id);
           
            var ratingName = RatingManager.GetById(model.RatingId);

            model.RatingName = ratingName.RatingName;

            var movieGenres = GenreManager.GetForMovie(id);
            var checkBoxListItems = new List<CheckBoxListItem>();

            foreach (var genre in movieGenres)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = genre.GenreId,
                    Display = genre.GenreName,
                    IsChecked = movieGenres.Any(x => x.GenreId == genre.GenreId)
                });
            }

            model.Genres = checkBoxListItems;

            return View(model);

        }

        // GET: Movies/Create
        [HttpGet]
        public ActionResult Create(int? theaterId)
        {
            var model = new MovieViewModel();

            if (theaterId.HasValue)
            {
                model.Theater = TheaterManager.GetByTheaterId(theaterId.Value);
            }

            var allRatings = RatingManager.GetAll();
            var allGenres = GenreManager.GetAll();

            var checkBoxListItems = new List<CheckBoxListItem>();

            model.Ratings = allRatings;

            foreach (var genre in allGenres)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = genre.GenreId,
                    Display = genre.GenreName,
                    IsChecked = false // On the add view, no genres will be selected by default
                });
            }

            model.Genres = checkBoxListItems;

            ViewBag.AvailableTheaters = TheaterManager.GetAll();

            return View(model);
        }

        // Add Movies to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel model)
        {
            if (model.File != null)
            {
                var fileInfo = new FileInfo(model.File.FileName);

                model.Poster = fileInfo.Name;

                var fullFileName = System.Web.HttpContext.Current.Server.MapPath("~/assets/images/movie-posters/") + fileInfo.Name;

                if (!System.IO.File.Exists(fullFileName))
                {
                    model.File.SaveAs(fullFileName);
                }
            }

            MovieManager.Add(model);

            return RedirectToAction("Index");
        }

        // GET: 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = MovieManager.GetById(id);
           
            var allRatings = RatingManager.GetAll();

            var movieGenres = GenreManager.GetForMovie(id);
            var allGenres = GenreManager.GetAll();
            var checkBoxListItems = new List<CheckBoxListItem>();

            foreach (var genre in allGenres)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = genre.GenreId,
                    Display = genre.GenreName,
                    IsChecked = movieGenres.Any(x => x.GenreId == genre.GenreId)
                });
            }

            model.Ratings = allRatings;

            model.Genres = checkBoxListItems;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieViewModel model)
        {
            if (model.File != null)
            {
                var fileInfo = new FileInfo(model.File.FileName);

                model.Poster = fileInfo.Name;

                var fullFileName = System.Web.HttpContext.Current.Server.MapPath("~/assets/images/movie-posters/") + fileInfo.Name;

                if (!System.IO.File.Exists(fullFileName))
                {
                    model.File.SaveAs(fullFileName);
                }
            }

            MovieManager.Edit(model);

            return RedirectToAction("Index");
        }

    }
}