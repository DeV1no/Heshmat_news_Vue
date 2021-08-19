using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.DTOs.User;
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

        public UserController(IMapper mapper, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost("Register")]
        public IActionResult Post(UserRegisterDTO user)
        {
            return Ok(_userService.Register(user));
        }

        [HttpPost("Login", Name = "Login")]
        public IActionResult Login([FromBody] UserLoginDTO model)
        {
            var user = _userService.Authenticate(model);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
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

        [HttpGet("getUserLsit")]
        //  [Authorize]
        public List<UserListViewModelDTO> GetUserList()
        {
            return _userService.GetUserList();
        }

        [HttpPost("isUniqueUserName")]
        public bool IsUniqueUserName(string username)
        {
            return !_userService.IsUniqueUser(username);
        }

        [HttpPost("isUniqueEmail")]
        public bool IsUniqueEmail(string email)
        {
            return !_userService.IsUniqueEmail(email);
        }

        [HttpPost("activeUserBySecretCode")]
        public int ActiveUserBySecretCode(string secretCode)
        {
            return _userService.ActiveUserBySecretKey(secretCode);
        }

        [HttpPost("ressetPasswordBySecretKey")]
        public int ResetPasword(string secretKey, string password)
        {
            return _userService.ResetPasswordBySecretKey(secretKey, password);
        }

        [HttpPost("userExistedWithSecretKey")]
        public bool isExistedUserBySecretCode(string secretKey)
        {
            var userDb = _userService.GetUserBySecretCode(secretKey);
            if (userDb == null)
                return false;
            return true;
        }

        [HttpPut("addroleToUser")]
        public bool AddRoleToUser([FromBody] UserRoleDTO model)
        {
            return _userService.AddRoleToUser(model.userId, model.roleId);
        }

        [HttpPut("removeRoleFromUser/{userId:int}")]
        public bool RemoveRoleFromUser(int userId)
        {
            return _userService.RemoveRoleToFrom(userId);
        }

        [HttpPut("updateUserInformation")]
        public async Task<bool> UpdateuserInformation([FromForm] UpdateUserInformationDTO model)
            => await _userService.UpdateUserInformation(model);
        [HttpGet("getUserDetails/{userId:int}")]
        public UserListViewModelDTO GetUserDetails(int userId)
        {
            return _userService.GetUserDataById(userId);
        }


        [HttpGet("getUserProfileInfo/{userId:int}")]
        public Task<UpdateUserInformationDTO> GetUserProfileInfo(int userId)
            => _userService.GetUserProfileInfo(userId);

    }
}