using Data.Entities;

namespace Business.Models

{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Customer Customer { get; set; } = null!;
    }

    public class ProjectRegistrationForm
    {
        public string ProjectName { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int CustomerId { get; set; }
    }
}
