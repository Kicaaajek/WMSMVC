using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.Services;

namespace WMSMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IItemService, ItemService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
