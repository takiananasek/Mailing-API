namespace ClientApi.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Activated { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }
        public virtual ICollection<UserClient> UserClient { get; set; }
    }
}
