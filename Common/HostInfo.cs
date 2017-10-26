using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;

namespace Common
{
    public class HostInfo:MarshalByRefObject
    {
        public string HostName { get; set; }

        public string IPAddress { get; set; }

        public string OSVersion { get; set; }

        public string DomainName { get; set; }

        public string UserName { get; set; }

        public string SerialNumber { get; set; }

        public string SendTime { get; set; }

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
                RALogger.Error(ex.Message);
                this.IPAddress = string.Empty;
            }

            this.UserName = Environment.UserName;

            ManagementClass OS = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject obj in OS.GetInstances())
            {
                this.OSVersion = obj.Properties["Caption"].Value.ToString();
                this.HostName = obj.Properties["CSName"].Value.ToString();
            }

            ManagementClass CS = new ManagementClass("Win32_ComputerSystem");
            foreach (ManagementObject obj in CS.GetInstances())
            {
                this.DomainName = obj.Properties["Domain"].Value.ToString();
            }

            ManagementClass Bios = new ManagementClass("Win32_Bios");
            foreach (ManagementObject obj in Bios.GetInstances())
            {
                this.SerialNumber = obj.Properties["SerialNumber"].Value.ToString();
            }

            this.SendTime = DateTime.Now.ToString();
        }
    }
}
