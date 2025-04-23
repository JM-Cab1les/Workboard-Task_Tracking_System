using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Workboard.Application.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;
using Workboard.Infratsructure.Contexts;

namespace Workboard.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly Workboard_DBContext contexts_;

        public ProjectRepository(Workboard_DBContext contexts)
        {
            contexts_ = contexts;
        }

   

       public async System.Threading.Tasks.Task AddProject(Project newProject)
        {
            try
            {
                contexts_.Projects.Add(newProject);
               await contexts_.SaveChangesAsync();

               // var exisitngProject = contexts_.Projects.Find(newProject.Id);

               //if(exisitngProject.Tasks != null && exisitngProject.Tasks.Any())
               // {
               //     foreach(var task in exisitngProject.Tasks)
               //     {
               //         var tasks = new Domain.Entities.Task
               //         {
               //             Title = task.Title,
               //             Description = task.Description,
               //             Status = task.Status,
               //             Priority = task.Priority,
               //             DueDate = task.DueDate,
               //             CreatedDate = task.CreatedDate,
               //             CreatedById = task.CreatedById

               //         };
               //         contexts_.Tasks.Add(tasks);
               //     }

               //     contexts_.SaveChangesAsync();

                    
               // }

   

            }catch (Exception ex)
            {

            }

        }

        public void DeleteProject(int id)
        {
            try
            {
                var existingProject = contexts_.Projects.FirstOrDefault(p => p.Id == id);

                if (existingProject != null)
                {
                    contexts_.Projects.Remove(existingProject);
                    contexts_.SaveChanges();


                }
            }
            catch (Exception ex)
            {
            }

        }

        public async Task<int> GetProjectCount()
        {
            return await contexts_.Projects.CountAsync();
        }

        public async Task<List<spRetrieveProjectListResult>> GetProjectList()
        {
            return await contexts_.Procedures.spRetrieveProjectListAsync();
        }

        public Project UpdateProject(int projectId, Project editProject)
        {
            try
            {
                var existingProject = contexts_.Projects.FirstOrDefault(p => p.Id == projectId);

                if (existingProject == null)
                {
                    throw new Exception("Project not found");
                }

                existingProject.Name = editProject.Name;
                existingProject.Description = editProject.Description;


                contexts_.SaveChanges();
 

                return existingProject;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while updating the project", ex);
            }
        }
    }
}
