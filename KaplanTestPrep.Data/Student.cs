//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KaplanTestPrep.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }
    
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
