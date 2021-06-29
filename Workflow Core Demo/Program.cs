using Microsoft.Extensions.DependencyInjection;
using System;
using Workflow_Core_Demo.DependencyInjection;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            var workflowHost = serviceProvider.GetService<IWorkflowHost>();
            workflowHost.RegisterWorkflow<DependencyInjectionWorkflow>();
            workflowHost.Start();

            //DataClass initialData = new DataClass
            //{
            //    Value1 = 2,
            //    Value2 = 3
            //};

            workflowHost.StartWorkflow("DI", 1, null);

            Console.ReadLine();
            
            workflowHost.Stop();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            services.AddTransient<DoSomething>();
            services.AddTransient<IMyService, MyService>();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
