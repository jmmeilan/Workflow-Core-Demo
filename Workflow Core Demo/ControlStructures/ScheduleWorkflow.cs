using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.ControlStructures
{
    public class ScheduleWorkflow : IWorkflow <DataClass>
    {
        public string Id => "ScheduleWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<DataClass> builder)
        {
            builder
                .StartWith(context => Console.WriteLine("Hello"))
                .Schedule(data => TimeSpan.FromSeconds(10)).Do(schedule => schedule
                    .StartWith(context => Console.WriteLine("Doing scheduled tasks"))
                )
                .Delay(data => TimeSpan.FromSeconds(15))
                .Then(context => Console.WriteLine("Doing normal tasks"))
                .Recur(data => TimeSpan.FromSeconds(3), data => data.Value1 > 5).Do(recur => recur
                    .StartWith(context => Console.WriteLine("Doing recurring task"))
                    .Then<IncrementStep>()
                        .Input(step => step.Value1, data => data.Value1)
                        .Output(data => data.Value1, step => step.Value2)
                )
                .Then(context => Console.WriteLine("Doing normal tasks"));
        }
    }
}
