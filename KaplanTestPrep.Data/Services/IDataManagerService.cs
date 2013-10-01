using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	interface IDataManagerService {
		IEnumerable<CourseData> GetAllCourses();
		IEnumerable<StudentData> GetAllStudents();
		void AddStudent(StudentData student);
		void AddCourse(CourseData course);
		void AddEnrollment(EnrollmentData enrollment);
		bool Reset();
	}
}
