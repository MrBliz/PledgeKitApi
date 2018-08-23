using System;
using FluentValidation;
using PledgeKit.Core.Events.Commands;

namespace PledgeKit.Core.Events.Validation
{
    public class CreateEventValidator :  AbstractValidator<CreateEventCommand>
    {
        public CreateEventValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(100);
            RuleFor(x => x.EventLevy).InclusiveBetween(0,1);
            RuleFor(x => x.EventDate).GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
