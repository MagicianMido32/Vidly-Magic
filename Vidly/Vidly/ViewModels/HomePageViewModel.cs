using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toaster;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class HomePageViewModel
    {
        //I know I only have to pass an IEnumerable of movies but I created this View model in case I want to pass something else later

        public IEnumerable<Movie> Movies { get; set; }
    }
}