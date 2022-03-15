using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Entities
{
    public class User : EntityBase
    {
        [Required(ErrorMessage = "The User Name Is Required")]
        [StringLength(maximumLength: 255, ErrorMessage = "The User Name Is Too Long")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Email Is Required")]
        [StringLength(maximumLength: 320, ErrorMessage = "The Email Is Too Long")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        [StringLength(maximumLength: 255, ErrorMessage = "The Password Is Too Long")]
        public string Password { get; set; }
    }
}
