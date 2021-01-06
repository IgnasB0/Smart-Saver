using System.ComponentModel.DataAnnotations;

namespace Smart_Saver_API.Models
{
    public class LoginDB
    {
        [Key]
        [MaxLength(100)]
        public string Username { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
