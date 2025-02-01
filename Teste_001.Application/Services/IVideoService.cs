using Teste_001.Application.ViewModels;

namespace Teste_001.Application.Services
{
    public interface IVideoService
    {
        Task<VideoViewModel?> GetByIdAsync(int id);
        Task<List<VideoViewModel>> GetAllAsync();
        Task AddAsync(VideoViewModel videoVm);
        Task UpdateAsync(VideoViewModel videoVm);
        Task DeleteAsync(int id);
    }

}
