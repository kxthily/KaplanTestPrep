using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	public class DataManagerService {

		private IStudentDataService studentService;
		private ICourseDataService courseService;
		private IEnrollmentDataService enrollmentService;

		protected internal DataManagerService(IStudentDataService studentService, ICourseDataService courseService,
									IEnrollmentDataService enrollmentService) {
			this.studentService = studentService;
			this.courseService = courseService;
			this.enrollmentService = enrollmentService;
		}

		public virtual IEnumerable<CourseData> GetAllCourses() {
			return courseService.GetAllCourses();
		}

		public virtual IEnumerable<StudentData> GetAllStudents() {
			return studentService.GetAllStudents();
		}

		public virtual void AddStudent(string firstName, string lastName) {
			StudentData student = new StudentData {
				FirstName = firstName,
				LastName = lastName,
				DateCreated = DateTime.Now.Date
			};
			studentService.AddStudent(student);
		}

		public virtual void AddCourse(string courseTitle, DateTime startDate) {
			CourseData course = new CourseData {
				Title = courseTitle,
				StartDate = startDate
			};
			courseService.AddCourse(course);
		}

		public virtual void AddCourse(string courseTitle, DateTime startDate, int maxEnrollmentCount) {
			CourseData course = new CourseData {
				Title = courseTitle,
				StartDate = startDate,
				MaxEnrollmentCount = maxEnrollmentCount
			};
			courseService.AddCourse(course);
		}

		public virtual void AddEnrollment(string studentFirstName, string studentLastName, string courseTitle) {
			StudentData student = studentService.GetStudent(studentFirstName, studentLastName);
			CourseData course = courseService.GetCourse(courseTitle);
			EnrollmentData enrollment = new EnrollmentData {
				StudentId = student.StudentId,
				CourseId = course.CourseId
			};
			enrollmentService.AddEnrollment(enrollment);
		}

		public void Reset() {
			enrollmentService.DeleteAll();
			courseService.DeleteAll();
			studentService.DeleteAll();
		}

		public virtual StudentData GetStudent(string firstName, string lastName) {
			return studentService.GetStudent(firstName, lastName);
		}

		public virtual CourseData GetCourse(string courseTitle) {
			return courseService.GetCourse(courseTitle);
		}

		public virtual EnrollmentData GetEnrollment(string studentFirstName, string studentLastName, string courseTitle) {
			return enrollmentService.GetEnrollment(studentFirstName, studentLastName, courseTitle);
		}

		public virtual int GetEnrollmentCount(string courseTitle) {
			return enrollmentService.GetNumberEnrolled(courseTitle);
		}

		public virtual bool StudentExists(string firstName, string lastName) {
			return (studentService.GetStudent(firstName, lastName) != null);
		}

		public virtual bool CourseExists(string courseTitle) {
			return (courseService.GetCourse(courseTitle) != null);
		}
	}
}
