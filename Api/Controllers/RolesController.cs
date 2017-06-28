using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class RolesController : ControllerBase
    {


       
        private readonly RoleManager<UserRole> _roleManager;

        public RolesController( RoleManager<UserRole> roleManager ){
            _roleManager = roleManager;
        }

        /*


       [HttpPost]
       public async Task<IActionResult> Create([FromBody] UserRole model)
       {

           //validateInboundModel()
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
           }


           var role = new UserRole { Name = model.Name };
           var result = await _roleManager.CreateAsync(role);

           //validateResultSucceeded()
           if (!result.Succeeded)
           {
               return BadRequest(result.Errors.Select(x => x.Description).ToList());
           }

           return Ok();
       }


           */


        /*
        [HttpGet]
        public List<UserRole> Get()
        {
            return _roleManager.Roles.ToList();
        }
        */

        [HttpGet]
        public string Get()
        {
            return "";
            //return JsonConvert.SerializeObject(_roleManager.Roles.ToList(), Formatting.Indented);
        }



    }
}

