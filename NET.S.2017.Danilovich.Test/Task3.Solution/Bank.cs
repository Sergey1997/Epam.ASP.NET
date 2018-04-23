using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Bank
    {
        private Stock stock;
        public string Name { get; set; }

        public Bank(string name, Stock stock)
        {
            this.Name = name;
            this.stock = stock;
            stock.Overflow += Update;
        }

        private void Update(object sender, RepletionEventArgs current)
        {
            if (current.EUR > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, current.EUR);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, current.EUR);
        }
    }
}
