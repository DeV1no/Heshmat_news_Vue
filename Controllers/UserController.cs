using System.Threading.Tasks;
using dadachMovie.Services.Contracts;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(IUserService userService, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("/Register")]
        public User Post(UserRegisterViewModelDTO user)
        {
            return _userService.RegisterUser(user);
        }

        [HttpPost("/Login")]
        [HttpPost("Login", Name = "Login")]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] UserLoginViewModelDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email,
                model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await _userService.BuildToken(model);
            }
            else
            {
                return BadRequest("Invalid login attempt");
            }
        }
    }
}