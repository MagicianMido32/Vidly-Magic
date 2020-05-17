using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int CustomerId { get; set; }

        //The name of the property in the model should be exactly like the name of the Ajax object
        //movieIds === movieIds ... moviesIds WRONG
        public List<int> MovieIds { get; set; }
    }
}