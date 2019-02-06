using FluentValidation;

namespace FluentValidationSample
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Firstname)
                .NotEmpty();

            RuleFor(p => p.Surname)
                .NotEmpty();
        }
    }
}