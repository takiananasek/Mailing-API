namespace ClientApi.Models
{
    public class SmtpConfiguration
    {
        public SmtpServerConfiguration Primary { get; set; }
        public SmtpServerConfiguration Secondary { get; set; }
    }

    public class SmtpServerConfiguration
    {
        public string Name { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
    }
}
