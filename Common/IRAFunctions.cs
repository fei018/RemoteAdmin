using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{ 
    public interface IRAFunctions
    {
        //event RAEventForwardDelegate RAEventForward;

        /// <summary>
        /// check connection password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool PasswordCheck(string password);

        /// <summary>
        /// Run a command from cmd.exe
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string RunCommand(string command);

        /// <summary>
        /// Run a batch file remotely
        /// </summary>
        /// <param name="batPath"></param>
        void RunBatch(string batPath);

        /// <summary>
        /// Get remote host info
        /// </summary>
        /// <returns></returns>
        HostInfo GetHostInfo();
    }
}
