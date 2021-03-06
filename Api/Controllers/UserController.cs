﻿using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/v1/[controller]")]
    public class UserController : DomainControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IOptions<AppConfiguration> _appConfiguration;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IPasswordHasher<User> passwordHasher,
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

            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }

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
