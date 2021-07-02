using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.ActivityWorkers
{
    public class ActivityWorkflow : IWorkflow<MyData>
    {
        public string Id => "activitySample";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MyData> builder)
        {
            builder
                .StartWith<HelloWorld>()
                .Activity("get-approval", (data) => data.Value1)
                    .Output(data => data.Value2, step => step.Result)
                .Then<CustomMessageStep>()
                    .Input(step => step.Message, data => data.Value2);

        }
    }
}
