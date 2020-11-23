using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Saver_API.Data_Structures
{
    public class TraceableIncome
    {
            public decimal Amount { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int DateID { get; set; }
    }
}
