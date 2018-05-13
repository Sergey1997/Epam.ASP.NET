using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class Account
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public decimal Balance { get; set; }

        public int BonusPoints { get; set; }

        public int Gradation { get; set; }
    }
}
