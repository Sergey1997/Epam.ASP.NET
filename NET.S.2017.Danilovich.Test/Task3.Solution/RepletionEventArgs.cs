using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class RepletionEventArgs : EventArgs
    {
        public int USD { get; set; }
        public int EUR { get; set; }
        public RepletionEventArgs(int usd, int eur)
        {
            USD = usd;
            EUR = eur;
        }
    }
}
