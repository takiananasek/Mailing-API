namespace ClientApi.Service
{
    public class EmailData
    {
        public string Message { get; set; }
        public string EmailAdress { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
    }
}