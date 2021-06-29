using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow_Core_Demo.DependencyInjection
{
    public class DoSomething : StepBody
    {

        private IMyService _service;

        public DoSomething(IMyService service)
        {
            _service = service;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            _service.DoStuff();
            return ExecutionResult.Next();
        }
    }
}
