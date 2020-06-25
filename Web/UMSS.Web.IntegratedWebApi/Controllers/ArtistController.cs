using System;
using AutoMapper;
using System.Threading.Tasks;
using UMSS.Core.Common.Models;
using Microsoft.AspNetCore.Mvc;
using UMSS.Core.Common.Entities;
using UMSS.Core.Common.Services;
using System.Collections.Generic;
using UMSS.Web.IntegratedWebApi.Resources;
using UMSS.Web.IntegratedWebApi.Validators;

namespace UMSS.Web.IntegratedWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            this._mapper = mapper;
            this._artistService = artistService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> GetAllArtists()
        {
            var result = await _artistService.GetAllEntity();

            if (!result.Success)
                return BadRequest(result.Message);

            //var artistResources = _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistResource>>(result.EntityList);

            return Ok(result.EntityList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistModel>> GetArtistById(int id)
        {
            var result = await _artistService.GetEntityById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            //var artistResource = _mapper.Map<Artist, ArtistResource>(result.Entity);

            return Ok(result.Entity);
        }

        [HttpPost("")]
        public async Task<ActionResult<ArtistModel>> CreateArtist([FromBody] SaveArtistResource saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var artistToCreate = _mapper.Map<SaveArtistResource, Artist>(saveArtistResource);

            var result = await _artistService.CreateEntity(artistToCreate);
            if (!result.Success)
                return BadRequest(result.Message);

            //var artistResource = _mapper.Map<Artist, ArtistResource>(result.Entity);

            return Ok(result.Entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArtistModel>> UpdateArtist(int id, [FromBody] SaveArtistResource saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);
            var requestIsInvalid = id == 0 || !validationResult.IsValid;
            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var artistToUpdate = _mapper.Map<SaveArtistResource, Artist>(saveArtistResource);

            var result = await _artistService.UpdateEntity(id, artistToUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            //var updatedArtistResource = _mapper.Map<Artist, ArtistResource>(result.Entity);

            return Ok(result.Entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var result = await _artistService.DeleteEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}