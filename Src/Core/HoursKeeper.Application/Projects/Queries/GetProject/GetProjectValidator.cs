using FluentValidation;

namespace HoursKeeper.Application.Projects.Queries.GetProject
{
    public class GetProjectValidator : AbstractValidator<GetProjectQuery>
    {
        public GetProjectValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
