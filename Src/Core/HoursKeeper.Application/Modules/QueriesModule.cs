using System;
using Autofac;
using HoursKeeper.Application.Buses;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Domain.Interfaces;

namespace HoursKeeper.Application.Modules
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<QueriesBus>()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.IsAssignableTo<IHandleQuery>()).AsImplementedInterfaces();
            builder.Register<Func<Type[], IHandleQuery>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IHandleQuery<,>).MakeGenericType(t);
                    return (IHandleQuery)context.Resolve(handlerType);
                };
            });
        }
    }
}