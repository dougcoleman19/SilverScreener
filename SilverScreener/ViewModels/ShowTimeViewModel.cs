using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverScreener.ViewModels
{
    public class ShowTimeViewModel
    {
        public ShowTimeViewModel()
        {
            this.Movie =  new MovieViewModel();
        }

        public int ShowTimeId { get; set; }
        public DateTime Showing { get; set; }

        public int MovieId { get; set; }
        public MovieViewModel Movie { get; set;  }
    }
}