using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class ReturnRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReturnRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //POST
        //api/ReturnRentals/
        [System.Web.Http.HttpPost]
        public IHttpActionResult ReturnRental(RentalDto rentalDto)
        {
            var rentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.Customer.Id == rentalDto.CustomerId).ToList();
            foreach (var rental in rentals)
            {
                if (rentalDto.MovieIds.Contains(rental.Movie.Id))
                {
                    rental.DateReturned = DateTime.Now;
                    var movie = _context.Movies.Single(m => m.Id == rental.Movie.Id);
                    movie.NumberAvailable++;
                }
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}