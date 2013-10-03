using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Core;

namespace KaplanTestPrep.Services {
	public class ConsoleDataService {

		private SimpleDataManagerService dataService;
		private static ConsoleDataService consoleService = new ConsoleDataService();

		private ConsoleDataService() {
			dataService = new SimpleDataManagerService();	
		}

		public static ConsoleDataService Instance {
			get {
				return consoleService;
			}
		}

		public void AddStudent(string firstName, string lastName) {
			if (dataService.StudentExists(firstName, lastName)) {

			} else {
				dataService.AddStudent(firstName, lastName);
			}
		}

	}
}
