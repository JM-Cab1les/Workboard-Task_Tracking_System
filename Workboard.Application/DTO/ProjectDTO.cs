using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.Entities;

namespace Workboard.Application.DTO
{
    public class ProjectDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int CreatedById { get; set; }

        public DateTime CreatedDate { get; set; }

        //public virtual User CreatedBy { get; set; }

        //public virtual ICollection<TaskDTO> Tasks { get; set; } = new List<TaskDTO>();
    }
}
