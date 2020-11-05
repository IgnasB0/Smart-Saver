using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Smart_Saver
{
    class Income : IComparable<Income>
    {
        public decimal Amount { get; set; }
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if(value <= DateTime.Now)
                {
                    date = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Date is in the future");
                }
            }
        }
        public int CompareTo( Income other)
        {
            if (this.Date == other.Date)
            {
                return this.Amount.CompareTo(other.Amount);
            }

            return other.Date.CompareTo(this.Date);
        }

    }
}
