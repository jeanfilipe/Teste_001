using Microsoft.EntityFrameworkCore;
using Teste_001.Infrastructure.Data.Context;
using Teste_001.Infrastructure.Entities;

namespace Teste_001.Domain.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Video?> GetByIdAsync(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task<List<Video>> GetAllAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task AddAsync(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Video video)
        {
            _context.Videos.Update(video);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            video.IsActive = false;

            await _context.SaveChangesAsync();
        }

        public async Task AddVideosAsync(List<Video> videos)
        {
            await _context.Videos.AddRangeAsync(videos);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Video>> SearchVideosAsync(string? title, TimeSpan? maxDuration, string? author, DateTime? after, string? q)
        {
            var query = _context.Videos.AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(v => v.Title.Contains(title));

            if (maxDuration.HasValue)
                query = query.Where(v => v.Duration <= maxDuration.Value);

            if (!string.IsNullOrEmpty(author))
                query = query.Where(v => v.Author.Contains(author));

            if (after.HasValue)
                query = query.Where(v => v.CreationDate >= after.Value);

            if (!string.IsNullOrEmpty(q))
                query = query.Where(v => v.Title.Contains(q) || v.Description.Contains(q));

            return await query.ToListAsync();
        }
    }
}