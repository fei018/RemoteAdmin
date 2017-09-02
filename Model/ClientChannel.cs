using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Collections;
using Common;
using System.Xml;

namespace Model
{
    public class ClientChannel
    {
        private string _port;

        private string _configPath;

        private void RegisterChannel()
        {
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            IDictionary prop = new Hashtable();
            prop["name"] = "AdminClientChannel" + _port;
            prop["port"] = _port;
            try
            {
                TcpChannel channel = new TcpChannel(prop, clientProvider, serverProvider);
                ChannelServices.RegisterChannel(channel, false);
                RALogger.Log("Register Channel: " + _port + " port.");
            }
            catch (Exception) 
            {
                throw;
            }
        }

        private void UnregisterChannel()
        {
            TcpChannel channel = (TcpChannel)ChannelServices.GetChannel("AdminClientChannel" + _port);
            if (channel != null)
            {
                ChannelServices.UnregisterChannel(channel);
                RALogger.Log("Unregister Channel: " + _port + " port.");
            }
        }

        private void RegisterFunctions()
        {
            try
            {
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(Functions), "Client.Functions", WellKnownObjectMode.SingleCall);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetPort()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(this._configPath);
                XmlNodeList nodes = xml.GetElementsByTagName("port");
                string p = nodes[0].Attributes[0].Value;
                if (!RASecurity.IsChannelPort(p))
                {
                    throw new ArgumentException("Invalid Channel Port.");
                }
                this._port = p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OpenListening(string configPath)
        {       
            try
            {
                if (configPath == null)
                {
                    RALogger.Error("Null ConfigFile Path.");
                    return;
                }
                this._configPath = configPath;
                this.SetPort();
                this.RegisterChannel();
                this.RegisterFunctions();
            }
            catch (Exception ex)
            {
                RALogger.Error(ex.Message);
            }
        }

        public void CloseListening()
        {
            this.UnregisterChannel();
        }
    }
}
