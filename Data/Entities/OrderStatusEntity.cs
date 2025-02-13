
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class OrderStatusEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime Date { get; set; }
    }

}
