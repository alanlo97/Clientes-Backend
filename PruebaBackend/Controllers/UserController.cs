using Microsoft.AspNetCore.Mvc;
using PruebaBackend.Models.Dtos;
using PruebaBackend.Services.Interfaces;
using System.Threading.Tasks;

namespace PruebaBackend.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IServiceUser _userService;
        public UserController(IServiceUser userService)
        {
            this._userService = userService;
        }
 
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _userService.LoginAsync(userLoginDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(result.isError() ? 500 : 400, result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDtoForRegister dto)
        {
            var result = await _userService.Insert(dto);
            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(result.isError() ? 500 : 400, result);
        }     
    }
}
