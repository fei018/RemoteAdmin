using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Common;
using System.IO;

namespace ServerModel
{
    public class ServerConfig
    {
        /// <summary>
        /// 構造函數
        /// </summary>
        /// <exception cref="Server.cfg not exists."></exception>
        public ServerConfig()
        {
            if (!File.Exists(ServerConfig.Path))
            {
                throw new ArgumentException("Server.cfg not exists.");
            }
        }

        private static readonly object _Locker1 = new object();

        /// <summary>
        /// Server.cfg file Path
        /// </summary>
        public static string Path
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "\\Server.cfg"; }
        }

        public string ChannelPort
        {
            get
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    lock (ServerConfig._Locker1)
                    {
                        xml.Load(ServerConfig.Path);
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

        public static string DBConnectString;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="throw"></exception>
        public void SetDBConnectString()
        {
            XmlDocument xml = new XmlDocument();
            try
            {               
                lock (ServerConfig._Locker1)
                {
                    xml.Load(ServerConfig.Path);
                    XmlNodeList nodes = xml.GetElementsByTagName("mysql");
                    ServerConfig.DBConnectString = nodes[0].Attributes["connectionString"].Value;
                    xml = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }       
    }
}
