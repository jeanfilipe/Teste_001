using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_001.Application.Services
{
    public class YouTubeService : IYouTubeService
    {
        private readonly HttpClient _httpClient;
        private readonly IVideoService _videoService;

        public YouTubeService(HttpClient httpClient, IVideoService videoService)
        {
            _httpClient = httpClient;
            _videoService = videoService;
        }

        public async Task FetchAndSaveVideosAsync(string apiKey)
        {
            string url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=50&regionCode=BR&q=manipulação%20de%20medicamentos&type=video&publishedAfter=2022-01-01T00%3A00%3A00Z&publishedBefore=2022-12-31T23%3A59%3A59Z&key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                await _videoService.SaveVideosFromJsonAsync(jsonResponse);
            }
            else
            {
                throw new Exception($"Erro ao consumir API do YouTube: {response.ReasonPhrase}");
            }
        }
    }
}