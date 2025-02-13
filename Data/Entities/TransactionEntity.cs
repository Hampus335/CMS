using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = null!;  // Exempelvis "Payment", "Refund"
        public DateTime Date { get; set; }
    }
}
