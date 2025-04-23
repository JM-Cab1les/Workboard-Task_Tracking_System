using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workboard.Application.Interfaces;
using Workboard.Application.Services;
using Workboard.Domain.Interfaces;
using Workboard.Infrastructure.Repositories;
using Workboard.Infratsructure.Contexts;

namespace Workboard.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection InitializedDbConnection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Workboard_DBContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}
