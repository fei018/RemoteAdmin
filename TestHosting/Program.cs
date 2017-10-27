using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAModel;
using Common;

namespace TestHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            p.OnStart();

            Console.WriteLine("start...");
            Console.ReadLine();

            p.OnStop();
        }

        RAChannel _channel;
        void OnStart()
        {
            try
            {
                RAConfig config = new RAConfig();
                _channel = new RAChannel();
                _channel.OpenListening(config.ChannelPort);
            }
            catch (Exception ex)
            {
                RALogger.Error(ex.Message);
                _channel.CloseListening();
                Console.WriteLine(ex.Message);
            }
        }


        void OnStop()
        {
            _channel.CloseListening();
        }
    }
}
