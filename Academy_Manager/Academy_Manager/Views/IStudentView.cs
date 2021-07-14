using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.Views
{
    public interface IStudentView
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? Birthday { get; set; }
        Object DataGridViewSource { get; set; }
        Object DataGridViewCurrentRowData { get; }
        Object CmbBoxGroupsViewSource { get; set; }
        Object CmbBoxGroupsViewSelectedValue { get; set; }
        string Search { get; set; }
    }

    public interface IMarkStudentView
    {
        Object SubjCmbBoxViewSource { get; set; }
        Object SubjCmbBoxViewSelectedValue { get; set; }
        int? MarkValue { get; set; }
        DateTime? MarkDate { get; set; }
        Object MarkDataGridViewSource { get; set; }
        Object MarkDataGridViewCurrentRowData { get; }
    }

    
}
