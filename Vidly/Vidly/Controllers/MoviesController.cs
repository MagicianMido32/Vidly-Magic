﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using AutoMapper;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List", movies);
            }
            return View("ReadOnlyList", movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var movie = new Movie(); //{ DateAdded = DateTime.Now }; wrong , we don't specify the dateAdded here, but in the Save Action
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList(),
                // Movie = new Movie(){} // initialize all to zero , solve the hidden field problem ,modified it later in the course
                //DateAdded = DateTime.Now you don't need to handel date added here , handle it when saving on the database
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie, HttpPostedFileBase file = null)
        {
            /* POST
             * in form BeginForm(Action,Controller)
             * @validate Anti Forgery
             * HTTP POST ,ValidateAntiForgery
             * Can manage movies role
             * Check Model state
             * if not valid return the same view with empty view model
             * if id==0 then it's new movie
             * else
             * get the movie from the context so EF can track the changes that happen to it
             * change it
             * save context
             * redirect to edit so the user can see changes (image)
             */
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)// used a constructor to initialize the view model
                {
                    Genres = _context.Genres.ToList(),
                };
                return View("MovieForm", viewModel);
            }

            //embedding movie
            //might wanna add similar logic in the Api but that's enough
            if (!string.IsNullOrEmpty(movie.TrailerLink))
            {
                if (!movie.TrailerLink.Contains(@"/embed/"))
                {
                    movie.TrailerLink = movie.TrailerLink
                        .Replace(@"www.youtube.com", @"www.youtube.com/embed")
                        .Replace("watch?v=", "")
                        .Replace(@"youtu.be", "www.youtube.com/embed");
                }

            }

            if (movie.Id == 0)
            {
                //initialize number available
                movie.NumberAvailable = movie.NumberInStock;
                //specifying the date Added
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                Mapper.Map(movie, movieInDb);
                ////can use auto mapper ,
                //movieInDb.Name = movie.Name;
                //movieInDb.DateAdded = DateTime.Now;//Added Now
                //movieInDb.ReleaseDate = movie.ReleaseDate;
                //movieInDb.GenreId = movie.GenreId;
                //movieInDb.NumberInStock = movie.NumberInStock;
                //you can add genre from context or you may leave it null because EF only uses the foreign key
            }
            _context.SaveChanges();
            //new movie Id is generated by EF so we need to save changes to generate an Id for it and use it to save the photo

            //image logic
            if (file != null)
            {
                string pic = movie.Id.ToString() + ".jpg";
                string path = System.IO.Path.Combine(
                    Server.MapPath("~/Content/Images/"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}
            }

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie) // used a constructor to initialize the view model
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}