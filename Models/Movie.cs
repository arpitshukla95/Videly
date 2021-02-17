using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Videly.Models
{
    public class Movie
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Release date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1,20)]
        [Display(Name="Number in stock")]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Genre is")]
        [Required]
        public byte GenreId { get; set; }
    }
}