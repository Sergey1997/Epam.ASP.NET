using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Stock
    {
        public event EventHandler<RepletionEventArgs> Overflow = delegate { };

        public void Imitation()
        {
            RepletionEventArgs currentCourse = new RepletionEventArgs(28,37);
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                currentCourse.USD += random.Next(0, 3);
                currentCourse.EUR += random.Next(0, 3);
                System.Threading.Thread.Sleep(1000);
                OnOverflow(currentCourse);
            }

        }
        protected virtual void OnOverflow(RepletionEventArgs args)
        {
            Overflow(this, args);
        }
    }
}
