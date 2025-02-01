using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_001.Application.Services;
using Teste_001.Application.ViewModels;

namespace Teste_001.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var video = await _videoService.GetByIdAsync(id);
            if (video == null)
                return NotFound(new { message = "Vídeo não encontrado." });

            return Ok(video);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var videos = await _videoService.GetAllAsync();
            return Ok(videos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VideoViewModel videoVm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _videoService.AddAsync(videoVm);
            return CreatedAtAction(nameof(GetById), new { id = videoVm.Id }, videoVm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VideoViewModel videoVm)
        {
            if (id != videoVm.Id)
                return BadRequest("ID inconsistente.");

            try
            {
                await _videoService.UpdateAsync(videoVm);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _videoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
