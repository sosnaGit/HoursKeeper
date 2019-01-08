using System;
using System.Linq;
using System.Collections.Generic;
using HoursKeeper.Database.Models;
using HoursKeeper.Database.Repositories.Interfaces;

namespace HoursKeeper.Database.Repositories
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
            var existingProject = GetProjectByName(project.Name);

            if (existingProject == null)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            else
                throw new Exception("Project already exists");
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

        public Project GetProjectByName(string name)
        {
            return _context.Projects.FirstOrDefault(x => x.Name == name);
        }

        public long Count(Func<Project, bool> function = null)
        {
            if (function == null)
                return _context.Projects.Count();

            return _context.Projects.Count(function);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
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
