using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	public interface IStudentDataService {
		StudentData GetStudent(int studentId);
		StudentData GetStudent(string FirstName, string LastName);
		void AddStudent(StudentData studentData);
		void DeleteStudent(int studentId);
		bool UpdateStudent(StudentData studentData);
		IEnumerable<StudentData> GetAllStudents();
		void DeleteAll();
	}
}
