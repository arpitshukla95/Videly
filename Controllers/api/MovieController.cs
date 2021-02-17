using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videly.Dtos;
using Videly.Models;

namespace Videly.Controllers.api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
         
        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
            return movies;

        }
        // GET /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(Mapper.Map<Movie,MovieDto>(movies));
        }
        
        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movies = Mapper.Map<MovieDto,Movie>(movieDto);
            _context.Movies.Add(movies);
            _context.SaveChanges();
            movieDto.Id = movies.Id;
            return Created(new Uri(Request.RequestUri+"/"+movies.Id),movieDto);


        }
        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int Id,MovieDto movieDto)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if(movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
        }

        //DELETE /api/movies/1
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
