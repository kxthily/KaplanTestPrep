﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaplanTestPrep {
	class Program {
		static void Main(string[] args) {
			ConsoleProgram program = ConsoleProgram.Instance;
			program.ExecuteCommand("add-course");
		}
	}
}
