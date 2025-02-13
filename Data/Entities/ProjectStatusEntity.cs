using System.ComponentModel.DataAnnotations;


namespace Data.Entities
{
    public class ProjectStatusEntity
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;  // "Ej påbörjad", "Pågående", "Avslutad"
    }

}
