using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Application.Interfaces;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;

namespace Workboard.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepository_;

        public NotificationService(INotificationRepository notificationRepository)
        {
            notificationRepository_ = notificationRepository;
        }

        public async Task<List<spRetrieveNotificationListResult>> GetNotificationList(int userId)
        {
            return await notificationRepository_.GetNotificationList(userId);
        }
    }
}
