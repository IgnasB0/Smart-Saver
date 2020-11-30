using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Saver.Backend
{
    public class IncomeAddEventArgs : EventArgs
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
