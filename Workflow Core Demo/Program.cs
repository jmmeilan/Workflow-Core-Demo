using Microsoft.Extensions.DependencyInjection;
using System;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            var workflowHost = serviceProvider.GetService<IWorkflowHost>();
            workflowHost.RegisterWorkflow<PassingDataWorkflow, DataClass>();
            workflowHost.Start();

            DataClass initialData = new DataClass
            {
                Value1 = 2,
                Value2 = 3
            };

            workflowHost.StartWorkflow("PassingData", 1, initialData);

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
