using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Videly.Models;

namespace Videly.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre is")]
        [Required]
        public byte GenreId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }
                return "New Movie";
            }
        }
        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movies)
        {

            Id = movies.Id;
            Name = movies.Name;
            ReleaseDate = movies.ReleaseDate;
            GenreId = movies.GenreId;
            NumberInStock = movies.NumberInStock;
        }
    }
}