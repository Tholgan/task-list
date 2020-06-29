using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class Startup
    {
        public static void Main()
        {
            new TaskList(new RealConsole()).Run();
        }
    }
}
