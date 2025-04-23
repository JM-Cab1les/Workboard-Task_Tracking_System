using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Application.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;
using Tasks = Workboard.Domain.Entities.Task;

namespace Workboard.Application.Interfaces
{
    public interface ITaskService
    {
        System.Threading.Tasks.Task AddTask(TaskDTO addNewTask);
        public Tasks UpdateTask(int taskId, TaskDTO editTask);
        public void DeleteProject(int id);
        Task<List<spRetrieveTaskListResult>> GetTaskList();
        Task<int> GetTotalTask();
        Task<int> GetTotalTaskPerId(int userId);
        Task<List<spRetrieveTaskListPerIdResult>> GetTaskListPerId(int usedIds);
        //Task<Notification> AddNotification(Notification addNotification);
    }
}
