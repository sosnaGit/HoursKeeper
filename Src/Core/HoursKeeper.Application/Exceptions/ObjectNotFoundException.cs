using System;

namespace HoursKeeper.Application.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string objectName, long id)
            : base($"{objectName} with id {id} was not found")
        {
        }
    }
}
