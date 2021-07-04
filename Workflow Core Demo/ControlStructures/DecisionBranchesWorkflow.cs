using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Core_Demo.ActivityWorkers;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.ControlStructures
{
    public class DecisionBranchesWorkflow : IWorkflow<MyData>
    {
        public string Id => "DecisionBranches";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MyData> builder)
        {
            var branch1 = builder.CreateBranch()
                .StartWith<CustomMessageStep>()
                    .Input(step => step.Message, data => "Test from Branch1");

            var branch2 = builder.CreateBranch()
                .StartWith<CustomMessageStep>()
                    .Input(step => step.Message, data => "Test from Branch2")
                    .Output(data => data.Value2, step => "Output of 2");

            builder
                .Decide(data => data.Value1)
                    .Branch((data, outcome) => data.Value1 == "one", branch1)
                    .Branch((data, outcome) => data.Value1 == "two", branch2)
                .Then<CustomMessageStep>()
                    .Input(step => step.Message, data => data.Value2);
        }
    }
}
