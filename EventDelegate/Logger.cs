using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Logger
    {
        private static readonly Logger l = new Logger();
        public string FileName { get; set; }
        private Logger()
        {
            this.FileName = "Info.txt";
        }
        public static Logger GetLogger()
        {
            return l;
        }
    }
}
