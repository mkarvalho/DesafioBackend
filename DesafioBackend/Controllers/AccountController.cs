using DesafioBackend.Services;
using DesafioBackend.Services.Interfaces;
using DesafioBackend.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using System.Threading.Tasks;

namespace DesafioBackend.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v1/accounts")]
    public class AccountController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromServices] TokenService tokenService,
            [FromBody] LoginViewModel loginViewModel,
            [FromServices] IUserService userService 
            )
        {
            var user = await userService.GetByEmail(loginViewModel.Email);
            if(user == null)
            {
                return Unauthorized(new ResultViewModel(true, "Usuário e / ou senha inválidos"));
            }

            if (!PasswordHasher.Verify(user.Password, loginViewModel.Password))
            {
                return Unauthorized(new ResultViewModel(true, "Usuário e / ou senha inválidos"));
            }

            var token = tokenService.GenerateToken(user);
            
            return Ok(new ResultViewModel(false, token));
        }

    }
}
