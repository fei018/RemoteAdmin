using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Timers;
using System.IO;

namespace RAModel
{
    public class ClientHelper
    {
        private string Get_raServerFunc_url()
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

        private IRSFunctions _remoteServerFunctions;

        private void ActiveIRSFunctions()
        {
            try
            {
                _remoteServerFunctions = (IRSFunctions)Activator.GetObject(typeof(IRSFunctions), this.Get_raServerFunc_url());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UploadHostInfo()
        {
            try
            {
                HostInfo host = new HostInfo();
                host.LoadInfo();
                _remoteServerFunctions.UploadHostInfoToDB(host);
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
                this.UploadHostInfo();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Timer _timer;

        /// <summary>
        /// On schedule for upload HostInfo to server.
        /// </summary>
        /// <exception cref="throw"></exception>
        public void OnScheduleUploadInfo()
        {
            try
            {
                this.ActiveIRSFunctions();
                this._timer = new Timer(10000);
                this._timer.Elapsed += timer_Elapsed;
                this._timer.Start();
                this.UploadHostInfo();
            }
            catch (Exception)
            {
                this._timer.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Stop schedule of upload HostInfo to server.
        /// </summary>
        /// <exception cref="throw"></exception>
        public void StopScheduleUploadInfo()
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

        private static object lock1 = new object();

        public void Test(HostInfo info, string i)
        {
            try
            {
                this.ActiveIRSFunctions();
                info.LoadInfo();
                info.HostSerial = i;
                this._remoteServerFunctions.UploadHostInfoToDB(info);
                Console.WriteLine(i);
                lock (lock1)
                {
                    File.AppendAllText("d:\\log.txt", i + "\r\n");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}