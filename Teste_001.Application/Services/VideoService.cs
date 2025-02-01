using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Logging;
using System.Text.Json;
using Teste_001.Application.ViewModels;
using Teste_001.Domain.Repositories;
using Teste_001.Infrastructure.Entities;

namespace Teste_001.Application.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<VideoViewModel?> GetByIdAsync(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            return video != null ? MapToViewModel(video) : null;
        }

        public async Task<List<VideoViewModel>> GetAllAsync()
        {
            var videos = await _videoRepository.GetAllAsync();
            return videos.Select(MapToViewModel).ToList();
        }

        public async Task AddAsync(VideoViewModel videoVm)
        {
            var video = MapToEntity(videoVm);
            await _videoRepository.AddAsync(video);
        }

        public async Task UpdateAsync(VideoViewModel videoVm)
        {
            var video = await _videoRepository.GetByIdAsync(videoVm.Id);
            if (video == null)
                throw new KeyNotFoundException("Vídeo não encontrado.");

            video.Title = videoVm.Title;
            video.Author = videoVm.Author;
            video.VideoId = videoVm.VideoId;
            video.Duration = videoVm.Duration;
            video.CreationDate = videoVm.CreationDate;
            video.IsActive = videoVm.IsActive;
            video.Description = video.Description;

            await _videoRepository.UpdateAsync(video);
        }

        public async Task DeleteAsync(int id)
        {
            await _videoRepository.DeleteAsync(id);
        }

        private static VideoViewModel MapToViewModel(Video video)
        {
            return new VideoViewModel
            {
                Id = video.Id,
                VideoId = video.VideoId,
                Title = video.Title,
                Author = video.Author,
                IsActive = video.IsActive,
                Duration = video.Duration,
                CreationDate = video.CreationDate,
                Description = video.Description
            };
        }

        private static Video MapToEntity(VideoViewModel videoVm)
        {
            return new Video
            {
                Id = videoVm.Id,
                VideoId = videoVm.VideoId,
                Title = videoVm.Title,
                Author = videoVm.Author,
                IsActive = videoVm.IsActive,
                Duration = videoVm.Duration,
                CreationDate = videoVm.CreationDate,
                Description = videoVm.Description

            };
        }

        public async Task SaveVideosFromJsonAsync(string jsonResponse)
        {
            var youtubeResponse = JsonSerializer.Deserialize<YouTubeApiResponse>(jsonResponse);

            if (youtubeResponse?.items != null)
            {
                var videos = youtubeResponse.items.Select(item => new Video
                {
                    VideoId = item.id.videoId,
                    Title = item.snippet.title,
                    Author = item.snippet.channelTitle,
                    CreationDate = item.snippet.publishedAt,
                    Duration = TimeSpan.Parse("0"),
                    IsActive = true,
                    Description = item.snippet.description

                }).ToList();

                int id = 1;
                foreach (var item in videos)
                {
                    item.Id = id;
                    await _videoRepository.AddAsync(item);

                    id++;
                }
            }
        }

        public async Task<List<Video>> SearchVideosAsync(string? title, TimeSpan? maxDuration, string? author, DateTime? after, string? q)
        {
            return await _videoRepository.SearchVideosAsync(title, maxDuration, author, after, q);
        }
    }
}