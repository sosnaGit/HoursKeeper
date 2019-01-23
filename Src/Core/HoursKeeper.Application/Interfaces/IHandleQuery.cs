using HoursKeeper.Domain.Interfaces;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Interfaces
{
    public interface IHandleQuery
    {
    }

    public interface IHandleQuery<TQuery, TResult> : IHandleQuery
        where TQuery : IQuery
        where TResult : IEntity
    {
        TResult Handle(TQuery query, DatabaseContext context, bool isRequired = false);
    }
}
