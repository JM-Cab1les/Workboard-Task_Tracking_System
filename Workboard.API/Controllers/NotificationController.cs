using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workboard.Application.Interfaces;
using Workboard.Domain.SPEntity;

namespace Workboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService_;

        public NotificationController(INotificationService notificationService)
        {
            notificationService_ = notificationService;
        }

        [HttpGet("GetNotificationById/{userId}")]
        public async Task<List<spRetrieveNotificationListResult>> GetNotificationPerId(int userId)
        {
            return await notificationService_.GetNotificationList(userId);
        }
    }
}
