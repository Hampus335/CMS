using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class PaymentEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethodEntity PaymentMethod { get; set; } = null!;
    }
}