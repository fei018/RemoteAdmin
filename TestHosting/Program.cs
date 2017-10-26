using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppModel;
using Common;

namespace TestHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            string config = AppDomain.CurrentDomain.BaseDirectory + "\\app.config";
            RAConfigFile path = new RAConfigFile(config);
            ClientChannel client = new ClientChannel();
            client.OpenListening(path.Path);
            Console.WriteLine("start...");
            
            Console.ReadLine();
            client.CloseListening();
        }
    }
}
