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
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IOptions<AppConfiguration> _appConfiguration;

        public AccountsController(
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


        private async Task<JwtSecurityToken> GetJwtSecurityToken(UserEntity user)
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

        private IEnumerable<Claim> GetTokenClaims(UserEntity user)
        {

            var userRoles = _userManager.GetRolesAsync(user).Result;
            var userRolesArray = userRoles.ToArray();

            var claims = new List<Claim>{
                                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                                        };

            for(var ii=0; ii < userRolesArray.Length; ii++)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRolesArray[ii]));
            }

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

