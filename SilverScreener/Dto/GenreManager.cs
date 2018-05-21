using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SilverScreener.Models;

namespace SilverScreener.Dto
{
    public class GenreManager
    {
        public static List<Genre> GetAll()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                return _context.Genres.OrderBy(model => model.GenreName).ToList();
            }
        }

        public static Genre GetById(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                return _context.Genres.First(model => model.GenreId == id);
            }
        }

        public static List<Genre> GetForMovie(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                return _context.Movies.First(model => model.MovieId == id).Genres.ToList();
            }
        }
    }
}