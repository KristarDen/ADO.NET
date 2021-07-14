using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.Views
{
    public interface ISubjectView
    {
        string NameSubject { get; set; }
        int Duration { get; set; }
        Object dataGridViewSource { get; set; }
        Object dataGridViewCurrentRowData { get; }
        Object cmbBoxTeachersViewSource { get; set; }
        Object cmbBoxTeachersViewSelectedValue { get; set; }
    }
}
