using System.ComponentModel.DataAnnotations;

namespace School_api.Register
{
    public class register
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
