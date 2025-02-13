using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class PaymentHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public PaymentEntity Payment { get; set; } = null!;
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = null!;
    }

}
