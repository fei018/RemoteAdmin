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
        ClientHelper _hostHelper;
        void OnStart()
        {
            try
            {
                RAConfig.Path = AppDomain.CurrentDomain.BaseDirectory + "\\RAdmin.cfg"; ;
                RAConfig config = new RAConfig();               
                _channel = new RAChannel();
                _channel.OpenListening(config.RAChannel_port);

                //_hostHelper = new HostHelper();
                //_hostHelper.OnSchedule();
                Test();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                Console.WriteLine(ex.Message);
            }
        }


        void OnStop()
        {
            try
            {
                if (_channel != null)
                {
                    _channel.CloseListening();
                }

                if (_hostHelper != null)
                {
                    _hostHelper.StopScheduleUploadInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Test()
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    ClientHelper h = new ClientHelper();
                    HostInfo info = new HostInfo();
                    h.Test(info, i.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
