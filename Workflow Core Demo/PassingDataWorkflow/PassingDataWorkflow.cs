using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo
{
    public class PassingDataWorkflow : IWorkflow<DataClass>
    {
        public string Id => "PassingData";

        public int Version => 1;

        public void Build(IWorkflowBuilder<DataClass> builder)
        {
            builder
                .StartWith<AddNumbers>()
                    .Input(step => step.Input1, data => data.Value1)
                    .Input(step => step.Input2, data => data.Value2)
                    .Output(data => data.Answer, step => step.Output)
                .Then<CustomMessageStep>()
                    .Input(step => step.Message, data => $"The answer is {data.Answer.ToString()}");

        }
    }
}
