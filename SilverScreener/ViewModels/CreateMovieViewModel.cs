using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Razor;
using SilverScreener.Models;

namespace SilverScreener.ViewModels
{
    public class CreateMovieViewModel
    {
        [Required]
        [Display(Name = "Movie Title")]
        [StringLength(128, ErrorMessage = "Movie Titles can only be 128 charactgers in length.")]
        public string MovieTitle { get; set; }

        public int RatingId { get; set; }
        public string RatingName { get; set; }
        [Display(Name = "Rating")]
        public List<Rating> Ratings { get; set; }

        [Display(Name = "Genres")]
        public List<CheckBoxListItem> Genres { get; set; }

        public string MoviePoster { get; set; }
    }

    public class EditMovieViewModel : CreateMovieViewModel
    {
        public int ID { get; set; }
    }
}