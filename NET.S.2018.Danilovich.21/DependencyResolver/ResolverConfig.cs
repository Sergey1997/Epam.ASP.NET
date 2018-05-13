using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IGenerator>().To<Generator>();
            kernel.Bind<IRepository>().To<FakeRepository>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<IGradationCounter>().To<GradationCounter>();
        }
    }
}
