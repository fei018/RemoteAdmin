using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Timers;
using System.IO;

namespace RAModel
{
    public class HostHelper
    {
        private string _raServerFunc_url
        {
            get
            {
                try
                {
                    RAConfig config = new RAConfig();
                    return string.Format(@"Tcp://{0}:{1}/RServerFunctions", config.RAServer_ip, config.RAServer_port);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private IRSFunctions _IRServerFuncObject;
        private void ActiveIRSFunctions()
        {
            try
            {
                _IRServerFuncObject = (IRSFunctions)Activator.GetObject(typeof(IRSFunctions), this._raServerFunc_url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdateHostInfo()
        {
            try
            {
                HostInfo host = new HostInfo();
                host.LoadInfo();
                _IRServerFuncObject.UpdateHostInfoToDB(host);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.UpdateHostInfo();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Timer _timer;
        /// <summary>
        /// On schedule for Update HostInfo to server.
        /// </summary>
        /// <exception cref="throw"></exception>       
        public void OnSchedule()
        {
            try
            {
                this.ActiveIRSFunctions();
                this._timer = new Timer(10000);
                this._timer.Elapsed += timer_Elapsed;
                this._timer.Start();
                this.UpdateHostInfo();
            }
            catch (Exception)
            {
                this._timer.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Stop schedule of Update HostInfo to server.
        /// </summary>
        /// <exception cref="throw"></exception>
        public void StopSchedule()
        {
            try
            {
                if (this._timer != null)
                {
                    this._timer.Stop();
                    this._timer.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static object lock1 = new object();
        public void Test(HostInfo info, string i)
        {
            try
            {
                this.ActiveIRSFunctions();
                info.LoadInfo();
                info.HostSerial = i;
                this._IRServerFuncObject.UpdateHostInfoToDB(info);
                Console.WriteLine(i);
                lock (lock1)
                {
                    File.AppendAllText("d:\\log.txt", i+"\r\n");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
