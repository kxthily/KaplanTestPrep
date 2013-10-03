using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	interface IDataManagerService {
		IEnumerable<CourseData> GetAllCourses();
		IEnumerable<StudentData> GetAllStudents();
		void AddStudent(string firstName, string lastName);
		void AddCourse(string courseTitle, DateTime startDate);
		void AddCourse(string courseTitle, DateTime startDate, int maxEnrollmentCount);
		void AddEnrollment(string firstName, string lastName, string courseTitle);
		void Reset();
	}
}
