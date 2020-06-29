using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class AddCommand : Command
    {
        public override void Action(string[] commandLine)
        {
			var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
			if (subcommandRest[0] == "project")
			{
				AddProject(subcommandRest[1]);
			}
			else if (subcommandRest[0] == "task")
			{
				var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
				AddTask(projectTask[0], projectTask[1]);
			}
		}
    }
}
