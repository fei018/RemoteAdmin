using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{ 
    public interface IFunctions
    {
        event RAEventForwardDelegate CmdEventForward;

        //check connection password
        bool PasswordCheck(string password);

        //Run a command from cmd.exe
        string RunCommand(string command);

        //Run a batch file remotely
        void RunBatch(string batPath);

        //Send host info to Server
        HostInfo GetHostInfo();
    }
}
