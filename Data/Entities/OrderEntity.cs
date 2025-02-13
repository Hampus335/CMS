using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public SupplierEntity Supplier { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = null!;
    }   
}