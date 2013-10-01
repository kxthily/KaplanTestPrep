using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data;
using KaplanTestPrep.Data.Services;

namespace KaplanTestPrep.Core {
	public class SimpleDataManagerService : DataManagerService {
		private static SimpleDataManagerService _dataService = null;

		private SimpleDataManagerService(IStudentDataService studentService, ICourseDataService courseService, IEnrollmentDataService enrollmentService)
			: base(studentService, courseService, enrollmentService) {
		}

		
	}
}
