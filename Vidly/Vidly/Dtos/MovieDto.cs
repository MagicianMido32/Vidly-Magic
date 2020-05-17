using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(), StringLength(255)]
        public string Name { get; set; }

        public string TrailerLink { get; set; }

        [Required()]
        public byte GenreId { get; set; }

        //it's only used to return genre object to the Get method
        //we don't use it to set the genre we use the GenreId instead
        //this is only used to present the genre when using get
        //WE NEVER CHANGE OR ADD GENRES
        //It's called reference data
        public GenreDto Genre { get; set; }

        [Required()]
        public DateTime? ReleaseDate { get; set; }

        [Range(minimum: 1, maximum: 20)]
        public int NumberInStock { get; set; }

        //we don't put model specific values here such as date Added and number Available , since it's not used in the Api
        //it's related to the inner logic of the app
    }
}