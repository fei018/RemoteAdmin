﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading;

namespace RAModel
{
    public class RAFunctions:MarshalByRefObject,IRAFunctions
    {
        //public event RAEventForwardDelegate RAEventForward;

        public bool PasswordCheck(string password)
        {
            if (password == null) return false;

            RAPasswd p = new RAPasswd();
            if (p.ToCheck(password)) return true;

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
            RACmd cmd = new RACmd();
            return cmd.Run(command);
        }


        public void RunBatch(string batPath)
        {

        }

        /// <summary>
        /// Get local host info
        /// </summary>
        /// <returns></returns>
        public HostInfo GetHostInfo()
        {
            HostInfo h = new HostInfo();
            h.LoadInfo();
            return h;
        }
    }
}
