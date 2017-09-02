using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{ 
    public interface IFunctions
    {
        event RAEventForwardDelegate CmdEventForward;

        bool PasswordCheck(string password);
        string RunCmd(string command);
        void RunBatch(string batPath);
    }
}
