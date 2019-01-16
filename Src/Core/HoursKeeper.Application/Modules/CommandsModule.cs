using System;
using Autofac;
using HoursKeeper.Application.Buses;
using HoursKeeper.Application.Interfaces;

namespace HoursKeeper.Application.Modules
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CommandsBus>()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.IsAssignableTo<IHandleCommand>()).AsImplementedInterfaces();
            builder.Register<Func<Type, IHandleCommand>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IHandleCommand<>).MakeGenericType(t);
                    return (IHandleCommand)context.Resolve(handlerType);
                };
            });
        }
    }
}