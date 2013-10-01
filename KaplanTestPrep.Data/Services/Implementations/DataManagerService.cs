using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	public class DataManagerService {

		protected internal IStudentDataService studentService;
		protected internal ICourseDataService courseService;
		protected internal IEnrollmentDataService enrollmentService;

		protected internal DataManagerService(IStudentDataService studentService, ICourseDataService courseService,
									IEnrollmentDataService enrollmentService) {
			this.studentService = studentService;
			this.courseService = courseService;
			this.enrollmentService = enrollmentService;
		}

		protected virtual IEnumerable<CourseData> GetAllCourses() {
			return courseService.GetAllCourses();
		}

		protected virtual IEnumerable<StudentData> GetAllStudents() {
			return studentService.GetAllStudents();
		}

		protected virtual void AddStudent(StudentData studentData) {
			studentService.AddStudent(studentData);
		}

		protected virtual void AddCourse(CourseData courseData) {
			courseService.AddCourse(courseData);
		}

		protected virtual void AddEnrollment(EnrollmentData enrollmentData) {
			enrollmentService.AddEnrollment(enrollmentData);
		}

		protected virtual void Reset() {
			enrollmentService.DeleteAll();
			courseService.DeleteAll();
			studentService.DeleteAll();
		}
	}
}
