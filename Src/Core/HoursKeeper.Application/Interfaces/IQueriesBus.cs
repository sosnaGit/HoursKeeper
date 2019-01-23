using HoursKeeper.Domain.Interfaces;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Interfaces
{
    public interface IQueriesBus
    {
        TResult Execute<TQuery, TResult>(TQuery query, DatabaseContext context, bool isRequired = false) 
            where TQuery : IQuery
            where TResult : IEntity;
    }
}
