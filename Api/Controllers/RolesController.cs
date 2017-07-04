using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize(Roles="Admin")]
    [Route("api/v1/[controller]")]
    public class RolesController : DomainControllerBase
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController( RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }



        
       [HttpPost]
       public async Task<IActionResult> Create([FromBody] IdentityRole model)
       {

           //validateInboundModel()
           if (!ModelState.IsValid || model == null)
           {
               return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
           }


           var role = new IdentityRole { Name = model.Name };
           var result = await _roleManager.CreateAsync(role);

           //validateResultSucceeded()
           if (!result.Succeeded)
           {
               return BadRequest(result.Errors.Select(x => x.Description).ToList());
           }

           return Ok();
       }
       
        [HttpGet]
        public string GetAll()
        {
            return SerializeObject( _roleManager.Roles.ToList() );
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if(role == null)
            {
                return NotFound();
            }
            return Ok( SerializeObject(role) );
        }


    }
}

