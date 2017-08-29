using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{ 
    public interface IFunctions
    {
        event EventForwardDelegate CmdEventForward;
        string RunCmd(string command);
        void RunBatch(string batPath);
    }
}
