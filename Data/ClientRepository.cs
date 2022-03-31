using ClientApi.DTO;
using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DbSet<Client> Clients { get; set; }
        public ClientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Clients = _dbContext.Clients;
        }

        public void Add(Client client)
        {
            _dbContext.Add(client);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void Remove(Client client)
        {
            _dbContext.Remove(client);
        }

        public bool isDuplicate(RegisterClientRequestDTO registerRequest)
        {
                var result = _dbContext.Clients.Where(c => c.Email == registerRequest.Email).Any();
                return result;      
        }
    }
}
