using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RAdminViewer
{
    public partial class ViewerForm : Form
    {
        public ViewerForm()
        {
            InitializeComponent();

            OpenChannel();
        }

        #region ViewerChannel
        private ViewerChannel _channel;

        private void OpenChannel()
        {
            _channel = new ViewerChannel();
            _channel.StartListen("9124");
        }

        private void CloseChannel()
        {
            if (_channel != null)
            {
                _channel.StopListen();
            }
        }
        #endregion
    }
}
