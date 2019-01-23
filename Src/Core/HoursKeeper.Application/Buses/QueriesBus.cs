using System;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Interfaces;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Buses
{
    public class QueriesBus : IQueriesBus
    {
        private readonly Func<Type[], IHandleQuery> _handlersFactory;
        public QueriesBus(Func<Type[], IHandleQuery> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public TResult Execute<TQuery, TResult>(TQuery query, DatabaseContext context, bool isRequired = false) 
            where TQuery : IQuery
        {
            Type[] typeArgs = { typeof(TQuery), typeof(TResult) };

            var handler = (IHandleQuery<TQuery, TResult>)_handlersFactory(typeArgs);
            return handler.Handle(query, context, isRequired);
        }
    }
}