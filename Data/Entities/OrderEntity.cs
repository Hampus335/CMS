using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public PaymentEntity Payment { get; set; } = null!;
        public int ShippingAddressId { get; set; }
        public ShippingAddressEntity ShippingAddress { get; set; } = null!;
    }
}
