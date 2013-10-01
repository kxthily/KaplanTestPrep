using System;
using System.Collections.Generic;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	interface IEnrollmentDataService {
		EnrollmentData GetEnrollment(int enrollmentId);
		void AddEnrollment(EnrollmentData enrollmentData);
		void DeleteEnrollment(int enrollmentId);
		bool UpdateEnrollment(EnrollmentData enrollmentData);
		void DeleteAll();
		IEnumerable<EnrollmentData> GetAllEnrollments();
		IEnumerable<EnrollmentData> GetAllEnrollmentsForStudent(int studentId);
		IEnumerable<EnrollmentData> GetAllEnrollmentsForCourse(int courseId);
	}
}
