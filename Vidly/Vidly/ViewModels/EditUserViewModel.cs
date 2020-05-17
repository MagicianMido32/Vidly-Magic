using Vidly.Models;

namespace Vidly.ViewModels
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }
        public bool CanManageMovies { get; set; }
        public bool CanManageUsers { get; set; }
    }
}