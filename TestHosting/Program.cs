using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace TestHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientChannel client = new ClientChannel();
            client.StartListen("9123");
            Console.WriteLine("start...");

            Console.ReadLine();
            client.StopListen();
        }
    }
}
