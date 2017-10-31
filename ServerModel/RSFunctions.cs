using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace ServerModel
{
    public class RSFunctions:MarshalByRefObject,IRSFunctions
    {
        public void UpdateHostInfoToDB(HostInfo host)
        {
            Console.WriteLine(host.HostSerial);
            HostInfoHelper helper = new HostInfoHelper();
            helper.UpdateInfoToDB(host);            
        }
    }
}
