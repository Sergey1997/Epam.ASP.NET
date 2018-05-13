using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
//using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        public static void Main(string[] args)
        {
            IBankAccountService accountService = Resolver.Get<IBankAccountService>();

            Client c1 = new Client("12321", "323", "112", "32231");
            Client c2 = new Client("12321", "323", "112", "eqwqwe");
            accountService.Open(c1, Gradation.Gold);
            accountService.Open(c2, Gradation.Platinum);
            foreach(var item in accountService.GetAllAccounts())
            {
                Console.WriteLine(item.ToString());
            }
            accountService.Put(1, 120);
            accountService.Withdraw(1, 50);
            foreach (var item in accountService.GetAllAccounts())
            {
                Console.WriteLine(item.ToString());

            }
        }
    }
}
