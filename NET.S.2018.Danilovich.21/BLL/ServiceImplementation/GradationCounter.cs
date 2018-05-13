using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class GradationCounter : IGradationCounter
    {
        #region Fields

        private GradationLogicCounter counter;

        #endregion Fields

        #region Constructor

        public GradationCounter()
        {
            counter = null;
        }

        #endregion Constructor


        #region Public methods

        public void SetGraduationType(Gradation gradation)
        {
            this.counter = GradationFactory.GetGradation(gradation);
        }

 
        public int Add(int bonusPoints)
        {
            return bonusPoints + this.counter.CoeffCostOfPayment;
        }


        public int Decrease(int bonusPoints)
        {
            return (bonusPoints <= this.counter.CoeffCostOfBalanse) ? 0 : bonusPoints - this.counter.CoeffCostOfBalanse;
        }

        #endregion Public methods
    }
}
