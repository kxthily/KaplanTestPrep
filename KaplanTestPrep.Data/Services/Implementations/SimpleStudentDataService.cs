using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KaplanTestPrep.Data.Models;

namespace KaplanTestPrep.Data.Services.Implementations {
	public class SimpleStudentDataService : IStudentDataService {
		
		public StudentData GetStudent(int studentId) {
			StudentData studentData = null;

			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Student student = con.Students.Where(x => x.StudentId == studentId).FirstOrDefault();
				if (student != null) {
					studentData.StudentId = student.StudentId;
					studentData.FirstName = student.FirstName;
					studentData.LastName = student.LastName;
					studentData.DateCreated = student.DateCreated;
				}
			}
			return studentData;
		}

		public StudentData GetStudent(string FirstName, string LastName) {
			StudentData studentData = null;

			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var student = con.Students.Where(x => x.FirstName == FirstName && x.LastName == LastName).FirstOrDefault();
				
				if (student != null) {
					studentData.StudentId = student.StudentId;
					studentData.FirstName = student.FirstName;
					studentData.LastName = student.LastName;
					studentData.DateCreated = student.DateCreated;		
				}
			}
			return studentData;
		}

		public void AddStudent(StudentData studentData) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Student student = new Student {
					FirstName = studentData.FirstName,
					LastName = studentData.LastName,
					DateCreated = studentData.DateCreated
				};
				con.Students.Add(student);
				con.SaveChanges();
			}
		}

		public void DeleteStudent(int studentId) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Student student = con.Students.Where(x => x.StudentId == studentId).FirstOrDefault();
				if (student != null) {
					con.Students.Remove(student);
					con.SaveChanges();
				}
			}
		}

		public bool UpdateStudent(StudentData studentData) {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				Student student = con.Students.Where(x => x.StudentId == studentData.StudentId).FirstOrDefault();
				if (student != null) {
					student.FirstName = studentData.FirstName;
					student.LastName = studentData.LastName;
					student.DateCreated = studentData.DateCreated;

					con.SaveChanges();
					return true;
				}
			}
			return false;
		}

		public IEnumerable<StudentData> GetAllStudents() {
			List<StudentData> allStudents = new List<StudentData>();
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var students = con.Students;
				if (students != null) {
					foreach (Student s in students) {
						allStudents.Add(new StudentData {
							StudentId = s.StudentId,
							FirstName = s.FirstName,
							LastName = s.LastName,
							DateCreated = s.DateCreated
						});
					}
				}
				return allStudents;
			}
		}

		public void DeleteAll() {
			using (KaplanTestPrepEntities con = new KaplanTestPrepEntities()) {
				var students = con.Students;
				if (students != null) {
					foreach (Student s in students) {
						con.Students.Remove(s);
					}
					con.SaveChanges();
				}
			}
		}
	}
}
