using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Models
{
    public class ExpenseDB
    {
        [Key]
        public int expenseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string expenseName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal expenseAmount { get; set; }

        [Required]
        public DateTime expenseDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string expenseCategory { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int categoryId { get; set; }

    }
}
