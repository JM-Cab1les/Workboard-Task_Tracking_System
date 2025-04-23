using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Workboard.Application.DTO;
using Workboard.Application.Interfaces;
using Workboard.Domain.Entities;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;

namespace Workboard.Application.Services
{
    public class TaskService : ITaskService
    {
        public readonly ITaskRepository taskrepository_;

        public TaskService(ITaskRepository taskrepository)
        {
            taskrepository_ = taskrepository;
        }
        public async System.Threading.Tasks.Task AddTask(TaskDTO addNewTask)
        {
            if (addNewTask == null)
                throw new ArgumentNullException(nameof(addNewTask));

            var newTask = new Domain.Entities.Task
            {
                Title = addNewTask.Title,
                Description = addNewTask.Description,
                Status = addNewTask.Status,
                Priority = addNewTask.Priority,
                DueDate = addNewTask.DueDate,
                ProjectId = addNewTask.ProjectId,
                CreatedDate =  DateTime.Now,
                MemberAssigned = addNewTask.MemberAssigned,
                CreatedById = addNewTask.CreatedById
            };

            await taskrepository_.AddTask(newTask);

        }

        public void DeleteProject(int id)
        {
            taskrepository_.DeleteTask(id);
        }

        public async Task<List<spRetrieveTaskListResult>> GetTaskList()
        {
            return await taskrepository_.GetTaskList();
        }

        public async Task<List<spRetrieveTaskListPerIdResult>> GetTaskListPerId(int usedIds)
        {
            return await taskrepository_.GetTaskListPerId(usedIds);
        }

        public async Task<int> GetTotalTask()
        {
            return await taskrepository_.GetTotalTask();
        }

        public async Task<int> GetTotalTaskPerId(int userId)
        {
            return await taskrepository_.GetTotalTaskPerId(userId);
        }

        public Domain.Entities.Task UpdateTask(int taskId, TaskDTO editTask)
        {
            if (editTask == null)
                throw new ArgumentNullException(nameof(editTask));

            var existingTask = new Domain.Entities.Task
            {
                Title = editTask.Title,
                Description = editTask.Description,
                Status = editTask.Status,
                Priority = editTask.Priority,
                DueDate = editTask.DueDate,
                ProjectId = editTask.ProjectId,
                MemberAssigned = editTask.MemberAssigned
            };

            return taskrepository_.UpdateTask(taskId, existingTask);
        }
    }
}
