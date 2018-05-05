using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger : ILogger
    {
        public string PathToFile;

        public Logger()
        {
        }

        public Logger(string path)
        {
            this.PathToFile = path;
        }

        public void Log(string message)
        {
            using (var file = File.AppendText(PathToFile))
            {
                file.Write(message);
            }

        }
    }
}
