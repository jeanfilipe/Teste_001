using Microsoft.AspNetCore.Mvc;
using Teste_001.Application.Services;

namespace Teste_001.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouTubeController : ControllerBase
    {
        private readonly IYouTubeService _youTubeService;

        public YouTubeController(IYouTubeService youTubeService)
        {
            _youTubeService = youTubeService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportVideos()
        {
            try
            {
                await _youTubeService.FetchAndSaveVideosAsync();
                return Ok(new { message = "Vídeos importados com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}