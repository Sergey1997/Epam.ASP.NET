using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class GradationLogicCounter
    {
        #region Constructors
        /// <summary>
        /// Constructor of coeffitients for bonuses points
        /// </summary>
        /// <param name="coeffCostOfPayment">int coefficient of current payment</param>
        /// <param name="coeffCostOfBalance">int coefficient of balance value</param>
        public GradationLogicCounter(int coeffCostOfPayment, int coeffCostOfBalance)
        {
            this.CoeffCostOfPayment = coeffCostOfPayment;
            this.CoeffCostOfBalanse = coeffCostOfBalance;
        }
        #endregion

        #region  Properties
        /// <summary>
        /// The coefficient of current payment
        /// </summary>
        public int CoeffCostOfPayment { get; private set; }

        /// <summary>
        /// The balance value coefficient
        /// </summary>
        public int CoeffCostOfBalanse { get; private set; }
        #endregion
    }
}
