using FluentValidation;

namespace HoursKeeper.Application.Schedules.Commands.CreateSchedule
{
    public class CreateScheduleValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleValidator()
        {
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.SpentTime).NotNull().GreaterThan(0);
            RuleFor(x => x.Project).NotNull();
        }
    }
}
