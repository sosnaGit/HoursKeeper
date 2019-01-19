using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Schedules.Commands.CreateSchedule
{
    public class CreateScheduleHandler : IHandleCommand<CreateScheduleCommand>
    {
        private readonly CreateScheduleValidator _validator;

        public CreateScheduleHandler()
        {
            _validator = new CreateScheduleValidator();
        }

        public void Handle(CreateScheduleCommand command, DatabaseContext context, bool shouldSaveChanges = false)
        {
            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                throw new CustomValidationException(result.Errors);
            }

            context.Schedules.Add(new Schedule
            {
                Date = command.Date,
                SpentTime = command.SpentTime,
                Project = command.Project,
                Note = command.Note
            });

            if (shouldSaveChanges)
                context.SaveChanges();
        }
    }
}
