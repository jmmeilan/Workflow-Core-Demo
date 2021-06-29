using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Workflow_Core_Demo.DependencyInjection
{
    public class DependencyInjectionWorkflow : IWorkflow
    {
        public string Id => "DI";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<DoSomething>();
        }
    }
}
