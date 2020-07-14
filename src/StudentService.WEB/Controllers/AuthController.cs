using Microsoft.AspNetCore.Mvc;
using StudentService.BLL.Interfaces;
using StudentService.DAL.Models;

namespace StudentService.WEB.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IUserManager _userManager;
        readonly ITokenManager _tokenManager;

        public AuthController(IUserManager userManager, ITokenManager tokenManager)
        {
            this._userManager = userManager;
            this._tokenManager = tokenManager;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("Invalid client request");
            }

            var user = this._userManager.Verify(loginUser);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = this._tokenManager.GenerateAccessToken(user);

            return Ok(new { Token = token });
        }
    }
}
