using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Playroom;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //POST
        //api/NewRentals/
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateRental(RentalDto rental)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);

            //customer Id not valid
            if (customer == null)
                return BadRequest("Customer Id is not valid.");

            //No movies Ids
            if (rental.MovieIds.Count == 0)
                return BadRequest("No Movies Ids have been given.");

            //Customer is delinquent
            if (customer.Delinquent)
                return BadRequest("Customer is delinquent.");

            //Customer trying to rent more than 5 movies
            if (rental.MovieIds.Count > 5)
                return BadRequest("You can't rent more than 5 movies at one time.");

            var movies = _context.Movies.Where(
                m => rental.MovieIds.Contains(m.Id)).ToList();

            //One or more MovieIds are invalid.
            if (movies.Count != rental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                //Movie is not available.
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;
                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(newRental);
            }

            _context.SaveChanges();
            //we didn't use created because we have multiple resources
            return Ok();
        }

        //GET /api/NewRentals, only used to get the movies
        public IHttpActionResult GetRentedMovies(int id, string query = null)
        {
            // var moviesList = new List<MovieDto>();
            //Customers rentals
            var rentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.Customer.Id == id && r.DateReturned == null).ToList();

            if (!string.IsNullOrEmpty(query))
            {
                rentals = rentals.Where(r => r.Movie.Name.Contains(query)).ToList();//to end the query and release the reader
            }

            var moviesList = new List<MovieDto>();

            foreach (var rental in rentals)
            {
                var movie = _context.Movies.Single(m => m.Id == rental.Movie.Id);
                var movieDto = new MovieDto()
                {
                    Id = movie.Id,
                    Name = movie.Name
                };
                moviesList.Add(movieDto);
            }
            return Ok(moviesList);
        }
    }
}