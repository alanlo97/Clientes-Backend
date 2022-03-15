using Microsoft.EntityFrameworkCore;
using PruebaBackend.Entities;

namespace PruebaBackend.DbContextData
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
