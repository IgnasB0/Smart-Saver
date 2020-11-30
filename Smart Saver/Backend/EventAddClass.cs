using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Saver.Backend
{
    public class EventAddClass
    {
        public void Add(decimal amount, DateTime date)
        {

            IncomeAddEventArgs args = new IncomeAddEventArgs();
            args.Amount = amount;
            args.Date = date;
            OnProgress(args);

        }
        protected virtual void OnProgress(IncomeAddEventArgs e)
        {
            EventHandler<IncomeAddEventArgs> handler = incomeReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<IncomeAddEventArgs> incomeReached;
    }
}
