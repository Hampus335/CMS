using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class SupplierEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProjectUpdateform> Projects { get; set; } = new List<ProjectUpdateform>();
    }
}
