using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SilverScreener.Models
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required]
        [Display(Name = "Rating Name")]
        public string RatingName { get; set; }

        [Required]
        [Display(Name = "Rating Description")]
        public string RatingDescription { get; set; }
    }
}