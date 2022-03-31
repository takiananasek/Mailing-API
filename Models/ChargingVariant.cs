namespace ClientApi.Models
{
    public class ChargingVariant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int MinRequestsCount { get; set; }
        public int MaxRequestsCount { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public double Value { get; set; }
        public virtual ICollection<Charging> Chargings { get; set; }
    }
}
