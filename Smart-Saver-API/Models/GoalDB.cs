using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Models
{
    public class GoalDB
    {
        [Key]
        public int goalId { get; set; }

        [Required]
        [MaxLength(50)]
        public string goalName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal goalAmount { get; set; }

        [Required]
        public DateTime goalDate { get; set; }

        [Required]
        public int userId { get; set; }
    }
}
