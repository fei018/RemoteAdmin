using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace ServerModel
{
    public class RSFunctions:MarshalByRefObject,IRSFunctions
    {
        public void UploadHostInfoToDB(HostInfo host)
        {
            Console.WriteLine(host.HostSerial);
            HostInfoHelper helper = new HostInfoHelper();
            helper.UploadInfoToDB(host);            
        }
    }
}
