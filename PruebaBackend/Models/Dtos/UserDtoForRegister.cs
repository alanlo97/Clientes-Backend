using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Models.Dtos
{
    public class UserDtoForRegister
    {
        [StringLength(maximumLength: 255, ErrorMessage = "The User Name Is Too Long")]
        public string UserName { get; set; }
        [StringLength(maximumLength: 320, ErrorMessage = "The Email Is Too Long")]
        public string Email { get; set; }
        [StringLength(maximumLength: 255, ErrorMessage = "The Password Is Too Long")]
        public string Password { get; set; }
    }
}
