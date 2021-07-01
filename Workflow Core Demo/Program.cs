using Microsoft.Extensions.DependencyInjection;
using System;
using Workflow_Core_Demo.DependencyInjection;
using Workflow_Core_Demo.EventWorkflow;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            var workflowHost = serviceProvider.GetService<IWorkflowHost>();
            workflowHost.RegisterWorkflow<EventSampleWorkflow, SampleDataClass>();
            workflowHost.Start();

            SampleDataClass initialData = new SampleDataClass();

            var workflowId = workflowHost.StartWorkflow("EventSample", 1, initialData).Result;

            Console.WriteLine("Enter value to publish");
            string value = Console.ReadLine();
            workflowHost.PublishEvent("SomeEvent", workflowId, value);

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
