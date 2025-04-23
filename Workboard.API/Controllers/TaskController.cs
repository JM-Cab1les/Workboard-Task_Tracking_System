using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workboard.Application.DTO;
using Workboard.Application.Interfaces;
using Workboard.Application.Services;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;

namespace Workboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskservice_;

        public TaskController(ITaskService taskservice)
        {
            taskservice_ = taskservice;
        }

        [HttpGet("GetTaskList")]
        public async Task<List<spRetrieveTaskListResult>> GetTaskList()
        {
            return await taskservice_.GetTaskList();
        }

        [HttpGet("GetTotalTask")]
        public async Task<int> GetTotalTask()
        {
            return await taskservice_.GetTotalTask();
        }


        [HttpPost("AddNewTask")]
        public async Task<IActionResult> AddNewTask([FromBody] TaskDTO newTask)
        {
            try
            {
                await taskservice_.AddTask(newTask);
                return Ok(new { message = "New Task Added" });
            } catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateTask/{id}")]
        public ActionResult<Project> UpdateProject(int id, TaskDTO project)
        {
            try
            {
                taskservice_.UpdateTask(id, project);
                return Ok(new { message = "Project Updsated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteTask/{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            try
            {
                taskservice_.DeleteProject(taskId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetTaskListPerId/{userId}")]
        public async Task<int> GetTasksListPerId(int userId)
        {
            return await taskservice_.GetTotalTaskPerId(userId);
        }

        [HttpGet("GetTaskListPerUserId/{userIds}")]
        public async Task<List<spRetrieveTaskListPerIdResult>> GetTaskListPerUserId(int userIds)
        {
            return await taskservice_.GetTaskListPerId(userIds);
        }

    }
}
