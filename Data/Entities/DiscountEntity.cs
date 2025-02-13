using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class DiscountEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public bool IsPercentage { get; set; }
    }
}
