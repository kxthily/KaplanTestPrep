using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services.Implementations {
	public class SimpleEnrollmentDataService : IEnrollmentDataService {
		
		public EnrollmentData GetEnrollment(int enrollmentId) {
			EnrollmentData enrollmentData = null;

			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var enrollment = con.Enrollments.Where(x => x.EnrollmentId == enrollmentId).FirstOrDefault();
				if (enrollment != null) {
					enrollmentData.EnrollmentId = enrollment.EnrollmentId;
					enrollmentData.StudentId = (int) enrollment.StudentId;
					enrollmentData.CourseId = (int) enrollment.CourseId;
				}
			}
			return enrollmentData;
		}

		public EnrollmentData GetEnrollment(int courseId, int studentId) {
			EnrollmentData enrollmentData = null;

			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var enrollment = con.Enrollments.Where(x => x.CourseId == courseId && x.StudentId == studentId).FirstOrDefault();
				if (enrollment != null) {
					enrollmentData.EnrollmentId = enrollment.EnrollmentId;
					enrollmentData.StudentId = (int) enrollment.StudentId;
					enrollmentData.CourseId = (int) enrollment.CourseId;
				}
			}
			return enrollmentData;
		}

		public EnrollmentData GetEnrollment(string studentFirstName, string studentLastName, string courseTitle) {
			EnrollmentData enrollmentData = null;
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var student = con.Students.Where(x => x.FirstName.ToLower() == studentFirstName.ToLower()
														&& x.LastName.ToLower() == studentLastName.ToLower()).FirstOrDefault();

				Course course = con.Courses.Where(x => x.Title.ToLower() == courseTitle.ToLower()).FirstOrDefault();
				if (student != null && course != null) {
					var enrollment = con.Enrollments.Where(x => x.StudentId == student.StudentId
																	&& x.CourseId == course.CourseId).FirstOrDefault();
					enrollmentData.EnrollmentId = enrollment.EnrollmentId;
					enrollmentData.StudentId = (int) enrollment.StudentId;
					enrollmentData.CourseId = enrollmentData.CourseId;
				}
			}
			return enrollmentData;
		}

		public void AddEnrollment(EnrollmentData enrollmentData) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {

				var enrollment = new Enrollment {
					CourseId = enrollmentData.CourseId,
					StudentId = enrollmentData.StudentId
				};
				con.Enrollments.Add(enrollment);
				con.SaveChanges();
			}
		}

		public void DeleteEnrollment(int enrollmentId) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var enrollment = con.Enrollments.Where(x => x.EnrollmentId == enrollmentId).FirstOrDefault();
				if (enrollment != null) {
					con.Enrollments.Remove(enrollment);
					con.SaveChanges();
				}
			}
		}

		public void DeleteEnrollment(int courseId, int studentId) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var enrollment = con.Enrollments.Where(x => x.CourseId == courseId && x.StudentId == studentId).FirstOrDefault();
				if (enrollment != null) {
					con.Enrollments.Remove(enrollment);
					con.SaveChanges();
				}
			}
		}

		public bool UpdateEnrollment(EnrollmentData enrollmentData) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var enrollment = con.Enrollments.Where(x => x.EnrollmentId == enrollmentData.EnrollmentId).FirstOrDefault();
				if (enrollment != null) {
					enrollment.StudentId = enrollmentData.StudentId;
					enrollment.CourseId = enrollmentData.CourseId;
					con.SaveChanges();
					return true;
				}
			}
			return false;
		}

		public void DeleteAll() {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var enrollments = con.Enrollments;
				if (enrollments != null) {
					foreach (var e in enrollments) {
						con.Enrollments.Remove(e);
					}
					con.SaveChanges();
				}
			}
		}

		public IEnumerable<EnrollmentData> GetAllEnrollments() {
			List<EnrollmentData> allEnrollments = new List<EnrollmentData>();
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var enrollments = con.Enrollments;
				if (enrollments != null) {
					foreach (var e in enrollments) {
						allEnrollments.Add(new EnrollmentData {
							EnrollmentId = e.EnrollmentId,
							StudentId = (int) e.StudentId,
							CourseId = (int) e.CourseId
						});
					}
				}
			}
			return allEnrollments;
		}

		public int GetNumberEnrolled(string courseTitle) {
			
			int enrollmentCount = 0;

			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var course = con.Courses.Where(x => x.Title.ToLower() == courseTitle.ToLower()).FirstOrDefault();
				if (course != null) {
					enrollmentCount = course.Enrollments.Count();
				}
			}
			return enrollmentCount;
		}
	}
}
