using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Saver.Backend
{
    public class Result
    {
        public string monthAndYear { get; set; }
        public string Type { get; set; }
        public decimal amount { get; set; }


        private string[] val = new string[3];

        public string this[int index]                      //indexed property
        {
            get
            {
                return val[index];
            }
            set
            {
                val[index] = value;
            }
        }
    }
}
