using System;
using System.Collections.Generic;

#nullable disable

namespace Academy.Models.db
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte Duration { get; set; }
        public int IdTeacher { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
