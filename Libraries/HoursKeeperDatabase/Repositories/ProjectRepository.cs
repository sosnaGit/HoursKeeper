using System;
using System.Linq;
using System.Collections.Generic;
using HoursKeeperDatabase.Models;
using HoursKeeperDatabase.Repositories.Interfaces;

namespace HoursKeeperDatabase.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DatabaseContext _context;

        public ProjectRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public void DeleteProject(long id)
        {
            var project = GetProject(id);

            if (project == null)
                throw new Exception($"Project with id {id} does not exist");

            _context.Projects.Remove(project);
        }

        public IEnumerable<Project> GetAllProjects()
        {
           return _context.Projects;
        }

        public Project GetProject(long id)
        {
            return _context.Projects.FirstOrDefault(x => x.Id == id);
        }
        
        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
