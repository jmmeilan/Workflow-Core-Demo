using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Workflow_Core_Demo.ControlStructures
{
    public class IncrementStep : StepBody
    {

        public int Value1 { get; set; }
        public int Value2 { get; set; }


        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Value2 = Value1 + 1;
            return ExecutionResult.Next();
        }
    }
}
