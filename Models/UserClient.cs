﻿namespace ClientApi.Models
{
    public class UserClient
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
