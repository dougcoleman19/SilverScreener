using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SilverScreener.Models;

namespace SilverScreener.Dto
{
    public class RatingManager
    {
        public static List<Rating> GetAll()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                return _context.Ratings.OrderBy(model => model.RatingName).ToList();
            }
        }

        public static Rating GetById(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                return _context.Ratings.First(model => model.RatingId == id);
            }
        }
    }
}