using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Data
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _dbcontext;
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public UserRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            Users = _dbcontext.Users;
            Clients = _dbcontext.Clients;
        }
        public void Add(User user)
        {
            _dbcontext.Add(user);
        }

        public void Remove(User user)
        {
            _dbcontext.Remove(user);
        }

        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }
    }
}
