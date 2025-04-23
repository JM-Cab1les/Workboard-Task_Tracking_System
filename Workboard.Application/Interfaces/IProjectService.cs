using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Application.DTO;
using Workboard.Domain.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;

namespace Workboard.Application.Interfaces
{
    public interface IProjectService
    {
        System.Threading.Tasks.Task AddProject(ProjectDto newProject);
        Task<List<spRetrieveProjectListResult>> GetProjectList();
        public void DeleteProject(int id);
        public Project UpdateProject(int projectId, ProjectDto editProject);
        public Task<int> GetProjectCount();
    }
}
