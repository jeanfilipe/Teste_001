using Teste_001.Infrastructure.Entities;

namespace Teste_001.Domain.Repositories
{
    public interface IVideoRepository
    {
        Task<Video?> GetByIdAsync(int id);
        Task<List<Video>> GetAllAsync();
        Task AddAsync(Video video);
        Task UpdateAsync(Video video);
        Task DeleteAsync(int id);
        Task AddVideosAsync(List<Video> videos);
        Task<List<Video>> SearchVideosAsync(string? title, TimeSpan? maxDuration, string? author, DateTime? after, string? q);
    }
}