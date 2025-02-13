using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        [Required]
        public int CustomerId { get; set; }
        public EmployeeEntity ResponsibleEmployee { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
    }
}
