namespace ClientApi.Models
{
    public class Charging
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int RequestsCount { get; set; }
        public DateTime ChargingMonth { get; set; }
        public virtual ChargingVariant ChargingVariant { get; set; }

        public Guid ChargingVariantId { get; set; }
        public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
