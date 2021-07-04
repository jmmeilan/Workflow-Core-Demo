using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.ControlStructures
{
    public class ParallelPaths : IWorkflow<DataClass>
    {
        public string Id => "ParallelPaths";

        public int Version => 1;

        public void Build(IWorkflowBuilder<DataClass> builder)
        {
            builder
                .Parallel()
                    .Do(then =>
                        then.StartWith<CustomMessageStep>()
                                .Input(step => step.Message, data => "Item 1.1")
                            .Then<CustomMessageStep>()
                                .Input(step => step.Message, data => "Item 1.2"))
                    .Do(then =>
                        then.StartWith<CustomMessageStep>()
                                .Input(step => step.Message, data => "Item 2.1")
                            .Then<CustomMessageStep>()
                                .Input(step => step.Message, data => "Item 2.2")
                            .Then<CustomMessageStep>()
                                .Input(step => step.Message, data => "Item 2.3"))
                    .Do(then =>
                        then.StartWith<CustomMessageStep>()
                                .Input(step => step.Message, data => "Item 3.1")
                            .Then<CustomMessageStep>()
                                .Input(step => step.Message, data => "Item 3.2"))
                .Join()
                .Then<CustomMessageStep>()
                    .Input(step => step.Message, data => "Finished");
        }
    }
}
