using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	interface IDataManagerService {
		IEnumerable<CourseData> GetAllCourses();
		IEnumerable<StudentData> GetAllStudents();
		void AddStudent(StudentData studentData);
		void AddCourse(CourseData courseData);
		void AddEnrollment(EnrollmentData enrollmentData);
		void Reset();
	}
}
