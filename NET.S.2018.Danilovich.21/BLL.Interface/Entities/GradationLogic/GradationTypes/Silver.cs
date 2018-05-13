namespace BLL.Interface.Entities
{
    public class Silver : GradationLogicCounter
    {
        private const int coeffCostOfPayment = 2;

        private const int coeffCostOfBalanse = 2;

        public Silver() : base(coeffCostOfPayment, coeffCostOfBalanse)
        {

        }
    }
}
