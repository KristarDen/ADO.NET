using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.Views
{
    public interface ITeacherView
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? Birthday { get; set; }
        Object dataGridViewSource { get; set; }
        Object dataGridViewCurrentRowData { get; }
    }
}
