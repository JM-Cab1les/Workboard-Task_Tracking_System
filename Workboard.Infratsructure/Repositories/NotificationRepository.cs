using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;
using Workboard.Infratsructure.Contexts;

namespace Workboard.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly Workboard_DBContext contexts_;

        public NotificationRepository(Workboard_DBContext contexts)
        {
            contexts_ = contexts;
        }

        public async Task<List<spRetrieveNotificationListResult>> GetNotificationList(int userId)
        {
            return await contexts_.Procedures.spRetrieveNotificationListAsync(userId);
        }
    }
}
