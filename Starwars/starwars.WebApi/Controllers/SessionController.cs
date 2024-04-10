using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using starwars.IBusinessLogic;
using starwars.WebApi.Filters;
using starwars.WebApi.Dtos;

namespace starwars.WebApi.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    [ExceptionFilter]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginModel userLoginModel)
        {
            var token = _sessionService.Authenticate(userLoginModel.Email, userLoginModel.Password);
            return Ok(new { token = token });
        }

        // En los endpoints que quiero usar autenticación, agrego el filtro, si quiero usarlo en todos los endpoints
        // de un controller lo agrego a nivel de la clase
        [ServiceFilter(typeof(AuthenticationFilter))]
        [AuthorizationFilter(RoleNeeded = "Admin")]
        [HttpDelete]
        public IActionResult Logout()
        {
            // TODO: Implementar logout
            return Ok();
        }

        [ActionFilter]
        [ResultFilter]
        [ResourceFilter]
        [HttpGet]
        public IActionResult Get(){
            Console.WriteLine("Ejecuto método");
            return Ok("ejecuto metodo");
        }
    }
}