using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Entities
{
    public class EntityBase
    {
        [Required]
        public bool IsDeleted { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
