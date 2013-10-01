using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaplanTestPrep.Data.Models {
	class StudentData {
		public int StudentId { get; internal set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
