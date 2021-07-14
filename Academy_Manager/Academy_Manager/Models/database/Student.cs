using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace Academy.Models.db
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Mark>();
        }
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int IdGroup { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
