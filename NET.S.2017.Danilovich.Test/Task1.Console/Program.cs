using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository sqlRepository = new SqlRepository();
            IRepository binaryFileRepository = new BinaryFileRepository();

            PasswordCheckerService checkerService = new PasswordCheckerService(sqlRepository, new CustomValidator());
            PasswordCheckerService checkerService2 = new PasswordCheckerService(binaryFileRepository, new CustomValidator());

            System.Console.WriteLine(checkerService.VerifyPassword("GoodPassword1"));
            System.Console.WriteLine(checkerService2.VerifyPassword("badpass"));

        }
    }
}
