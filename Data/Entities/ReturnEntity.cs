using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ReturnEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Reason { get; set; } = null!;
    }

}
