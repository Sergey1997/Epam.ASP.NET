using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Broker
    {
        private Stock stock;

        public string Name { get; set; }

        public Broker(string name, Stock stock)
        {
            this.Name = name;
            this.stock = stock;
            stock.Overflow += Update;
        }

        public void Update(object info, RepletionEventArgs current)
        {
            if (current.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, current.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, current.USD);
        }

        public void StopTrade()
        {
            stock.Overflow -= Update;
            stock = null;
        }
    }
}
