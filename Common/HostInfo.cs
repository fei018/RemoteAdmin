using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;

namespace Common
{
    [Serializable]
    public class HostInfo
    {
        public string HostName { get; set; }

        public string IPAddress { get; set; }

        public string OSVersion { get; set; }

        public string DomainName { get; set; }

        public string UserName { get; set; }

        public string HostSerial { get; set; }

        public string SendTime { get; set; }

        /// <summary>
        /// Get IP Address v4
        /// </summary>
        /// <returns></returns>
        /// <exception cref="throw"></exception>
        private string GetIPAddress()
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
                string ip = entry.AddressList.FirstOrDefault<IPAddress>(a =>
                {
                    return a.AddressFamily.ToString().Equals("InterNetwork");
                }).ToString();
                return ip;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoadInfo()
        {
            try
            {
                this.IPAddress = GetIPAddress();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                this.IPAddress = string.Empty;
            }

            this.UserName = Environment.UserName;

            ManagementClass OS = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject obj in OS.GetInstances())
            {
                this.OSVersion = obj.Properties["Caption"].Value.ToString();
                this.HostName = obj.Properties["CSName"].Value.ToString();
            }
            OS.Dispose();

            ManagementClass CS = new ManagementClass("Win32_ComputerSystem");
            foreach (ManagementObject obj in CS.GetInstances())
            {
                this.DomainName = obj.Properties["Domain"].Value.ToString();
            }
            CS.Dispose();

            ManagementClass Bios = new ManagementClass("Win32_Bios");
            foreach (ManagementObject obj in Bios.GetInstances())
            {
                this.HostSerial = obj.Properties["SerialNumber"].Value.ToString();
            }
            Bios.Dispose();

            this.SendTime = DateTime.Now.ToString();
        }
    }
}
