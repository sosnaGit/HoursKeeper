using FluentValidation;

namespace HoursKeeper.Application.Schedules.Commands.UpdateSchedule
{
    public class UpdateScheduleValidator : AbstractValidator<UpdateScheduleCommand>
    {
        public UpdateScheduleValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.SpentTime).NotNull().GreaterThan(0);
            RuleFor(x => x.Project).NotNull();
        }
    }
}
