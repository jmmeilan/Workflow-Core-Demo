using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow_Core_Demo.EventWorkflow
{
    public class EventSampleWorkflow : IWorkflow<SampleDataClass>
    {
        public string Id => "EventSample";

        public int Version => 1;

        public void Build(IWorkflowBuilder<SampleDataClass> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next())
                .WaitFor("SomeEvent", (data, context) => context.Workflow.Id, data => DateTime.Now)
                    .Output(data => data.Value1, step => step.EventData)
                .Then<CustomMessageStep>()
                    .Input(step => step.Message, data => $"The data from the event is {data.Value1}")
                .Then(context => Console.WriteLine("Workflow complete"));
        }
    }
}
