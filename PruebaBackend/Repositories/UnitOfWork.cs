using PruebaBackend.DbContextData;
using PruebaBackend.Entities;
using PruebaBackend.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PruebaBackend.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;
        public UnitOfWork(Context dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IRepository<User> _userRepository;

        public IRepository<Cliente> ClienteRepository => _clienteRepository ?? new Repository<Cliente>(_dbContext);
        public IRepository<User> UserRepository => _userRepository ?? new Repository<User>(_dbContext);
        public void Dispose()
        {
            if(_dbContext != null)
                _dbContext.Dispose();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
