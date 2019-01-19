using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;
using System.Linq;

namespace HoursKeeper.Application.Schedules.Commands.UpdateSchedule
{
    public class UpdateScheduleHandler : IHandleCommand<UpdateScheduleCommand>
    {
        private readonly UpdateScheduleValidator _validator;

        public UpdateScheduleHandler()
        {
            _validator = new UpdateScheduleValidator();
        }

        public void Handle(UpdateScheduleCommand command, DatabaseContext context, bool shouldSaveChanges = false)
        {
            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                throw new CustomValidationException(result.Errors);
            }

            var schedule = context.Schedules.FirstOrDefault(x => x.Id == command.Id);

            if (schedule == null)
            {
                throw new ObjectNotFoundException(nameof(Schedule), command.Id);
            }

            schedule.Date = command.Date;
            schedule.SpentTime = command.SpentTime;
            schedule.Project = command.Project;
            schedule.Note = command.Note;

            if (shouldSaveChanges)
                context.SaveChanges();
        }
    }
}
