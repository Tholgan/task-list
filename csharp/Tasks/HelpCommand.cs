﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    class HelpCommand
    {
		public void Action()
		{
			Console.WriteLine("Commands:");
			Console.WriteLine("  show");
			Console.WriteLine("  add project <project name>");
			Console.WriteLine("  add task <project name> <task description>");
			Console.WriteLine("  check <task ID>");
			Console.WriteLine("  uncheck <task ID>");
			Console.WriteLine();
		}
	}
}
