using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;
using Task = Workboard.Domain.Entities.Task;

namespace Workboard.Domain.Interfaces
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task AddTask(Entities.Task addNewTask);
        public void DeleteTask(int id);
        public Task UpdateTask(int taskId, Task editTask);
        Task<List<spRetrieveTaskListResult>> GetTaskList();
        Task<int> GetTotalTask();
        Task<int> GetTotalTaskPerId(int userId);
        Task<List<spRetrieveTaskListPerIdResult>> GetTaskListPerId(int usedIds);
    }
}
