using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ShippingAddressEntity
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
    }
}
