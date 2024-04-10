using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using starwars.IBusinessLogic;
using starwars.WebApi.Filters;
using starwars.WebApi.Dtos;

namespace starwars.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [ExceptionFilter]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateModel userCreateModel)
        {
            _userService.InsertUser(userCreateModel.ToEntity());

            return Ok();
        }
    }
}