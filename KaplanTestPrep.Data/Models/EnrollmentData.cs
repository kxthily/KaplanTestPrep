﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaplanTestPrep.Data.Models {
	public class EnrollmentData {
		public int EnrollmentId { get; internal set; }
		public int StudentId { get; set; }
		public int CourseId { get; set; }
	}
}
