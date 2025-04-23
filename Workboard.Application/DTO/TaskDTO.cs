using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.Entities;

namespace Workboard.Application.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime DueDate { get; set; }
        public string MemberAssigned { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ProjectId { get; set; }

        public int CreatedById { get; set; }
    }
}
