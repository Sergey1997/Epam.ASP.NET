using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class Base : GradationLogicCounter
    {
        private const int coeffCostOfPayment = 1;

        private const int coeffCostOfBalanse = 1;

        public Base() :base(coeffCostOfPayment, coeffCostOfBalanse)
        {

        }
    }
}
