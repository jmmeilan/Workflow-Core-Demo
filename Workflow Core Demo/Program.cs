using Microsoft.Extensions.DependencyInjection;
using System;
using Workflow_Core_Demo.ActivityWorkers;
using Workflow_Core_Demo.ControlStructures;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            var workflowHost = serviceProvider.GetService<IWorkflowHost>();
            workflowHost.RegisterWorkflow<ScheduleWorkflow, DataClass>();
            workflowHost.Start();

            workflowHost.StartWorkflow("ScheduleWorkflow", 1, new DataClass { Value1 = 0 });

            Console.ReadLine();
            workflowHost.Stop();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
