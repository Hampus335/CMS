using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Required]
        public int CustomerId { get; set; }
        public EmployeeEntity ResponsibleEmployee { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
        public string? Description { get; set; }
    }
}
