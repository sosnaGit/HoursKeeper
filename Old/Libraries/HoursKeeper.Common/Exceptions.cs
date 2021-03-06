﻿using System;

namespace HoursKeeper.Old.Common
{
    public class NotUniqueException : Exception
    {
        public NotUniqueException() {}
        public NotUniqueException(string message) : base(message) {}
    }

    public class EntityNotExistException : Exception
    {
        public EntityNotExistException() { }
        public EntityNotExistException(string message) : base(message) { }
    }
}
