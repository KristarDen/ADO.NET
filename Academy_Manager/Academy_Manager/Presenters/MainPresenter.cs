using Academy.Models.db;
using Academy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.Presenters
{
    public class MainPresenter
    {
        private AcademyContext database = new AcademyContext();
        IMainView mainView;

        public MainPresenter(IMainView view)
        {
            mainView = view;
        }

        public void DataToGrig()
        {
            if (mainView.CmbBoxGroupViewSourse == null) return;

            Group group = mainView.CmbBoxGroupViewSelectedItem as Group;

            if (group == null) return;

            var students = from st in database.Students
                           orderby st.FirstName
                           where st.IdGroup == @group.Id
                           select st;

            if (students != null && students.Count() > 0)
            {
                mainView.DataGridViewSourse = students.ToList();
            }

            else
            {
                mainView.DataGridViewSourse = null;
            }
        }

        private void DataToCombo()
        {
            var groups = from grp in database.Groups 
                         orderby grp.Name
                         select grp;

            if (groups != null && groups.Count() > 0)
            { 
                mainView.CmbBoxGroupViewSourse = groups.ToList(); 
            } 
            else
            {
                mainView.CmbBoxGroupViewSourse = null;
            }
                
        }

        public void LoadData()
        {
            DataToCombo();
            DataToGrig();
        }

    }
}
