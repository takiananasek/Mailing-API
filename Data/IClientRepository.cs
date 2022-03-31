using ClientApi.DTO;
using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Data
{
    public interface IClientRepository
    {
        public DbSet<Client> Clients { get; set; }
        void Add(Client client);

        void SaveChanges();
        void Remove(Client client);

        bool isDuplicate(RegisterClientRequestDTO registerRequest);
    }
}
