using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SilverScreener.Models;
using System.Data.Entity;
using Microsoft.Owin.Security.Provider;
using SilverScreener.ViewModels;

namespace SilverScreener.Dto
{
    public class MovieManager
    {
        public static List<MovieViewModel> GetAll()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var movies = _context.Movies.Include(x => x.Rating)
                    .Include(x => x.Genres)
                    .Include(x => x.Theater)
                    .Include(x => x.Showtimes)
                    .OrderBy(x => x.MovieName)
                    .Select(x => new MovieViewModel()
                    {
                        MovieId = x.MovieId,
                        Title = x.MovieName,
                        RunTime = x.RunTime,
                        RatingId = x.RatingId,
                        Poster = x.PosterImage,
                        ShowTimes = x.Showtimes.Select(y => new ShowTimeViewModel()
                        {
                            ShowTimeId = y.ShowTimeId,
                            Showing = y.Showing
                        }).ToList(),
                        Genres = x.Genres.Select(y => new CheckBoxListItem()
                        {
                            Display = y.GenreName
                        }).ToList()
                    })
                    .ToList();

                return movies;
            }
        }

        public static MovieViewModel GetById(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var movie = _context.Movies.Include(x => x.Rating)
                    .Include(x => x.Genres)
                    .Include(x => x.Theater)
                    .Include(x => x.Showtimes)
                    .OrderBy(x => x.MovieName)
                    .Select(x => new MovieViewModel()
                    {
                        MovieId = x.MovieId,
                        Title = x.MovieName,
                        RunTime = x.RunTime,
                        RatingId = x.RatingId,
                        Poster = x.PosterImage,
                        ShowTimes = x.Showtimes.Select(y => new ShowTimeViewModel()
                        {
                            ShowTimeId = y.ShowTimeId,
                            Showing = y.Showing
                        }).ToList(),
                        Genres = x.Genres.Select(y => new CheckBoxListItem()
                        {
                            Display = y.GenreName
                        }).ToList()
                    })
                    .FirstOrDefault(x => x.MovieId == id);

                return movie;
            }
        }

        public static List<MovieViewModel> GetByGenre(string genreSearch)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var movies = _context.Movies.Include(x => x.Rating)
                    .Include(x => x.Genres)
                    .Include(x => x.Theater)
                    .Include(x => x.Showtimes)
                    .Where(x => x.Genres.Any(y => y.GenreName.Contains(genreSearch)))
                    .OrderBy(x => x.MovieName)
                    .Select(x => new MovieViewModel()
                    {
                        MovieId = x.MovieId,
                        Title = x.MovieName,
                        RunTime = x.RunTime,
                        RatingId = x.RatingId,
                        Poster = x.PosterImage,
                        ShowTimes = x.Showtimes.Select(y => new ShowTimeViewModel()
                        {
                            ShowTimeId = y.ShowTimeId,
                            Showing = y.Showing
                        }).ToList(),
                        Genres = x.Genres.Select(y => new CheckBoxListItem()
                        {
                            Display = y.GenreName
                        }).ToList()
                    })
                    .ToList();

                return movies;
            }
        }

        public static void Add(MovieViewModel model)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var movie = new Movie()
                {
                    MovieName = model.Title,
                    RatingId = model.RatingId,
                    RunTime = model.RunTime,
                    PosterImage = model.Poster,
                    TheaterId = model.TheaterId.Value
                    
                };

                foreach (var genreId in model.Genres.Where(x => x.IsChecked).Select(x => x.ID).ToList())
                {
                    var genre = _context.Genres.Find(genreId);
                    movie.Genres.Add(genre);
                }

                _context.Movies.Add(movie);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static void Edit(MovieViewModel model)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var movie = _context.Movies.Find(model.MovieId);

                if (movie != null)
                {
                    movie.MovieName = model.Title;
                    movie.RatingId = model.RatingId;
                    movie.RunTime = model.RunTime;
                    movie.PosterImage = model.Poster;

                    movie.Genres.Clear();

                    foreach (var genreId in model.Genres.Where(x => x.IsChecked).Select(x => x.ID).ToList())
                    {
                        var genre = _context.Genres.Find(genreId);
                        movie.Genres.Add(genre);
                    }

                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    
                }
                else
                {
                    throw new Exception("No Movies Found");
                }
                
            }
        }
    }

   
}