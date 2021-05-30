using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs.User;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController( IMapper mapper, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost("Register")]
        public IActionResult Post(UserRegisterDTO user)
        {
            return Ok( _userService.Register(user));
        }

        [HttpPost("Login", Name = "Login")]
        public  IActionResult Login([FromBody] UserLoginDTO model)
        {
            var user = _userService.Authenticate(model);
            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});
            return Ok(user);
        }

        [HttpGet("CurrentUser")]
        [Authorize]

        public IActionResult GetCurrentUser()
        {
           var userId = _httpContextAccessor.HttpContext.User.Identity.Name;
           var user = _userService.GetCurrentUserById(userId);
           return Ok(user);
        }
    }
}