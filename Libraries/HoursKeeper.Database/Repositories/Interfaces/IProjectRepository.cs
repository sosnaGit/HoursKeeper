using System;
using System.Collections.Generic;
using HoursKeeper.Database.Models;

namespace HoursKeeper.Database.Repositories.Interfaces
{
    public interface IProjectRepository : IDisposable
    {
        Project GetProject(long id);

        Project GetProjectByName(string name);

        IEnumerable<Project> GetAllProjects();

        void AddProject(Project project);

        void DeleteProject(long id);

        long Count(Func<Project, bool> function = null);

        void SaveChanges();
    }
}