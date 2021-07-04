using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.ControlStructures
{
    public class IfWorkflow : IWorkflow<DataClass>
    {
        public string Id => "IfWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<DataClass> builder)
        {
            builder
                .If(data => data.Value1 < 3).Do(then =>
                    then.StartWith<CustomMessageStep>()
                        .Input(step => step.Message, data => "Value less than 3")
                )
                .If(data => data.Value1 > 3).Do(then =>
                    then.StartWith<CustomMessageStep>()
                        .Input(step => step.Message, data => "Value greater than 3")
                );
        }
    }
}
