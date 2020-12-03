using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Saver.Backend
{
    interface iIncome
    {
        List<RecurringIncome.Income> ParseIncomes();
    }
}
