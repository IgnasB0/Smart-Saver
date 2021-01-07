using System;
using System.Collections.Generic;
using System.Text;

namespace Sql
{
    public static class Password
    {
        public static string Pass() { return _pass; }
        private static readonly string _pass = "covid-19";
    }
}
