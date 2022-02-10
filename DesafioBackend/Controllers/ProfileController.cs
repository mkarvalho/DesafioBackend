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
            [FromBody] ProfileDTO profileDTO,
            [FromServices] IProfileService profileService
            )
        {
            var profileCreated = await profileService.Create(profileDTO);

            return Ok(new ResultViewModel
            {
                Message = null,
                Success = true,
                Data = profileCreated
            });
        }
    }
}
