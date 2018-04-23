using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordCheckerService
    {
        private IRepository repository;
        private IEnumerable<IValidator> validators;

        public PasswordCheckerService(IRepository repository, IEnumerable<IValidator> validators)
        {
            this.repository = repository ?? throw new ArgumentNullException($"{(nameof(repository))} musnt be a null");
            this.validators = validators ?? throw new ArgumentNullException($"{(nameof(validators))} musnt be a null");
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            var checker = validators.Select(x => x.IsValid(password));

            if (checker.All(x => x.Item1))
            {
                repository.Create(password);
                return Tuple.Create(true, "Password is Ok. User was created");
            }

            return checker.First(x => !x.Item1);
        }
    }
}
