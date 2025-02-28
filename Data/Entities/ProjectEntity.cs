using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ProjectUpdateform
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Required]
        public int CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; }
        public string? Description { get; set; }
        public string? CustomerName { get; set; } = null!;
    }
}
