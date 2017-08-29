using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Collections;
using Common;

namespace Model
{
    public class ClientChannel
    {
        private string _port;

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
                Logger.Log("Register Channel: " + _port + " port.");
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
                Logger.Log("Unregister Channel: " + _port + " port.");
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

        public void StartListen(string port)
        {
            if (port == null)
            {
                Logger.Error("Null Port.");
                return;
            }

            this._port = port;

            try
            {
                this.RegisterChannel();
                this.RegisterFunctions();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

            }
        }

        public void StopListen()
        {
            this.UnregisterChannel();
        }
    }
}
