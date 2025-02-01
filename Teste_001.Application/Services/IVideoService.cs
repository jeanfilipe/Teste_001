using Teste_001.Application.ViewModels;
using Teste_001.Infrastructure.Entities;

namespace Teste_001.Application.Services
{
    public interface IVideoService
    {
        Task<VideoViewModel?> GetByIdAsync(int id);
        Task<List<VideoViewModel>> GetAllAsync();
        Task AddAsync(VideoViewModel videoVm);
        Task UpdateAsync(VideoViewModel videoVm);
        Task DeleteAsync(int id);
        Task SaveVideosFromJsonAsync(string jsonResponse);
        Task<List<Video>> SearchVideosAsync(string? title, TimeSpan? maxDuration, string? author, DateTime? after, string? q);
    }

}
