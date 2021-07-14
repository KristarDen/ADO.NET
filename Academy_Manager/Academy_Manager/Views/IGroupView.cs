using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.Views
{
    public interface IGroupView
    {
        string GroupName { get; set; }
        DateTime? Date { get; set; }
        Object dataGridViewSource { get; set; }
        Object dataGridViewCurrentRowData { get; }
    }
}
