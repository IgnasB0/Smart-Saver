﻿using System;
using System.IO;

namespace Smart_Saver.Backend
{
    class Logger
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private Logger() { }
        private static Logger _instance = null; //Singleton pattern

        public static Logger Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Logger methods and variables
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        public void Log<T>(T errorMessageOrCode) //Generic method
        {
            logFileWriter.WriteLine(DateTime.Now.ToString() + "|:   " + errorMessageOrCode);
            logFileWriter.Flush();
        }

        private readonly StreamWriter logFileWriter = new StreamWriter("..\\..\\..\\log.txt");
    }
}
