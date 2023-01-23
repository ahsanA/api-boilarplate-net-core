using FluentValidation;

namespace APIBoilerplate.Application.Cows.Commands.AddCow
{
    public class AddCowCommandValidator : AbstractValidator<AddCowCommand>
    {
        public AddCowCommandValidator()
        {
            RuleFor(x => x.InitialWeight)
                .NotEmpty();
            RuleFor(x => x.FarmId)
                .NotEmpty();
        }
    }
}