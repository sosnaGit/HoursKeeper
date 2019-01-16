using System;
using Autofac;
using HoursKeeper.Application.Buses;
using HoursKeeper.Application.Interfaces;

namespace HoursKeeper.Application.Modules
{
    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CommandsBus>()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.IsAssignableTo<IHandleEvent>()).AsImplementedInterfaces();
            builder.Register<Func<Type, IHandleEvent>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IHandleEvent<>).MakeGenericType(t);
                    return (IHandleEvent)context.Resolve(handlerType);
                };
            });
        }
    }
}
