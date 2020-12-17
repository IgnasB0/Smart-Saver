using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Models
{
    public class CategoriesDB
    {
        [Key]
        public int categoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string categoryName { get; set; }
    }
}
