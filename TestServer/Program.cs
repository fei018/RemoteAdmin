using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerModel;
using Common;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            p.OnStart();
            Console.WriteLine("Start...");
            Console.ReadLine();

            p.OnStop();
        }

        ServerChannel _channel;
        void OnStart()
        {
            try
            {
                ServerConfig.Path = AppDomain.CurrentDomain.BaseDirectory + "\\Server.cfg";
                ServerConfig config = new ServerConfig();
                ServerConfig.DBConnectionString = config.GetDBConnectionString();

                _channel = new ServerChannel();
                _channel.OpenListening(config.ChannelPort);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        void OnStop()
        {
            if (_channel != null)
            {
                _channel.CloseListening();
            }
        }
    }
}
