
using System.ComponentModel.DataAnnotations;
namespace Data.Entities
{
    public class WishlistEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }

}
