namespace Teste_001.Shared.Abstractions
{
    public abstract class BaseEntity : IEntityKey<int>
    {
        public int Id { get; set; }
    }
}
