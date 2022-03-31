using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Data
{
    public class ClientRequestRepository :IClientRequestRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DbSet<ClientRequest> ClientRequests { get; set; }
        public ClientRequestRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            ClientRequests = _dbContext.ClientRequests;
        }
        public void Add(ClientRequest clientRequest)
        {
            _dbContext.Add(clientRequest);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void Remove(ClientRequest clientRequest)
        {
            _dbContext.Remove(clientRequest);
        }
    }
}
