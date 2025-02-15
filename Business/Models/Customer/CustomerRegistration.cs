using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    internal class CustomerRegistration
    {
        [Required]
        public string CustomerName { get; set; } = null!;
    }
}
