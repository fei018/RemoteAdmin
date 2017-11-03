using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Collections;
using Common;

namespace ServerModel
{
    public class ServerChannel
    {
        private string _port;
        private string _portName;
        /// <summary>
        /// 註冊 信道
        /// </summary>
        /// <exception cref="throw"></exception>
        private void RegisterChannel()
        {
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            IDictionary prop = new Hashtable();
            prop["name"] = _portName;
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

        /// <summary>
        /// 註銷 信道
        /// </summary>
        private void UnregisterChannel()
        {
            TcpChannel channel = (TcpChannel)ChannelServices.GetChannel(_portName);
            if (channel != null)
            {
                ChannelServices.UnregisterChannel(channel);
                Logger.Log("Unregister Channel: " + _port + " port.");
            }
        }

        /// <summary>
        /// SingleCall 方式註冊遠程對象 'AppFunctions'
        /// </summary>
        /// <exception cref="throw"></exception>
        private void RegisterFunctions()
        {
            try
            {
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RSFunctions), "RServerFunctions", WellKnownObjectMode.SingleCall);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Channel service
        /// <summary>
        /// 開始偵聽信道服務
        /// </summary>
        /// <param name="port"></param>
        /// <exception cref="throw"></exception>
        public void OpenListening(string port)
        {
            try
            {
                this._port = port;
                this._portName = "RAServerChannel" + _port;
                this.RegisterChannel();
                this.RegisterFunctions();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 停止信道服務
        /// </summary>
        public void CloseListening()
        {
            this.UnregisterChannel();
        }
        #endregion
    }
}
