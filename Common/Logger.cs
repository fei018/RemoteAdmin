using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Logger
    {
        static object Locker1 = new object();

        public static string Path { get; set; }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="log"></param>
        /// <exception cref="Log File Path not exists."></exception>
        public static void Log(string log)
        {

        }

        /// <summary>
        /// Error Log
        /// </summary>
        /// <param name="error"></param>
        /// <exception cref="Log File Path not exists."></exception>
        public static void Error(string error)
        {

        }
    }
}
