using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;
using System.Linq;

namespace HoursKeeper.Application.Schedules.Commands.DeleteSchedule
{
    public class DeleteScheduleHandler : IHandleCommand<DeleteScheduleCommand>
    {
        private readonly DeleteScheduleValidator _validator;

        public DeleteScheduleHandler()
        {
            _validator = new DeleteScheduleValidator();
        }

        public void Handle(DeleteScheduleCommand command, DatabaseContext context, bool shouldSaveChanges = false)
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

            context.Schedules.Remove(schedule);

            if (shouldSaveChanges)
                context.SaveChanges();
        }
    }
}
