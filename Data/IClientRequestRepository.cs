using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Data
{
    public interface IClientRequestRepository
    {
        public DbSet<ClientRequest> ClientRequests { get; set; }
        void Add(ClientRequest clientRequest);

        void SaveChanges();
        void Remove(ClientRequest clientRequest);
    }
}
