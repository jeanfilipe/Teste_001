using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_001.Application.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
