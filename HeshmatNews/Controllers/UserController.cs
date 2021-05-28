using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper _mapper;

        public UserController( IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
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
    }
}