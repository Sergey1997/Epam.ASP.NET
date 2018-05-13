using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class Generator : IGenerator
    {
        private int id;

        public Generator()
        {
            this.Id = 0;
        }


        public Generator(int id)
        {
            this.Id = id;
        }

        private int Id
        {
            get => this.id;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.id = value;
            }
        }

        public int GenerateId()
        {
            return Id++;
        }
    }
}
