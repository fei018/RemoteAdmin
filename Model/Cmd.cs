using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Common;

namespace Model
{
    public class Cmd
    {
        private Process _process;
        private ProcessStartInfo _startInfo;

        //public event EventForwardDelegate OutputEvent;

        public string Run(string command)
        {
            using (_process = new Process())
            {
                _startInfo = new ProcessStartInfo();
                _startInfo.FileName = "cmd.exe";
                _startInfo.RedirectStandardError = true;
                _startInfo.RedirectStandardInput = true;
                _startInfo.RedirectStandardOutput = true;
                _startInfo.UseShellExecute = false;
                _startInfo.CreateNoWindow = true;

                _process.StartInfo = _startInfo;
                _process.Start();
                _process.StandardInput.WriteLine(command);
                _process.StandardInput.Flush();

                string output = _process.StandardOutput.ReadToEnd();
                string error = _process.StandardError.ReadToEnd();
                //if (OutputEvent != null)
                //{
                //    if (output != null) OutputEvent(null, output);

                //    if (error != null) OutputEvent(null, error);
                //}
                string result = null;
                if (output != null) result = output;

                if (error != null) result = error;

                _process.WaitForExit();
                return result;
            }
        }

        public void RunBatch(string path)
        {
            Process.Start(path);
        }
    }
}
