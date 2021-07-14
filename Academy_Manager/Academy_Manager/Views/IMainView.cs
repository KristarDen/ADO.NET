using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.Views
{
    public interface IMainView
    {
        Object CmbBoxGroupViewSourse { get; set; }
        Object CmbBoxGroupViewSelectedItem { get; }
        Object DataGridViewSourse { get; set; }
    }
}
