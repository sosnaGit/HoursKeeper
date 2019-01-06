using System;
using System.Collections.Generic;
using HoursKeeperDatabase.Models;

namespace HoursKeeperDatabase.Repositories.Interfaces
{
    public interface IProjectRepository : IDisposable
    {
        Project GetProject(long id);

        IEnumerable<Project> GetAllProjects();

        void AddProject(Project project);

        void DeleteProject(long id);

        void SaveChanges();
    }
}