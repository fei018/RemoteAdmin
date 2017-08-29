using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public delegate void EventForwardDelegate(object sender,string e);

    public class EventForwarder:MarshalByRefObject
    {
        public event EventForwardDelegate CmdEvent;

        public void CallCmdEvent(object sender, string e)
        {
            if (this.CmdEvent != null)
            {
                this.CmdEvent(sender, e);
            }
        }
    }
}
