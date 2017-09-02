using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class RAConfigFile
    {
        public RAConfigFile(string filePath)
        {
            this._filePath = filePath;
        }

        private string _filePath;

        public string Path
        {
            get
            {
                return this._filePath;
            }
        }
    }
}
