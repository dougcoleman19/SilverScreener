
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverScreener.ViewModels
{
    public class TheaterViewModel
    {
        public TheaterViewModel()
        {
            this.Movies = new List<MovieViewModel>();
        }

        public int TheaterId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<MovieViewModel> Movies { get; set; }
    }
}