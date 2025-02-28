using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<ProjectUpdateform> Projects { get; set; } = [];
    }
}
