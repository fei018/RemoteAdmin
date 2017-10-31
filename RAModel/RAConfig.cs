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
        /// <summary>
        /// 構造函數
        /// </summary>
        /// <exception cref="RAdmin.cfg not exists."></exception>
        public RAConfig()
        {
            if (!File.Exists(RAConfig.Path))
            {
                throw new ArgumentException("RAdmin.cfg not exists.");
            }
        }

        private static readonly object _Locker1 = new object();

        /// <summary>
        /// RAdmin.cfg file Path
        /// </summary>
        public static string Path { get; set; }

        /// <summary>
        /// RAdmin Channel Port.
        /// </summary>
        /// <exception cref="Invalid raChannel Port."></exception>
        public string RAChannel_port { get { return GetRAChannel_port(); } }
        private string GetRAChannel_port()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                lock (RAConfig._Locker1)
                {
                    xml.Load(RAConfig.Path);
                    XmlNodeList nodes = xml.GetElementsByTagName("raChannel");
                    string port = nodes[0].Attributes["port"].Value;
                    if (!RAMatch.IsChannelPort(port))
                    {
                        throw new ArgumentException("Invalid raChannel Port.");
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

        public string Secure_passwd
        {
            get { return GetSecure_passwd(); }
            set { SetSecure_passwd(value); }
        }
        string GetSecure_passwd()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                lock (RAConfig._Locker1)
                {
                    xml.Load(RAConfig.Path);
                    XmlNodeList nodes = xml.GetElementsByTagName("secure");
                    string p = nodes[0].Attributes["passwd"].Value;
                    xml = null;
                    return p;
                }
            }
            catch (Exception ex)
            {
                xml = null;
                RALogger.Error(ex.Message);
                return null;
            }
        }
        void SetSecure_passwd(string passwd)
        {
            XmlDocument xml = new XmlDocument();
                try
                {
                    if (passwd != null)
                    {
                        lock (RAConfig._Locker1)
                        {
                            xml.Load(RAConfig.Path);
                            XmlNodeList nodes = xml.GetElementsByTagName("secure");
                            nodes[0].Attributes["passwd"].Value = passwd;
                            xml.Save(RAConfig.Path);
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

        /// <summary>
        /// RAdmin Server IP
        /// </summary>
        /// <exception cref="Invalid RAServer IP."></exception>
        public string RAServer_ip { get { return GetRAServer_ip(); } }
        string GetRAServer_ip()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                lock (RAConfig._Locker1)
                {
                    xml.Load(RAConfig.Path);
                    XmlNodeList nodes = xml.GetElementsByTagName("raServer");
                    string ip = nodes[0].Attributes["ip"].Value;
                    if (!RAMatch.IsIPAddress(ip))
                    {
                        throw new ArgumentException("Invalid RAServer IP.");
                    }
                    xml = null;
                    return ip;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// RAdmin Server Channel Port
        /// </summary>
        /// <exception cref="Invalid RAServer Port."></exception>
        public string RAServer_port { get { return GetRAServer_port(); } }
        string GetRAServer_port()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                lock (RAConfig._Locker1)
                {
                    xml.Load(RAConfig.Path);
                    XmlNodeList nodes = xml.GetElementsByTagName("raServer");
                    string port = nodes[0].Attributes["port"].Value;
                    if (!RAMatch.IsChannelPort(port))
                    {
                        throw new ArgumentException("Invalid RAServer Port.");
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

        public string UpdateServer_ip { get { return GetUpdateServer_ip(); } }
        string GetUpdateServer_ip()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                lock (RAConfig._Locker1)
                {
                    xml.Load(RAConfig.Path);
                    XmlNodeList nodes = xml.GetElementsByTagName("updateServer");
                    string ip = nodes[0].Attributes["ip"].Value;
                    if (!RAMatch.IsIPAddress(ip))
                    {
                        throw new ArgumentException("Invalid UPdateServer ip.");
                    }
                    xml = null;
                    return ip;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
