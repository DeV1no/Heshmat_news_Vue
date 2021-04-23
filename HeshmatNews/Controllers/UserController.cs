using System.Linq;
using System.Threading.Tasks;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace HeshmastNews.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private ApplicationDbContext _context;

        public UserController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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
            var result =
                _context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            
            
            /*
            var result =
                _context.User.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                */

            if (result != null)
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