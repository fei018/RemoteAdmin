using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerModel;
using Common;

namespace TestServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Program p = new Program();

            p.OnStart();
            Console.WriteLine("Start...");
            Console.ReadLine();

            p.OnStop();
        }

        private ServerChannel _channel;

        private void OnStart()
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

        private void OnStop()
        {
            if (_channel != null)
            {
                _channel.CloseListening();
            }
        }
    }
}