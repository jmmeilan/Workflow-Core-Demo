using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Core_Demo.ActivityWorkers;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.ControlStructures
{
    public class WhileWorkflow : IWorkflow<DataClass>
    {
        public string Id => "WhileWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<DataClass> builder)
        {
            builder
                .StartWith<CustomMessageStep>()
                    .Input(step => step.Message, data => "Starting workflow...")
                .While(data => data.Value1 < 3)
                    .Do(x => x
                            .StartWith<CustomMessageStep>()
                                .Input(step => step.Message, data => "Doing something...")
                            .Then<IncrementStep>()
                                .Input(step => step.Value1, data => data.Value1)
                                .Output(data => data.Value1, step => step.Value2)
                    );
        }
    }
}
