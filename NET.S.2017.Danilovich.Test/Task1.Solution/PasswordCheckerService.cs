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
        private IValidator validator;

        public PasswordCheckerService(IRepository repository, IValidator validator)
        {
            this.repository = repository ?? throw new ArgumentNullException($"{(nameof(repository))} musnt be a null");
            this.validator = validator ?? throw new ArgumentNullException($"{(nameof(validator))} musnt be a null");
        }

        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException($"{password} musnt be a null");

            Tuple<bool, string> checker = validator.VerifyPassword(password);

            if (checker.Item1 == true)
            {
                repository.Create(password);
            }

            return checker;
        }
    }
}
