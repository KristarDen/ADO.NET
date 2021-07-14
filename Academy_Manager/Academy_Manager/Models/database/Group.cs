using System;
using System.Collections.Generic;

#nullable disable

namespace Academy.Models.db
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
