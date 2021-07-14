using Academy.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class TeacherView : Teacher
    {
        public string DisplayName { get; set; }
    }
}
