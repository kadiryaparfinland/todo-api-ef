using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.IService;
using ToDo.Application.Response;
using ToDo.Domain.DBModel;
using ToDo.Domain.Enum;
using ToDo.Domain.IEntity;
using ToDo.Domain.Model;

namespace ToDo.Api.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        public UserController(UserManager<ApplicationUser> userManager, ICurrentUser currentUser)
        {
            _userManager = userManager;
            _currentUser = currentUser;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var data = await _userManager.Users.ToListAsync();
            var users = data.Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });
            
            return Ok(users);
        }
        
        [HttpPatch]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(_currentUser.User.Id.ToString());
            await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            return Ok();
        }
    }
}
