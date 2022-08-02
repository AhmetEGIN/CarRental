using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(f => f.DailyPrice).NotEmpty();
            RuleFor(f => f.DailyPrice).GreaterThan(0);
            RuleFor(f => f.DailyPrice).GreaterThanOrEqualTo(800).When(f=>f.Description == "Coupe");
            RuleFor(f => f.ModelYear).NotEmpty();
            RuleFor(f => f.Description).MinimumLength(2);
            RuleFor(f => f.ModelYear).GreaterThanOrEqualTo(2015);


        }

    }
}
