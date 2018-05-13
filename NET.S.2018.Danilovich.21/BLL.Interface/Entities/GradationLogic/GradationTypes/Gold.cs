namespace BLL.Interface.Entities
{
    public class Gold : GradationLogicCounter
    {
        private const int coeffCostOfPayment = 3;

        private const int coeffCostOfBalanse = 3;

        public Gold() : base(coeffCostOfPayment, coeffCostOfBalanse)
        {

        }
    }
}
