﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using Common;
using System.Windows.Forms;

namespace RAdminViewer
{
    public class ViewerChannel
    {
        private string _port;

        private void RegisterChannel()
        {
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            IDictionary prop = new Hashtable();
            prop["name"] = "ViewerChannel" + _port;
            prop["port"] = _port;
            try
            {
                TcpChannel channel = new TcpChannel(prop, clientProvider, serverProvider);
                ChannelServices.RegisterChannel(channel, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UnregisterChannel()
        {
            TcpChannel channel = (TcpChannel)ChannelServices.GetChannel("ViewerChannel" + _port);
            if (channel != null)
            {
                ChannelServices.UnregisterChannel(channel);
            }
        }

        public void OpenListening(string port)
        {
            if (port == null)
            {
                MessageBox.Show("Null port");
                return;
            }

            this._port = port;

            try
            {
                this.RegisterChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CloseListening()
        {
            this.UnregisterChannel();
        }
    }
}
