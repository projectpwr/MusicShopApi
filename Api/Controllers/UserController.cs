using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/v1/[controller]")]
    public class UserController : DomainControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IOptions<AppConfiguration> _appConfiguration;

        public UserController(
            UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager,
            IPasswordHasher<UserEntity> passwordHasher,
            IOptions<AppConfiguration> appConfiguration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _appConfiguration = appConfiguration;
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRegisterLogin model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            var user = new UserEntity { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return SerializeObject(_userManager.Users.ToList());
        }

        [HttpGet("{id}")]
        public string GetById(string id)
        {
            return SerializeObject(_userManager.Users.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                _userManager.DeleteAsync(user);
            }
        }


    }
}
