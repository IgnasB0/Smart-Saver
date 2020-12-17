using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Data
{
    public static class Password
    {
        public static string Pass() { return _pass; }
        private static readonly string _pass = "covid-19";
    }
}
