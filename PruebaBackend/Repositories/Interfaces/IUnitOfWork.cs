using PruebaBackend.Entities;
using System.Threading.Tasks;

namespace PruebaBackend.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Cliente> ClienteRepository { get; }
        IRepository<User> UserRepository { get; }
        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
