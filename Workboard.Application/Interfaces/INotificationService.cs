using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.SPEntity;

namespace Workboard.Application.Interfaces
{
    public interface INotificationService
    {
        public Task<List<spRetrieveNotificationListResult>> GetNotificationList(int userId);
    }
}
