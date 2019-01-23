using HoursKeeper.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoursKeeper.Domain.Entities
{
    public class Project : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
