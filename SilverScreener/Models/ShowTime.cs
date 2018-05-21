using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SilverScreener.ViewModels;

namespace SilverScreener.Models
{
    public class ShowTime
    {
        public ShowTime()
        {
            this.Movie = new Movie();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowTimeId { get; set; }
        public DateTime Showing { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}