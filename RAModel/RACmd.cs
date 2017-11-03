using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Common;

namespace RAModel
{
    public class RACmd
    {
        private Process _process;
        private ProcessStartInfo _startInfo;

        //public event EventForwardDelegate OutputEvent;

        /// <summary>
        /// Run a cmd.exe command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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

                try
                {
                    _process.Start();
                    _process.StandardInput.WriteLine(command);
                    _process.StandardInput.Flush();

                    string output = _process.StandardOutput.ReadToEnd();
                    string error = _process.StandardError.ReadToEnd();
                    string result = null;
                    if (output != null) result = output;

                    if (error != null) result = error;

                    _process.WaitForExit();
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                    return ex.Message;
                }
            }
        }

        /// <summary>
        /// Run a remote batch file
        /// </summary>
        /// <param name="path"></param>
        public void RunBatch(string path)
        {
            Process.Start(path);
        }
    }
}
