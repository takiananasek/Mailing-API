using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Data
{
    public interface IUserRepository
    {
        void Add(User user);
        void SaveChanges();
        void Remove(User user);
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
