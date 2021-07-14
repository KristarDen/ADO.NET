using System;
using System.Collections.Generic;

#nullable disable

namespace Academy.Models.db
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
