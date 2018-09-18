namespace Employees.App
{
    using Employees.Data;
    using Employees.Services;

    using AutoMapper;
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class StartUp
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();
            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<EmployeesContext>(options =>
                                                        options.UseSqlServer(Configuration.ConnectionString));

            services.AddTransient<EmployeeService>();

            //???
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EmployeesProfile>();
            });

            services.AddAutoMapper(cfg => cfg.AddProfile<EmployeesProfile>());

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}