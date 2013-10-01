using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services.Implementations {
	class SimpleCourseDataService : ICourseDataService {
		public CourseData GetCourse(int courseId) {
			CourseData courseData = null;
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Course course = con.Courses.Where(x => x.CourseId == courseId).FirstOrDefault();
				if (course != null) {
					courseData.CourseId = course.CourseId;
					courseData.Title = course.Title;
					courseData.StartDate = course.StartDate;
					courseData.MaxEnrollmentCount = course.MaxEnrollmentCount;
				}
			}
			return courseData;
		}

		public CourseData GetCourse(string courseTitle) {
			CourseData courseData = null;
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Course course = con.Courses.Where(x => x.Title == courseTitle).FirstOrDefault();
				if (course != null) {
					courseData.CourseId = course.CourseId;
					courseData.Title = course.Title;
					courseData.StartDate = course.StartDate;
					courseData.MaxEnrollmentCount = course.MaxEnrollmentCount;
				}
			}
			return courseData;
		}

		public void AddCourse(CourseData courseData) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Course course = new Course {
					Title = courseData.Title,
					StartDate = courseData.StartDate,
					MaxEnrollmentCount = courseData.MaxEnrollmentCount
				};
				con.Courses.Add(course);
				con.SaveChanges();
			}
		}

		public void DeleteCourse(int courseId) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Course course = con.Courses.Where(x => x.CourseId == courseId).FirstOrDefault();
				if (course != null) {
					con.Courses.Remove(course);
					con.SaveChanges();
				}
			}
		}

		public bool UpdateCourse(CourseData courseData) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Course course = con.Courses.Where(x => x.CourseId == courseData.CourseId).FirstOrDefault();
				if (course != null) {
					course.Title = courseData.Title;
					course.StartDate = courseData.StartDate;
					course.MaxEnrollmentCount = courseData.MaxEnrollmentCount;

					con.SaveChanges();
					return true;
				}
			}
			return false;
		}

		public IEnumerable<CourseData> GetAllCourses() {
			throw new NotImplementedException();
		}

		public void DeleteAll() {
			throw new NotImplementedException();
		}
	}
}
