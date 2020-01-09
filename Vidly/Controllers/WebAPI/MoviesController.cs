using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.WebAPI
{
    public class MoviesController : ApiController
    {
        //return one movie based on id
        //return all movies
        //add movie
        //delete movie
        //update movie based on id

        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


    
       public IHttpActionResult GetMovie(int id)
        {


            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

       
        public  IHttpActionResult GetMovies(string query=null)
        {
            var moviesQuery = _context.Movies
                    .Include(m => m.Genre)
                    .Where(m => m.NumberAvailable > 0);
   
            if (!String.IsNullOrWhiteSpace(query))
            moviesQuery=  moviesQuery.Where(m => m.Name.Contains(query));

            var movieDtos = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);

        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(Request.RequestUri.ToString() + "/" + movie.Id,movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.Where(m => m.Id == id).SingleOrDefault();
            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();


            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}