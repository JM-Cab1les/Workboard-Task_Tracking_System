using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Application.DTO;
using Workboard.Application.Interfaces;
using Workboard.Domain.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;

namespace Workboard.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository_;

        public ProjectService(IProjectRepository projectRepository)
        {
            projectRepository_ = projectRepository;
        }
        public async System.Threading.Tasks.Task AddProject(ProjectDto newProject)
        {
            if (newProject == null)
                throw new ArgumentNullException(nameof(newProject));

            var project = new Project
            {
                Name = newProject.Name,
                Description = newProject.Description,
                CreatedById = newProject.CreatedById,
                CreatedDate = DateTime.Now,

            };

            //foreach(var taskDTO in newProject.Tasks)
            //{
            //    var tasks = new Domain.Entities.Task
            //    {
            //        Title = taskDTO.Title,
            //        Description = taskDTO.Description,
            //        DueDate = taskDTO.DueDate,
            //        ProjectId = project.Id
            //    };

            //    project.Tasks.Add(tasks);
            //}


           await projectRepository_.AddProject(project);
        }

        public void DeleteProject(int id)
        {
            projectRepository_.DeleteProject(id);
        }

        public Task<int> GetProjectCount()
        {
            return projectRepository_.GetProjectCount();
        }

        public async Task<List<spRetrieveProjectListResult>> GetProjectList()
        {
            return await projectRepository_.GetProjectList();
        }

        public Project UpdateProject(int projectId, ProjectDto editProject)
        {
            if (editProject == null)
                throw new ArgumentNullException(nameof(editProject));

            var existingProject = new Project
            {
                Name = editProject.Name,
                Description = editProject.Description,
                CreatedById = editProject.CreatedById,
            };

            return projectRepository_.UpdateProject(projectId, existingProject);
        }
    }
}
