using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RAModel;
using Common;

namespace RemoteAdminApp
{
    public partial class RAdminForm : Form
    {
        public RAdminForm()
        {
            InitializeComponent();
            LoadHostInfo();
        }


        void LoadHostInfo()
        {
            HostInfo h = new HostInfo();
            h.LoadInfo();
            txtbHostInfo.Clear();
            txtbHostInfo.AppendText("Computer Name: " + "\t" + h.HostName + "\r\n");
            txtbHostInfo.AppendText("User Name: " + "\t" + h.UserName + "\r\n");
            txtbHostInfo.AppendText("Domain Name: " + "\t" + h.DomainName + "\r\n");
            txtbHostInfo.AppendText("OS Version: " + "\t" + h.OSVersion + "\r\n");
            txtbHostInfo.AppendText("IP Address: " + "\t" + h.IPAddress + "\r\n");
            txtbHostInfo.AppendText("Serial Number: " + "\t" + h.HostSerial);
        }

        RAChannel _channel;
        ClientHelper _localhost;
        void OnStart()
        {
            try
            {
                Logger.Path = AppDomain.CurrentDomain.BaseDirectory;
                RAConfig.Path = AppDomain.CurrentDomain.BaseDirectory + "\\RAdmin.cfg";
                RAConfig config = new RAConfig();
                _channel = new RAChannel();
                _channel.OpenListening(config.RAChannel_port);

                //_localhost = new LocalHost();
                //_localhost.OnScheduleUploadInfo();              
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                Console.WriteLine(ex.Message);
            }
        }



        void OnStop()
        {
            try
            {
                if (_channel != null)
                {
                    _channel.CloseListening();
                }

                if (_localhost != null)
                {
                    _localhost.StopScheduleUploadInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Test()
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    ClientHelper h = new ClientHelper();
                    HostInfo info = new HostInfo();
                    h.Test(info, i.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
