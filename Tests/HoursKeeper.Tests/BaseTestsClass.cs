﻿using NUnit.Framework;
using HoursKeeper.Database;
using Microsoft.EntityFrameworkCore;

namespace HoursKeeper.Tests
{
    public abstract class BaseTestsClass
    {
        protected DatabaseContext _context;

        [SetUp]
        public virtual void Configure()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "database")
                .Options;

            _context = new DatabaseContext();
            _context.Database.EnsureCreated();
        }

        [TearDown]
        public virtual void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}