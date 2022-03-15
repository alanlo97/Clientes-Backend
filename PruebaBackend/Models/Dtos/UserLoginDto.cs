using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Models.Dtos
{
    public class UserLoginDto
    {
        [StringLength(maximumLength: 320, ErrorMessage = "The Email Is Too Long")]
        public string Email { get; set; }
        [StringLength(maximumLength: 255, ErrorMessage = "The Password Is Too Long")]
        public string Password { get; set; }
    }
}
