using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Login_Gabriel.Shared; //para login DTO y sesion DTO
//Api para consumir desde el cliente 
namespace Login_Gabriel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();

            if (login.UserName == "admin@gmail.com" && login.Password == "admin")
            {
                sesionDTO.Name = "admin";
                sesionDTO.UserName = login.UserName;
                sesionDTO.Role = "ADMINISTRADOR";
            }
            else
            {
                sesionDTO.Name = "empleado";
                sesionDTO.UserName = login.UserName;
                sesionDTO.Role = "EMPLEADO";
            }
            return StatusCode(StatusCodes.Status200OK,sesionDTO);
        }


    }
}
