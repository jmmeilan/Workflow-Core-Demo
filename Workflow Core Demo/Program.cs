using Microsoft.Extensions.DependencyInjection;
using System;
using Workflow_Core_Demo.ActivityWorkers;
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
            workflowHost.RegisterWorkflow<ActivityWorkflow, MyData>();
            workflowHost.Start();

            MyData initialData = new MyData()
            {
                Value1 = "Test"
            };

            workflowHost.StartWorkflow("activitySample", 1, initialData);
            var activity = workflowHost.GetPendingActivity("get-approval", "worker1", TimeSpan.FromMinutes(1)).Result;

            if (activity != null)
            {
                Console.WriteLine($"Approval required for {activity.Parameters}");
                workflowHost.SubmitActivitySuccess(activity.Token, "Approved activity");
            }

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
