using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SilverScreener.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new HashSet<Genre>();
            this.Showtimes = new List<ShowTime>();
            //this.Theater = new Theater();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        public Rating Rating { get; set; }

        public string RunTime { get; set; }

        public virtual Theater Theater { get; set; }

        public int TheaterId { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public int RatingId { get; set; }

        [Required]
        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<ShowTime> Showtimes { get; set; }

        public string PosterImage { get; set; }
    }
}