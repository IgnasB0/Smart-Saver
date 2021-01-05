using System;
using System.Collections.Generic;
using System.Text;

namespace MonthCheckExtensions.Backend
{
    public static class MyExtensions
    {
        public static bool CheckIfCurrentMonth(this DateTime dateTocheck)
        {
            int monthNow = DateTime.Now.Month;
            int monthToCheck = dateTocheck.Month;

            return monthNow == monthToCheck;
        }        
    }
}
