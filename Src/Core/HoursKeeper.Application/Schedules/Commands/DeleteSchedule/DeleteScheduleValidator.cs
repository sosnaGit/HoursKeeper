using FluentValidation;

namespace HoursKeeper.Application.Schedules.Commands.DeleteSchedule
{
    public class DeleteScheduleValidator : AbstractValidator<DeleteScheduleCommand>
    {
        public DeleteScheduleValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
