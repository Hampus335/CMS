using System.ComponentModel.DataAnnotations;

namespace Business.Factories
{
    public class ProjectUpdateForm
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}