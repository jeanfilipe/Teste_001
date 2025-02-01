using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                CreationDate = video.CreationDate
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
                CreationDate = videoVm.CreationDate
            };
        }
    }

}
