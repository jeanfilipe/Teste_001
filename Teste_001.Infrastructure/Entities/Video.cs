using Teste_001.Shared.Abstractions;

namespace Teste_001.Infrastructure.Entities
{
    public class Video : BaseEntity
    {
        public string VideoId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public string Author { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
