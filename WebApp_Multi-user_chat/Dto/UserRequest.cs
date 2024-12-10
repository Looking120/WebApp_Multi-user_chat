using System.ComponentModel.DataAnnotations;

namespace WebApp_Multi_user_chat.Dto
{
    public class UserRequest
    {
       
        public string? Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(17, MinimumLength = 3, ErrorMessage = "The username must be between 3 and 17 characters long.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(17, MinimumLength = 3, ErrorMessage = "The password must be between 3 and 17 characters long.")]
        public string Password { get; set; }
    }
}
