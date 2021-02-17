using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videly.Models;
using Videly.ViewModels;
using System.Data.Entity;
namespace Videly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie

        ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel(movies)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
           
        }

        public ActionResult Index()
        {
           
            var movies = _context.Movies.Include(c=>c.Genre).ToList();
            return View(movies);
        }

        
        //[Route("movie/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        //public ActionResult ByReleaseDate(int year,byte month)
        //{
        //    return Content(month+"/"+year);
        //}


        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m=>m.Genre).SingleOrDefault(c => c.Id == id);
            return View(movies);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel()
            {
               
                Genres = genres
            };
            return View("MovieForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm",viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
       
    }
}