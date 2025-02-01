using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_001.Infrastructure.Entities;

namespace Teste_001.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
