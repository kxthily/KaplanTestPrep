using System.Collections.Generic;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	public interface ICourseDataService {
		CourseData GetCourse(int courseId);
		CourseData GetCourse(string courseTitle);
		void AddCourse(CourseData courseData);
		void DeleteCourse(int courseId);
		bool UpdateCourse(CourseData courseData);
		IEnumerable<CourseData> GetAllCourses();
		void DeleteAll();
	}
}
