using System.ComponentModel.DataAnnotations;

namespace Business.Models.Customer
{
    internal class CustomerRegistration
    {
        [Required]
        public string CustomerName { get; set; } = null!;
    }
}
