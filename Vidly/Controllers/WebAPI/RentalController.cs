using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.WebAPI
{
    public class RentalController : ApiController
    {
        ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            var moviesRented = CheckNumberOfMoviesRented(customer);

            if (moviesRented > RentalConstraint.MaxMoviesUserCanRent)

            return BadRequest(String.Format("Customer can rent max {0} movies.", RentalConstraint.MaxMoviesUserCanRent));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    RentalDate = DateTime.Now
                };

                _context.NewRentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }


        [HttpPut]
        public IHttpActionResult CheckMovieIn(int id)
        {
            var rental = _context.NewRentals
                .Include(rent => rent.Movie).Include(rent=>rent.Customer)
                .SingleOrDefault(rent => rent.Id == id);


            if (rental == null)
                return NotFound();

                rental.ReturningDate = DateTime.Now;

                var movie = rental.Movie;

    
                movie.NumberAvailable++;
            

            _context.SaveChanges();
            return Ok();



        }

        [HttpGet]
        public IHttpActionResult GetMoviesRented(string query=null)
        {
            var rentalsQuery = _context.NewRentals.
                 Include(r =>r.Movie).Include(r=>r.Customer).Where(m=>m.ReturningDate==null);

            if (!String.IsNullOrWhiteSpace(query))
                rentalsQuery = rentalsQuery.Where(c => c.Customer.Name.Contains(query));

            var rentalDtos = rentalsQuery
                .ToList().
                Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalDtos);
        }


        private int CheckNumberOfMoviesRented(Customer customer)
        {
            var rentals = _context.NewRentals.Where(rental => rental.Customer_Id == customer.Id);
            return rentals.Count();
        }
    }
}
