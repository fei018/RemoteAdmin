using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public delegate void RAEventForwardDelegate(object sender,string e);

    public class RAEventForwarder:MarshalByRefObject
    {
        public event RAEventForwardDelegate CmdEvent;

        public void CallCmdEvent(object sender, string e)
        {
            if (this.CmdEvent != null)
            {
                this.CmdEvent(sender, e);
            }
        }
    }
}
