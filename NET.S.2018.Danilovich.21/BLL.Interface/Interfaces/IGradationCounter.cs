using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IGradationCounter
    {
        void SetGraduationType(Gradation gradation);

        int Add(int bonus);
        
        int Decrease(int bonus);
    }
}
