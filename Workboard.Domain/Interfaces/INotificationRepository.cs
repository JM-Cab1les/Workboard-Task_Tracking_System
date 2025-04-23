using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.SPEntity;

namespace Workboard.Domain.Interfaces
{
    public interface INotificationRepository
    {
        public Task<List<spRetrieveNotificationListResult>> GetNotificationList(int userId);
    }
}
