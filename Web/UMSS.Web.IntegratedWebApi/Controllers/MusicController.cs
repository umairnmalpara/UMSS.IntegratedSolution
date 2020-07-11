using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UMSS.Web.IntegratedWebApi.Resources;
using UMSS.Web.IntegratedWebApi.Validators;
using UMSS.Music.Business.Services.Interface;
using UMSS.Music.Model;

namespace UMSS.Web.IntegratedWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMusicService _musicService;

        public MusicController
        (
            IMapper mapper
            ,IMusicService musicService
        )
        {
            this._mapper = mapper;
            this._musicService = musicService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicModel>>> GetAllMusics()
        {
            var result = await _musicService.GetAllEntity();
            //var result = await _musicService.SearchMusicWithPagination();

            if (!result.Success)
                return BadRequest(result.Message);

            //var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(result.EntityList);

            return Ok(result.EntityList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicModel>> GetMusicById(int id)
        {
            var result = await _musicService.GetEntityById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            //var musicResource = _mapper.Map<Music, MusicResource>(result.Entity);

            return Ok(result.Entity);
        }

        [HttpPost("")]
        public async Task<ActionResult<MusicModel>> CreateMusic([FromBody] SaveMusicResource saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var musicToCreate = _mapper.Map<SaveMusicResource, UMSS.Music.Entity.Music>(saveMusicResource);

            var result = await _musicService.CreateEntity(musicToCreate);
            if (!result.Success)
                return BadRequest(result.Message);

            //var musicResource = _mapper.Map<Music, MusicResource>(result.Entity);

            return Ok(result.Entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MusicModel>> UpdateMusic(int id, [FromBody] SaveMusicResource saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);
            var requestIsInvalid = id == 0 || !validationResult.IsValid;
            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var musicToBeUpdate = _mapper.Map<SaveMusicResource, UMSS.Music.Entity.Music>(saveMusicResource);

            var result = await _musicService.UpdateEntity(id, musicToBeUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            //var updatedMusicResource = _mapper.Map<Music, MusicResource>(result.Entity);

            return Ok(result.Entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var result = await _musicService.DeleteEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

    }
}