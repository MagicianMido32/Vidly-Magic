using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //we create a view model so we don't have to bother with the hidden field being nullable
        // public Movie Movie { get; set; }
        public int? Id { get; set; }

        [Required(ErrorMessage = "The Name field is required."), StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Trailer")]
        public string TrailerLink { get; set; }

        [Required(ErrorMessage = "Please select genre."), Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "The Release Date field is required."), Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; } // Make it nullable prevents 1 jan 0001 problem,

        ///https://stackoverflow.com/questions/1331779/conversion-of-a-datetime2-data-type-to-a-datetime-data-type-results-out-of-range

        [Required(ErrorMessage = "The number is stock is required")]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "The field number is stock must be between 1 and 20")]
        [Display(Name = "Number in stock")]//i made this thing nullable but I don't remember why ...
        public int NumberInStock { get; set; }

        //we don't put model specific values here such as date Added and number Available , since it's not used in the view
        //it's related to the inner logic of the app

        public MovieFormViewModel(Movie movie)
        {
            //I don't like this. each time I change my Movie Model I have to comeback here and change here also
            //prop-ably should use auto mapper , but enough optimization here

            //Id = movie.Id;
            //Name = movie.Name;
            //TrailerLink = movie.TrailerLink;
            //ReleaseDate = movie.ReleaseDate;
            //NumberInStock = movie.NumberInStock;
            //GenreId = movie.GenreId;
            Mapper.Map(movie, this);
        }

        public MovieFormViewModel()
        {
            Id = 0; // to make sure that the hidden field is populated
        }
    }
}