using ToDo.Application.IService;
using ToDo.Application.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Authentication;
using ToDo.Domain.Constant;
using ToDo.Domain.DBModel;
using ToDo.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ToDo.Domain.Enum;

namespace ToDo.Api.Controllers
{
    public class AuthController : BaseController
    {

        private readonly TokenHelper _jwtExt;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public AuthController(
            TokenHelper jwtExt,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<UserRole> roleManager, 
            IConfiguration configuration,
            IMapper mapper)
        {
            _jwtExt = jwtExt;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            //var user = _mapper.Map<ApplicationUser>(registerModel);
            var user = new ApplicationUser()
            {
                Name = registerModel.Name,
                Email = registerModel.Email,
                UserName = registerModel.Email,
                PasswordHash = registerModel.Password
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                //return BadRequest(result.Errors.First().Code.ToString());
                var errors = result.Errors.Select(x => x.Description).ToList();
                return BadRequest(new AuthResponse(){ Errors = errors });
            }
            await _userManager.AddToRoleAsync(user, Role.User.ToString());
            return Ok();
        }

        [HttpPost]
        [Route("Signin")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password,true,false);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(loginModel.Email);

            if (user == null) return BadRequest();

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = await _jwtExt.GetToken(user, userRoles);
            return Ok(new LoginResponse()
            {
                Token = token,
                Name = user.Name,
                Email = user.Email
                //Role = userRoles.First()
            });
            //return Ok(new { token = new { Expires_in = 10000, Access_token  = token}});
        }

    }
}
