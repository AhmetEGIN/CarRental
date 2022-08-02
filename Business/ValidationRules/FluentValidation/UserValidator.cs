using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.Password).NotEmpty();
            RuleFor(u => u.Password).Must(GreaterThen);
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.EMail).Must(EndWith);
        }

        private bool EndWith(string arg)
        {
            return arg.EndsWith("@gmail.com");
        }

        private bool GreaterThen(int arg)
        {
            return arg > 100000;
        }
    }
}
