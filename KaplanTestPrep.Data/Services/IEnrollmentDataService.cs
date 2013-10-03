using System;
using System.Collections.Generic;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	public interface IEnrollmentDataService {
		EnrollmentData GetEnrollment(int enrollmentId);
		EnrollmentData GetEnrollment(int courseId, int studentId);
		EnrollmentData GetEnrollment(string studentFirstName, string studentLastName, string courseTitle);
		void AddEnrollment(EnrollmentData enrollmentData);
		void DeleteEnrollment(int enrollmentId);
		void DeleteEnrollment(int courseId, int studentId);
		bool UpdateEnrollment(EnrollmentData enrollmentData);
		void DeleteAll();
		IEnumerable<EnrollmentData> GetAllEnrollments();
		int GetNumberEnrolled(string courseTitle);
	}
}
