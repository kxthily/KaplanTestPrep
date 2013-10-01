using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services {
	interface IStudentDataService {
		StudentData GetStudent(int studentId);
		void AddStudent(StudentData student);
		void DeleteStudent(int studentId);
		//bool UpdateStudent(StudentData student);
		IEnumerable<StudentData> GetAllStudents();
		
	}
}
