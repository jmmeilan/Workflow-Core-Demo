using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.ControlStructures
{
    public class ParallelForEach : IWorkflow
    {
        public string Id => "ParallelForEach";

        public int Version => 1;

        private List<string> _test = new List<string> {
                "Jose Meilan",
                "Jose Luis Meilan",
                "Alejandro Rivero"
        };

        public void Build(IWorkflowBuilder<object> builder)
        {
               builder
                .StartWith<HelloWorld>()
                .ForEach(data => _test)
                    .Do(x => x
                         .StartWith<CustomMessageStep>()
                                .Input(step => step.Message, (data, context) => $"Working on item {context.Item}"))
                .Then<CustomMessageStep>()
                    .Input(step => step.Message, data => "Workflow finished");
        }
    }
}
