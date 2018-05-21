using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SilverScreener.Models;

namespace SilverScreener.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            this.ShowTimes = new List<ShowTimeViewModel>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string RunTime { get; set; }

        public int? TheaterId { get; set; }
        public TheaterViewModel Theater { get; set; }

        public int RatingId { get; set; }
        public string RatingName { get; set; }

        [Display(Name = "Rating")]
        public List<Rating> Ratings { get; set; }

        public List<ShowTimeViewModel> ShowTimes { get; set; }

        [Display(Name = "Genres")]
        public List<CheckBoxListItem> Genres { get; set; }

        public HttpPostedFileBase File { get; set; }
        public string Poster { get; set; }
    }
}