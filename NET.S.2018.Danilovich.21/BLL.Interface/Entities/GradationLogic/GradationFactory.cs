using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class GradationFactory
    {
        public static GradationLogicCounter GetGradation(Gradation gradation)
        {
            switch (gradation)
            {
                case Gradation.Base:
                    {
                        return new Base();
                    }

                case Gradation.Silver:
                    {
                        return new Silver();
                    }

                case Gradation.Gold:
                    {
                        return new Gold();
                    }

                case Gradation.Platinum:
                    {
                        return new Platinum();
                    }

                default:
                    {
                        throw new ArgumentException($"{nameof(gradation)} doesnt exist");
                    }
            }
        }
    }
}
