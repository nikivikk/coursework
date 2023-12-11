using art_store.art_storeDto;
using art_store.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace art_store.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(
            IConfiguration configuration,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var newUser = new User { UserName = model.Name, Name = model.Name, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password!);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResultDto { IsSuccessful = false, Errors = errors });

            }

            return Ok(new RegisterResultDto { IsSuccessful = true });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user is null)
                {
                    return BadRequest(new LoginResultDto { IsSuccessful = false, Error = "Username and password are invalid." });
                }
                var result = await _signInManager.PasswordSignInAsync(user, login.Password!, false, false);
                if (!result.Succeeded) return BadRequest(new LoginResultDto { IsSuccessful = false, Error = "Username and password are invalid." });

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.Email!),
                    new Claim(ClaimTypes.UserData, user.Id.ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

                var token = new JwtSecurityToken(
                    _configuration["JwtIssuer"],
                    _configuration["JwtAudience"],
                    claims,
                    expires: expiry,
                    signingCredentials: creds
                );

                return Ok(new LoginResultDto { IsSuccessful = true, AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResultDto { IsSuccessful = false, Error = "Username and password are invalid." });
            }

           
            //try
            //{
            //    var user = await _userManager.FindByEmailAsync(login.Email);
            //    var result = await _signInManager.PasswordSignInAsync(user, login.Password!, false, false);
            //    if (!result.Succeeded) return BadRequest(new LoginResultDto { IsSuccessful = false, Error = "Username and password are invalid." });
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new LoginResultDto { IsSuccessful = false, Error = "Username and password are invalid." });
            //}

            //var claims = new[]
            //{
            //new Claim(ClaimTypes.Name, login.Email!)
       

            
        }
    }
}
