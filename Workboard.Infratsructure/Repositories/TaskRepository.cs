using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workboard.Domain.Entities;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;
using Workboard.Infratsructure.Contexts;

namespace Workboard.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Workboard_DBContext contexts_;

        public TaskRepository(Workboard_DBContext contexts)
        {
            contexts_ = contexts;
        }


        public async System.Threading.Tasks.Task AddTask(Domain.Entities.Task addNewTask)
        {
            try
            {
                contexts_.Tasks.Add(addNewTask);
                await contexts_.SaveChangesAsync();
                if (!string.IsNullOrEmpty(addNewTask.MemberAssigned))
                {
                    var userIds = addNewTask.MemberAssigned
                        .Split(',')
                        .Select(id => int.TryParse(id.Trim(), out var parsedId) ? parsedId : (int?)null)
                        .Where(id => id.HasValue)
                        .Select(id => id.Value)
                        .ToList();

                    foreach (var userId in userIds)
                    {
                        var notification = new Notification
                        {
                            UserId = userId,
                            Message = $"You have been assigned a new task: {addNewTask.Title}",
                            TaskId = addNewTask.Id,
                            CreatedDate = DateTime.Now,
                            IsRead = false
                        };

                        contexts_.Notifications.Add(notification); 
                    }

                    await contexts_.SaveChangesAsync(); 
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void DeleteTask(int id)
        {
            try
            {
                var existingTask = contexts_.Tasks.FirstOrDefault(t => t.Id == id);

                if(existingTask != null)
                {
                    var relatedNotification = contexts_.Notifications.Where(n => n.TaskId == existingTask.Id).ToList();
                    if (relatedNotification.Any())
                    {
                        contexts_.Notifications.RemoveRange(relatedNotification);
                    }

                }

                    contexts_.Tasks.Remove(existingTask);
                    contexts_.SaveChanges();

            }
            catch (Exception ex) { 

            }

        }

        public async Task<List<spRetrieveTaskListResult>> GetTaskList()
        {
            return await contexts_.Procedures.spRetrieveTaskListAsync();
        }

        public async Task<List<spRetrieveTaskListPerIdResult>> GetTaskListPerId(int usedIds)
        {
            return await contexts_.Procedures.spRetrieveTaskListPerIdAsync(usedIds);
        }

        public async Task<int> GetTotalTask()
        {
            return await contexts_.Tasks.CountAsync();
        }

        public async Task<int> GetTotalTaskPerId(int userId)
        {
           var allTasks = await contexts_.Tasks.Where(task => task.MemberAssigned != null).ToListAsync();

            var totalTasksPerId = allTasks.Count(task => task.MemberAssigned.Split(',').Select(int.Parse).Contains(userId));

            return totalTasksPerId;
        }

        public Domain.Entities.Task UpdateTask(int taskId, Domain.Entities.Task editTask)
        {
            try
            {
                var existingTask = contexts_.Tasks.FirstOrDefault(p => p.Id == taskId);

                if (existingTask == null)
                {
                    throw new Exception("Task not found");
                }

                existingTask.Title = editTask.Title;
                existingTask.Description = editTask.Description;
                existingTask.Status = editTask.Status;
                existingTask.Priority = editTask.Priority;
                existingTask.DueDate = editTask.DueDate;
                existingTask.ProjectId = editTask.ProjectId;
                existingTask.MemberAssigned = editTask.MemberAssigned;

                contexts_.Update(existingTask);
                contexts_.SaveChanges();


                return existingTask;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while updating the Task", ex);
            }
        }
    }
}
