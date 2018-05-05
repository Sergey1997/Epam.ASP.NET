using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace XMLParserLogic
{
    public class XmlConverter
    {       
        public XmlConverter(ILogger logger)
        {
            this.Logger = logger;
        }
        public ILogger Logger { get; set; }
    }
}
