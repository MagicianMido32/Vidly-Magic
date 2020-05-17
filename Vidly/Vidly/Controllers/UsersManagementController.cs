using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize(Roles = RoleName.CanManageUsers)]
    public class UsersManagementController : Controller
    {
        private ApplicationDbContext _context;
        private UserStore<ApplicationUser> userStore;
        private UserManager<ApplicationUser> userManager;

        //just gonna leave them to remember
        //private RoleStore<IdentityRole> roleStore;

        //private RoleManager<IdentityRole> roleManager;
        //private ApplicationSignInManager signInManager;

        public UsersManagementController()
        {
            _context = new ApplicationDbContext();
            userStore = new UserStore<ApplicationUser>(_context);
            userManager = new UserManager<ApplicationUser>(userStore);
            //roleStore = new RoleStore<IdentityRole>(_context);
            //roleManager = new RoleManager<IdentityRole>(roleStore);
        }

        // GET: UsersManagement
        public ActionResult Index()
        {
            var listOfUsers = new List<ApplicationUserViewModel>();
            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                var userModel = new ApplicationUserViewModel { Id = user.Id, UserName = user.UserName };
                listOfUsers.Add(userModel);
            }
            return View(listOfUsers);
        }

        public ActionResult EditUser(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound("User not found");
            }

            var viewModel = new EditUserViewModel
            {
                User = user,
                CanManageMovies = userManager.IsInRole(user.Id, RoleName.CanManageMovies),//hmm
                CanManageUsers = userManager.IsInRole(user.Id, RoleName.CanManageUsers),//hmm
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EditUserViewModel userViewModel)
        {
            /*
             * only admin allowed
             * check if model is valid
             * if not return error
             * map application user to application user
             * save changes
             * return to index
             */

            if (!ModelState.IsValid)
            {
                return Content("Model is not valid");
            }
            var userInDb = _context.Users.Single(u => u.Id == userViewModel.User.Id);
            Mapper.Map(userViewModel.User, userInDb);

            var userHasManageMoviesRole = userManager.IsInRole(userViewModel.User.Id, RoleName.CanManageMovies);
            //checkbox selected but user doesn't have that role => add the role
            if (userViewModel.CanManageMovies && !userHasManageMoviesRole)
            {
                ////works too
                //var role = _context.Roles.SingleOrDefault(m => m.Name == RoleName.CanManageMovies);
                //userInDb.Roles.Add(new IdentityUserRole { RoleId = role.Id }); // worried about this

                userManager.AddToRole(userViewModel.User.Id, RoleName.CanManageMovies);
                //User have to resign to change roles , or wait for 30 minutes for the session to revalidate
                //check https://stackoverflow.com/questions/36766191/asp-net-identity-add-another-user-to-role-instantly-they-dont-have-to-log-out
            }
            //checkbox isn't selected but the user is in the role => remove the role
            else if (!userViewModel.CanManageMovies && userHasManageMoviesRole)
            {
                userManager.RemoveFromRole(userViewModel.User.Id, RoleName.CanManageMovies);
            }
            //else = > the checkbox is selected and the user has the role , the checkbox unselected and the user doesn't have the role => do nothing

            if (userViewModel.CanManageUsers && !userManager.IsInRole(userViewModel.User.Id, RoleName.CanManageUsers))
            {
                userManager.AddToRole(userViewModel.User.Id, RoleName.CanManageUsers);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "UsersManagement");
        }

        //
        //GET: /UsersManagement/AddAdminToRole
        // [Route("UsersManagement/AddAdminToRole/{roleName}")]
        public ActionResult AddAdminToRole()
        {
            var admin = _context.Users.Single(u => u.Id == "a4426d37-47bd-4bd2-99cf-417782cc0a71");
            _context.Roles.Add(new IdentityRole { Name = RoleName.CanManageUsers });//creates a new role
            _context.SaveChanges();
            var role = _context.Roles.SingleOrDefault(m => m.Name == RoleName.CanManageUsers);
            admin.Roles.Add(new IdentityUserRole { RoleId = role.Id });

            _context.SaveChanges();

            return Content("done");
        }
    }
}