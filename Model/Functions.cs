using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading;

namespace Model
{
    public class Functions:MarshalByRefObject,IFunctions
    {
        public event EventForwardDelegate CmdEventForward;

        public string RunCmd(string command)
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



    }
}
