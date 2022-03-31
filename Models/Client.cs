namespace ClientApi.Models
{
    public class Client
    {
        public Guid ClientId { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Secret { get; set; }
        public int Discount { get; set; } = 0;
        public virtual ICollection<Charging> Chargings { get; set; }
        public virtual ICollection<ClientRequest> ClientRequests { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UserClient> UserClient { get; set; }
      

    }
}
