namespace Business.Models
{
    public class Customer
    {
        public string CustomerName { get; set; } = null!;
        public string Emai { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<Project> Projects { get; set; } = [];
    }
}
