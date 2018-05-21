using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SilverScreener.Models;
using SilverScreener.ViewModels;

namespace SilverScreener.Dto
{
    public class TheaterManager
    {
        public static List<TheaterViewModel> GetAll()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var theaters = _context.Theaters
                    .OrderBy(x => x.TheaterName)
                    .Select(x => new TheaterViewModel()
                    {
                        TheaterId = x.TheaterId,
                        Name = x.TheaterName,
                        Location = x.ZipCode
                    }).ToList();

                return theaters;
            }
        }

        public static TheaterViewModel GetByTheaterId(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var theater = _context.Theaters.Where(x => x.TheaterId == id)
                    .Select(x => new TheaterViewModel()
                    {
                        TheaterId = x.TheaterId, 
                        Name = x.TheaterName,
                        Location = x.ZipCode
                    }).FirstOrDefault();

                return theater;
            }
        }

        public static void Add(TheaterViewModel model)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var theater = new Theater()
                {
                    TheaterName = model.Name,
                    ZipCode = model.Location
                };

                _context.Theaters.Add(theater);

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
    }
}