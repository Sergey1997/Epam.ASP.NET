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
            IValidator[] enumerables =
            {
                new StringValidator(), new LengthValidator()
            };
            IValidator[] enumerables2 =
            {
                new StringValidator()
            };

            PasswordCheckerService checkerService = new PasswordCheckerService(sqlRepository, enumerables);
            PasswordCheckerService checkerService2 = new PasswordCheckerService(binaryFileRepository, enumerables2);

            System.Console.WriteLine(checkerService.VerifyPassword("GoodPassword1"));
            System.Console.WriteLine(checkerService2.VerifyPassword("badpass"));

        }
    }
}
