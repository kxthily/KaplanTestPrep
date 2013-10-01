using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	class DataManagerService : IDataManagerService {

		protected IStudentDataService studentService;
		protected ICourseDataService courseService;
		protected IEnrollmentDataService enrollmentService;

		public DataManagerService(IStudentDataService studentService, ICourseDataService courseService,
									IEnrollmentDataService enrollmentService) {
			this.studentService = studentService;
			this.courseService = courseService;
			this.enrollmentService = enrollmentService;
		}

		public IEnumerable<CourseData> GetAllCourses() {
			throw new NotImplementedException();
		}

		public IEnumerable<StudentData> GetAllStudents() {
			throw new NotImplementedException();
		}

		public void AddStudent(StudentData student) {
			throw new NotImplementedException();
		}

		public void AddCourse(CourseData course) {
			throw new NotImplementedException();
		}

		public void AddEnrollment(EnrollmentData enrollment) {
			throw new NotImplementedException();
		}

		public bool Reset() {
			throw new NotImplementedException();
		}

		public void YO() {
		}
	}
}
