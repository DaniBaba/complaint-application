using Microsoft.AspNetCore.Mvc;
using Complaint.Api.Global.Framework;
using Complaint.Api.Global.Requests;
using Complaint.Api.Global.Services;
using Complaint.Api.Services;

namespace Complaint.Api.Global.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(AuthRequest request)
        {
            return Ok(_userService.Login(request));
        }

        [HttpPost("register")]
        public IActionResult Register(UserRequest request)
        {
            return Ok(_userService.Register(request));
        }
    }
}
