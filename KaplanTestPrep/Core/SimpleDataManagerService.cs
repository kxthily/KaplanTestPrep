using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data;
using KaplanTestPrep.Data.Services;
using KaplanTestPrep.Data.Models;
using KaplanTestPrep.Data.Services.Implementations;

namespace KaplanTestPrep.Core {
	public class SimpleDataManagerService : DataManagerService {
		
		private static IStudentDataService _studentService = new SimpleStudentDataService();
		private static ICourseDataService _courseService = new SimpleCourseDataService();
		private static IEnrollmentDataService _enrollmentService = new SimpleEnrollmentDataService();
		//private static readonly SimpleDataManagerService _dataService = new SimpleDataManagerService(_studentService, _courseService, _enrollmentService);

		private SimpleDataManagerService(IStudentDataService studentService, ICourseDataService courseService, IEnrollmentDataService enrollmentService)
			: base(studentService, courseService, enrollmentService) {
		}

		public SimpleDataManagerService() : this(_studentService, _courseService, _enrollmentService) { }

		public override IEnumerable<CourseData> GetAllCourses() {
			return base.GetAllCourses().OrderBy(x => x.Title);
		}

		public override IEnumerable<StudentData> GetAllStudents() {
			return base.GetAllStudents().OrderBy(x => x.DateCreated);
		}
	}
}
