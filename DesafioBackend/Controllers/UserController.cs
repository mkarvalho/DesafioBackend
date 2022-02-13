using DesafioBackend.DTO.User;
using DesafioBackend.Entities;
using DesafioBackend.Services.Interfaces;
using DesafioBackend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioBackend.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IUserService userService
            )
        {
            var users = await userService.GetAll();

            return Ok(new ResultViewModel(users));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            [FromServices] IUserService userService
            )
        {
            var user = await userService.GetById(id);

            if (user == null)
            {
                return NotFound(new ResultViewModel(true, "Usuário não encontrado"));
            }

            return Ok(new ResultViewModel(user));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] UserCreateDTO user,
            [FromServices] IUserService userService
            )
        {
            var checkEmail = await userService.GetByEmail(user.Email);
            if(checkEmail != null)
            {
                return BadRequest(new ResultViewModel(true, "Email já existente"));
            }

            var userCreated = await userService.Create(user);

            return Ok(new ResultViewModel(userCreated));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            [FromServices] IUserService userService
            )
        {
            var userExists = await userService.GetById(id);
            if (userExists == null)
            {
                return NotFound(new ResultViewModel(true, "Usuário não encontrado"));
            }

            await userService.Remove(id);

            return Ok(new ResultViewModel(false, "Perfil deletado"));

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UserUpdateDTO userUpdateDTO,
            [FromServices] IUserService userService
            )
        {

            if (userUpdateDTO.Id != id)
            {
                return BadRequest(new ResultViewModel(true, "Id inválido"));
            }

            var checkEmail = await userService.GetByEmail(userUpdateDTO.Email);
            if (checkEmail != null)
            {
                return BadRequest(new ResultViewModel(true, "Email já existente"));
            }

            var userUpdated = await userService.Update(userUpdateDTO);

            return Ok(new ResultViewModel(userUpdated));

        }
    }
}
