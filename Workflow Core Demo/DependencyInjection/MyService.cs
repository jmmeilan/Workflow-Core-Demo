using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_Core_Demo.DependencyInjection
{
    public class MyService : IMyService
    {
        public void DoStuff()
        {
            Console.WriteLine("Doing stuff...");
        }
    }
}
