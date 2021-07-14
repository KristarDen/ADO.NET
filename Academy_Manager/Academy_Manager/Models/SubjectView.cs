using Academy.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class SubjectView: Subject
    {
        public string TeacherName { get; set; }
    }
}
