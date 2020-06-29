using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class TaskList
	{

		private readonly IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();

		private long lastId = 0;

		public void Run()
		{
			while (true) {
				Console.Write("> ");
				var command = Console.ReadLine();
				if (command == "quit") {
					break;
				}
				Execute(command);
			}
		}

		private void Execute(string commandLine)
		{
			var commandRest = commandLine.Split(" ".ToCharArray(), 2);
			switch (commandRest[0]) {
			case "show":
				Show();
				break;
			case "add":
				Add(commandRest[1]);
				break;
			case "check":
				Check(commandRest[1]);
				break;
			case "uncheck":
				Uncheck(commandRest[1]);
				break;
			case "help":
				Help();
				break;
			default:
				Error(commandRest[0]);
				break;
			}
		}

		private void Show()
		{
			foreach (var project in tasks) {
				Console.WriteLine(project.Key);
				foreach (var task in project.Value) {
					Console.WriteLine("    [{0}] {1}: {2}", (task.Done ? 'x' : ' '), task.Id, task.Description);
				}
				Console.WriteLine();
			}
		}

		private void Add(string commandLine)
		{
			var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
			if (subcommandRest[0] == "project") {
				AddProject(subcommandRest[1]);
			} else if (subcommandRest[0] == "task") {
				var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
				AddTask(projectTask[0], projectTask[1]);
			}
		}

		private void AddProject(string name)
		{
			tasks[name] = new List<Task>();
		}

		private void AddTask(string project, string description)
		{
			if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
			{
				Console.WriteLine("Could not find a project with the name \"{0}\".", project);
				return;
			}
			projectTasks.Add(new Task { Id = NextId(), Description = description, Done = false });
		}

		private void Check(string idString)
		{
			SetDone(idString, true);
		}

		private void Uncheck(string idString)
		{
			SetDone(idString, false);
		}

		private void SetDone(string idString, bool done)
		{
			int id = int.Parse(idString);
			var identifiedTask = tasks
				.Select(project => project.Value.FirstOrDefault(task => task.Id == id))
				.Where(task => task != null)
				.FirstOrDefault();
			if (identifiedTask == null) {
				Console.WriteLine("Could not find a task with an ID of {0}.", id);
				return;
			}

			identifiedTask.Done = done;
		}

		private void Help()
		{
			Console.WriteLine("Commands:");
			Console.WriteLine("  show");
			Console.WriteLine("  add project <project name>");
			Console.WriteLine("  add task <project name> <task description>");
			Console.WriteLine("  check <task ID>");
			Console.WriteLine("  uncheck <task ID>");
			Console.WriteLine();
		}

		private void Error(string command)
		{
			Console.WriteLine("I don't know what the command \"{0}\" is.", command);
		}

		private long NextId()
		{
			return ++lastId;
		}
	}
}
