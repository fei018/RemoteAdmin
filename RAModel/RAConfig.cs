using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Common;
using System.Xml;

namespace RAModel
{
    public class RAConfig
    {
        public static readonly object Locker1 = new object();

        /// <summary>
        /// RAdmin.config file Path
        /// </summary>
        public string Path
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\RAdmin.config";
            }
        }

        public string ChannelPort
        {
            get
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    lock (RAConfig.Locker1)
                    {
                        xml.Load(this.Path);
                        XmlNodeList nodes = xml.GetElementsByTagName("channel");
                        string port = nodes[0].Attributes["port"].Value;
                        if (!RAMatch.IsChannelPort(port))
                        {
                            throw new ArgumentException("Invalid Channel Port.");
                        }
                        xml = null;
                        return port;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public string Password
        {
            get
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    lock (RAConfig.Locker1)
                    {
                        xml.Load(this.Path);
                        XmlNodeList nodes = xml.GetElementsByTagName("secure");
                        string p = nodes[0].Attributes["passwd"].Value;
                        xml = null;
                        return p;
                    }
                }
                catch (Exception ex)
                {
                    RALogger.Error(ex.Message);
                    return null;
                }
            }
            set
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    if (value != null)
                    {
                        lock (RAConfig.Locker1)
                        {
                            xml.Load(this.Path);
                            XmlNodeList nodes = xml.GetElementsByTagName("secure");
                            nodes[0].Attributes["passwd"].Value = value;
                            xml.Save(this.Path);
                            xml = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    xml = null;
                    RALogger.Error(ex.Message);                  
                }
            }
        }

        public string UpdateServer;

        public string HostsInfoServer;

        /// <summary>
        /// 構造函數
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="RAdmin.config not exists."></exception>
        public RAConfig()
        {
            if (!File.Exists(this.Path))
            {
                throw new ArgumentException("RAdmin.config not exists.");
            }
        }


    }
}
