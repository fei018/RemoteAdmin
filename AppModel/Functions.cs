using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading;

namespace AppModel
{
    public class Functions:MarshalByRefObject,IFunctions
    {
        public event RAEventForwardDelegate CmdEventForward;

        public bool PasswordCheck(string password)
        {
            return false;
        }

        /// <summary>
        /// Run a command from cmd.exe
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string RunCommand(string command)
        {
            //Thread thread = new Thread(new ThreadStart (new Action(()=>
            //    {
            //        Cmd cmd = new Cmd();
            //        cmd.OutputEvent += cmd_OutputEvent;
            //        cmd.Run(command);
            //        cmd.OutputEvent -= cmd_OutputEvent;
            //    }))); 
            Cmd cmd = new Cmd();
            return cmd.Run(command);
        }


        public void RunBatch(string batPath)
        {

        }

        public HostInfo GetHostInfo()
        {
            HostInfo h = new HostInfo();
            h.LoadInfo();
            return h;
        }

    }
}
