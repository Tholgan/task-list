using System;

namespace Tasks
{
	public interface IConsole
	{
		void WriteLine(string format, params object[] args);

		void WriteLine();
	}
}
