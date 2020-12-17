using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Models
{
    public class ReccuringIncomeDB
    {
        [Key]
        public int reccuringincomeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal reccuringincomeAmount { get; set; }

        [Required]
        public DateTime reccuringincomeDateFrom { get; set; }

        [Required]
        public DateTime reccuringincomeDateUntil { get; set; }

        [Required]
        public int userId { get; set; }

    }
}
