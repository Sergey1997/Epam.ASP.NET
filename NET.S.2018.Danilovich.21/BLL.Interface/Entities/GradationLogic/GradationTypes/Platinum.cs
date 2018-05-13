namespace BLL.Interface.Entities
{
    public class Platinum : GradationLogicCounter
    {
        private const int coeffCostOfPayment = 4;

        private const int coeffCostOfBalanse = 4;

        public Platinum() : base(coeffCostOfPayment, coeffCostOfBalanse)
        {

        }
    }
}
