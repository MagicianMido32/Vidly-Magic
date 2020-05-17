using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Authorize(Roles = RoleName.CanManageUsers)]
    public class UsersManagementController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersManagementController()
        {
            _context = new ApplicationDbContext();
        }

        //DELETE /api/UsersManagement
        [HttpDelete]
        public void DeleteUser(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}