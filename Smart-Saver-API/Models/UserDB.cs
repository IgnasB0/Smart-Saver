using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Models
{
    public class UserDB
    {
        [Key]
        public int userId { get; set; }

        [Required]
        [MaxLength(50)]
        public string userName { get; set; }

        [Required]
        [MaxLength(50)]
        public string userSurname { get; set; }

        [Required]
        public int userAge { get; set; }

    }
}
