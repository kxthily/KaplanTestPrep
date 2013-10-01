using System;
using System.Collections.Generic;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	interface IEnrollmentDataService {
		EnrollmentData GetEnrollment(int enrollmentId);
		EnrollmentData GetEnrollment(int courseId, int studentId);
		void AddEnrollment(EnrollmentData enrollmentData);
		void DeleteEnrollment(int enrollmentId);
		void DeleteEnrollment(int courseId, int studentId);
		bool UpdateEnrollment(EnrollmentData enrollmentData);
		void DeleteAll();
		IEnumerable<EnrollmentData> GetAllEnrollments();
		IEnumerable<EnrollmentData> GetAllEnrollmentsForStudent(int studentId);
		IEnumerable<EnrollmentData> GetAllEnrollmentsForCourse(int courseId);
	}
}
