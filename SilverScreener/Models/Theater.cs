using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SilverScreener.Models
{
    public class Theater
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheaterId { get; set; }

        [Required]
        [Display(Name = "Theater Name")]
        public string TheaterName { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}