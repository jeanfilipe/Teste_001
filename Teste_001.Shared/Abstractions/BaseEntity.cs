using System.ComponentModel.DataAnnotations;

namespace Teste_001.Shared.Abstractions
{
    public abstract class BaseEntity : IEntityKey<int>
    {
        [Key]
        public int Id { get; set; }
    }
}
