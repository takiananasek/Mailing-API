using ClientApi.Models.NonPersistentModels;

namespace ClientApi.Models
{
    public class ClientRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OperationId { get; set; } = Guid.NewGuid();
        public EventType EventType { get; set; }
        public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
