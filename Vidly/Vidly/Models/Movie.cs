using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required."), StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Trailer")]
        public string TrailerLink { get; set; }

        [Required(ErrorMessage = "Please select genre."), Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "The Release Date field is required."), Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; } // Make it nullable prevents 1 jan 0001 problem,

        ///https://stackoverflow.com/questions/1331779/conversion-of-a-datetime2-data-type-to-a-datetime-data-type-results-out-of-range

        //[Required(ErrorMessage = "The Adding Date field is required"),Display(Name = "Date Added")] // isn't used in the form whatsoever but fuck it
        public DateTime? DateAdded { get; set; }

        [Required(ErrorMessage = "The number is stock is required")]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "The field number is stock must be between 1 and 20")]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        //you will have to initialize this attribute using a SQL migration
        //Sql("UPDATE Movies SET NumberAvailable = NumberInStock")
        public int NumberAvailable { get; set; }

        //you know what , I'm not gonna put the movie pic src in the database , I'll keep calculating it from the movie Id
    }
}