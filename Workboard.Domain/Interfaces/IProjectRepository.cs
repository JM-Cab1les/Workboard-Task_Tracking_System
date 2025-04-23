using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;

namespace Workboard.Domain.Interfaces
{
    public interface IProjectRepository
    {
       System.Threading.Tasks.Task AddProject(Project newProject);
       Task<List<spRetrieveProjectListResult>> GetProjectList();
        public void DeleteProject(int id);
        public Project UpdateProject(int projectId, Project editProject);
        public Task<int> GetProjectCount();

    }
}
