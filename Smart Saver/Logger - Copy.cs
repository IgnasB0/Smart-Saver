﻿using System;
using System.IO;

namespace Smart_Saver
{
    static class Logger
    {
        public static void Log(string message)
        {
            logFileWriter.WriteLine(DateTime.Now.ToString() +"|:   " + message);
            logFileWriter.Flush();
        }

        private static readonly StreamWriter logFileWriter = new StreamWriter("..\\..\\..\\log.txt");
    }
}
