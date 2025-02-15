namespace Business.Models
{
    public class CustomerDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<Project> Projects { get; set; } = [];
    }
}
