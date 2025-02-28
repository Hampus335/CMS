using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class CustomerRegistration
    {
        [Required]
        public string CustomerName { get; set; } = null!;
    }   
}
