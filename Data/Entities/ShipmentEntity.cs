using System.ComponentModel.DataAnnotations;
namespace Data.Entities
{
    public class ShipmentEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public DateTime ShipmentDate { get; set; }
        public string Carrier { get; set; } = null!;  // T.ex. DHL, Shenker o postnord
        public string TrackingNumber { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
