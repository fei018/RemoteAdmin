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
            Program p = new Program();

            p.OnStart();

            Console.WriteLine("start...");
            Console.ReadLine();

            p.OnStop();
        }

        AppChannel _channel;
        void OnStart()
        {
            try
            {
                AppConfig config = new AppConfig();
                _channel = new AppChannel();
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
