using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaplanTestPrep.Data.Models {
	class CourseData {
		public int CourseId { get; internal set; }
		public String Title { get; set; }
		public DateTime StartDate { get; set; }
		public int? MaxEnrollmentCount { get; set; }
	}
}
