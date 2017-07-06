using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/v1/user/{id}/roles/{roleName}")]
    public class UserRolesController : DomainControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpPost]
        public IActionResult CreateUser2Role(string id, string roleName)
        {

            var user = _userManager.FindByIdAsync(id).Result;
            if(user == null)
            {
                return NotFound("user");
            }

            var role = _roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                return NotFound("role");
            }

            var result = _userManager.AddToRoleAsync(user, roleName).Result;

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }
            return Ok();
        }



        [HttpGet]
        public IActionResult GetByRoleName(string id, string roleName)
        {
            //TODO: try validate user and role in seperate method - get rid of copy/paste validation or this method and one above
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return NotFound("user");
            }
            var role = _roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                return NotFound("role");
            }

            var userRoles = _userManager.GetRolesAsync(user).Result;
            var rolesFound = userRoles.Select(x => x == roleName);

            if (rolesFound.Count() > 0)
            {
                return Ok(string.Concat("User has the role: ", roleName));
            }
            else
            {
                return NotFound("User does not have the role specified.");
            }
        }


        /*
        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                _userManager.DeleteAsync(user);
            }
        }
        */

    }
}
