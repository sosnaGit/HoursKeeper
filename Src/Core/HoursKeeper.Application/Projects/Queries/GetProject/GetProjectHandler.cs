using System.Linq;
using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Projects.Queries.GetProject
{
    public class GetProjectHandler : IHandleQuery<GetProjectQuery, Project>
    {
        private readonly GetProjectValidator _validator;

        public GetProjectHandler()
        {
            _validator = new GetProjectValidator();
        }

        public Project Handle(GetProjectQuery query, DatabaseContext context, bool isRequired = true)
        {
            var validationResult = _validator.Validate(query);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var result = context.Projects.FirstOrDefault(x => x.Id == query.Id);

            if (isRequired && result == null)
                throw new ObjectNotFoundException(nameof(Project), query.Id);

            return result;
        }
    }
}
