using System;
using System.Collections.Generic;

#nullable disable

namespace Academy.Models.db
{
    public partial class Mark
    {
        public int IdStudent { get; set; }
        public int IdSubject { get; set; }
        public byte Value { get; set; }
        public DateTime Date { get; set; }

        public virtual Student IdStudentNavigation { get; set; }
        public virtual Subject IdSubjectNavigation { get; set; }
    }
}
