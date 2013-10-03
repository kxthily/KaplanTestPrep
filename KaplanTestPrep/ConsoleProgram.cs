using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Core;
using KaplanTestPrep.Data.Services;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep {
	class ConsoleProgram {

		public class Commands {
			public const string LIST_COURSES = "list-courses";
			public const string LIST_STUDENTS = "list-students";
			public const string ADD_STUDENT = "add-student";
			public const string ADD_COURSE = "add-course";
			public const string ADD_ENROLLMENT = "add-enrollment";
			public const string RESET = "reset";
		}

		private static ConsoleProgram program = new ConsoleProgram();
		private HashSet<String> consoleCommands;
		private DataManagerService dataService;

		private ConsoleProgram() {
			dataService = new SimpleDataManagerService();
			consoleCommands = new HashSet<string>();
			AddCommands();
		}

		public static ConsoleProgram Instance {
			get {
				return program;
			}
		}

		public void ExecuteCommand(string command) {
			if (!CommandExists(command)) {
				Console.WriteLine("Invalid command. It does not exist. Press any key to exist.");
			} else {
				switch (command) 
				{
					case Commands.LIST_COURSES:
						ListCourses();
						break;
					case Commands.LIST_STUDENTS:
						ListStudents();
						break;
					case Commands.ADD_STUDENT:
						AddStudent();
						break;
					case Commands.ADD_COURSE:
						AddCourse();
						break;
					default:
						Console.WriteLine("default");
						break;
				}
			}
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		public void SetDataManagerService(DataManagerService dataService) {
			this.dataService = dataService;
		}

		private void ListCourses() {
			List<CourseData> courses = dataService.GetAllCourses().ToList();
			if (courses != null && courses.Count > 0) {
				foreach (CourseData course in courses) {
					Console.WriteLine(course.Title);
				}
			} else {
				Console.WriteLine("There are no courses.");
			}
		}

		private void ListStudents() {
			List<StudentData> students = dataService.GetAllStudents().ToList();
			if (students != null && students.Count > 0) {
				foreach (StudentData student in students) {
					Console.WriteLine(student.LastName + ", " + student.FirstName);
				}
			} else {
				Console.WriteLine("There are no students.");
			}
		}

		private void AddStudent() {
			Console.WriteLine("Please enter the student's first and last name in this format and press enter:");
			Console.WriteLine("Mary Sue");
			string enteredName = Console.ReadLine();
			string[] fullName = enteredName.Split(' ');
			if (fullName.Length != 2) {
				Console.WriteLine("Invalid input. Please try again.");
				return;
			}

			if (dataService.StudentExists(fullName[0], fullName[1])) {
				Console.WriteLine("This student already exists in the database. Please try again.");
				return;
			}

			dataService.AddStudent(fullName[0], fullName[1]);
			Console.WriteLine("Entry saved.");
		}

		private void AddCourse() {
			Console.WriteLine("Please enter the course title and press enter.");
			string enteredTitle = Console.ReadLine();
			Console.WriteLine("Please enter the course start date in this format and press enter:");
			Console.WriteLine("mm/dd/yyyy");
			string enteredDate = Console.ReadLine();
			string[] date = enteredDate.Split('/');
			
			if (date.Length == 3) {
				foreach (string digits in date) {
					int num;
					if (!int.TryParse(digits, out num)) {
						Console.WriteLine("Invalid input. Please try again.");
						return;
					}
				}
			} else {
				Console.WriteLine("Invalid input. Please try again.");
				return;
			}

			Console.WriteLine("Is there a maximum enrollment count? y/n");
			string enteredValue = Console.ReadLine();
			if (enteredValue == "y") {
				Console.WriteLine("Please enter the maximum enrollment count and press enter.");
				int count;
				enteredValue = Console.ReadLine();
				if (int.TryParse(enteredValue, out count)) {
					dataService.AddCourse(enteredTitle, DateTime.Parse(enteredDate).Date, count);

				} else {
					Console.WriteLine("Invalid input. Please try again.");
					return;
				}
			} else if (enteredValue == "n") {
				dataService.AddCourse(enteredTitle, DateTime.Parse(enteredDate).Date);
			} else {
				Console.WriteLine("Invalid input. Please try again.");
				return;
			}
			Console.WriteLine("Entry saved.");
		}

		private void AddEnrollment() {
			Console.WriteLine("Please enter the student's first and last name in this format and press enter:");
			Console.WriteLine("Mary Sue");
			string enteredName = Console.ReadLine();
			string[] fullName = enteredName.Split(' ');
			if (fullName.Length != 2) {
				Console.WriteLine("Invalid input. Please try again.");
				return;
			}

			if (!dataService.StudentExists(fullName[0], fullName[1])) {
				Console.WriteLine("This student does not exist in the database. Please try again.");
				return;
			}

			Console.WriteLine("Please enter the course title.");
			string enteredCourse = Console.ReadLine();

			CourseData course = dataService.GetCourse(enteredCourse);

			if (course == null) {
				Console.WriteLine("This course does not exist in the database. Please try again.");
				return;
			}

			if (course.MaxEnrollmentCount < dataService.GetEnrollmentCount(enteredCourse) + 1) {
				Console.WriteLine("Matching course has exceeded maximum enrollment count.");
				return;
			}

			if (course.StartDate < DateTime.UtcNow.Date) {
				Console.WriteLine("Matching course start date has passed.");
				return;
			}

			dataService.AddEnrollment(fullName[0], fullName[1], course.Title);
			Console.WriteLine("Entry saved");
		}

		private void Reset() {
			dataService.Reset();
			Console.WriteLine("Database cleared.");
		}

		private bool ProcessStudentName(string fullName) {
			string[] names = fullName.Split(' ');
			if (names.Length == 2) {
				return true;
			}

			return false;
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
