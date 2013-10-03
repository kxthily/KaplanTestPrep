using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaplanTestPrep {
	class ConsoleProgram {

		public class Commands {
			public static readonly string LIST_COURSES = "list-courses";
			public static readonly string LIST_STUDENTS = "list-students";
			public static readonly string ADD_STUDENT = "add-students";
			public static readonly string ADD_COURSE = "add-course";
			public static readonly string ADD_ENROLLMENT = "add-enrollment";
			public static readonly string RESET = "reset";
		}

		private static ConsoleProgram program = new ConsoleProgram();
		private HashSet<String> consoleCommands;

		private ConsoleProgram() {
			consoleCommands = new HashSet<string>();
			AddCommands();
		}

		public static ConsoleProgram Instance {
			get {
				return program;
			}
		}

		private bool CommandExists(string command) {
			return consoleCommands.Contains(command);
		}

		private void AddCommands() {
			if (consoleCommands != null) {
				consoleCommands.Add(Commands.LIST_COURSES);
				consoleCommands.Add(Commands.LIST_STUDENTS);
				consoleCommands.Add(Commands.ADD_STUDENT);
				consoleCommands.Add(Commands.ADD_COURSE);
				consoleCommands.Add(Commands.ADD_ENROLLMENT);
				consoleCommands.Add(Commands.RESET);
			}
		}
	}
}
