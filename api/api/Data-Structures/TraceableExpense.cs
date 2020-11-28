using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Data_Structures
{
    public class TraceableExpense
    {
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int DateID { get; set; }
    }
}
