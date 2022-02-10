using DesafioBackend.DTO;
using DesafioBackend.Services.Interfaces;
using DesafioBackend.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioBackend.Controllers
{
    [ApiController]
    [Route("api/v1/profiles")]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IProfileService profileService
            )
        {
            var allProfiles = await profileService.GetAll();

            return Ok(new ResultViewModel
            {
                Message = null,
                Success = true,
                Data = allProfiles
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            [FromServices] IProfileService profileService
            )
        {
            var profile = await profileService.GetById(id);

            return Ok(new ResultViewModel
            {
                Message = null,
                Success = true,
                Data = profile
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProfileCreateDTO profileCreateDTO,
            [FromServices] IProfileService profileService
            )
        {
            var profileCreated = await profileService.Create(profileCreateDTO);

            return Ok(new ResultViewModel
            {
                Message = null,
                Success = true,
                Data = profileCreated
            });
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            [FromServices] IProfileService profileService
            )
        {
            await profileService.Remove(id);

            return Ok(new ResultViewModel { Message = "Perfil deletado", Success = true, Data = null });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] ProfileUpdateDTO profileUpdateDTO,
            [FromServices] IProfileService profileService
            )
        {
            if(profileUpdateDTO.Id != id)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = "Id inválido",
                    Success = false,
                    Data = null
                });
            }

            var profileExists = await profileService.GetById(id);
            if (profileExists == null) 
            {

                return NotFound(new ResultViewModel
                {
                    Message = "Perfil não encontrado",
                    Success = false,
                    Data = null
                }) ;
            }

            profileUpdateDTO.Modified = DateTime.Now;
            
            var profileUpdated = await profileService.Update(profileUpdateDTO);

            return Ok(new ResultViewModel
            {
                Message = null,
                Success = true,
                Data = profileUpdated
            });
        }
    }
}
