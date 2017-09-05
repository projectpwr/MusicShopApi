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
    [Route("api/v1/[controller]")]
    public class AccountsController : DomainControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IOptions<AppConfiguration> _appConfiguration;

        public AccountsController(
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

  

        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] UserRegisterLogin model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(model.Email);

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) != PasswordVerificationResult.Success)
            {
                return BadRequest();
            }

            var token = await GetJwtSecurityToken(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }





        private async Task<JwtSecurityToken> GetJwtSecurityToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);


            return new JwtSecurityToken(
                issuer: _appConfiguration.Value.SiteUrl,
                audience: _appConfiguration.Value.SiteUrl,
                claims: GetTokenClaims(user).Union(userClaims),
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.Value.Key)), SecurityAlgorithms.HmacSha256)
            );
        }

        private IEnumerable<Claim> GetTokenClaims(User user)
        {
            var userRoles = _userManager.GetRolesAsync(user).Result.ToArray();
            var claims = new List<Claim>{
                                            new Claim("user_name", user.UserName),
                                            new Claim("user_email", user.Email),
                                        };
            List<Claim> rolesClaims = userRoles.Select(x => new Claim("role", x)).ToList();
            claims.AddRange(rolesClaims);

            return claims;
        }





        /*
 * 
 *  IF WE WANT TO LOGIN / OUT USING SESSION COOKIES THEN REACTIVATE THESE METHODS. FOR NOW WE'RE ONLY USING TOKEN BASED AUTH
[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] AccountRegisterLogin model)
{
    if (!ModelState.IsValid)
    {
        return BadRequest();
    }

    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

    if (!result.Succeeded)
    {
        return BadRequest();
    }

    return Ok();
}

[HttpPost("logout")]
public async Task<IActionResult> Logout()
{
    try
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
    catch
    {
        return BadRequest();
    }

}
*/
    }
}

