using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentPrice).GreaterThan(0);
            RuleFor(r => r.RentDate).GreaterThan(DateTime.Now);
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate);
            RuleFor(r => r.CarId).NotEmpty();
        }
    }
}
