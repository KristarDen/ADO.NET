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
    public class GroupPresenter
    {
        private IGroupView groupView;
        private AcademyContext database = new AcademyContext();

        public GroupPresenter(IGroupView view)
        {
            groupView = view;
        }

        public void DataToGrig()
        {
            var data = from s in database.Groups 
                       orderby s.Name
                       select s;

            if (data != null && data.Count() > 0)
            {
                groupView.dataGridViewSource = data.ToList();
            }
                
            else groupView.dataGridViewSource = null;
        }

        public void LoadData()
        {
            DataToGrig();
        }

        public void getDataFromGrid()
        {
            if (groupView.dataGridViewSource == null) return;

            Group row = groupView.dataGridViewCurrentRowData as Group;

            if (row != null)
            {
                var group = database.Groups.Find(row.Id);
                if (group != null)
                {
                    groupView.GroupName = group.Name;
                    groupView.Date = group.Date.GetValueOrDefault();
                }
            }
        }

        public void saveData()
        {
            try
            {
                Group group = new Group()
                {
                    Name = groupView.GroupName,
                    Date = groupView.Date,
                };

                database.Groups.Add(group);
                database.SaveChanges();
                DataToGrig();
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }

        public void deleteData()
        {
            try
            {
                Group row = groupView.dataGridViewCurrentRowData as Group;

                if (row != null)
                {
                    var result = MessageBox.Show("Are You sure?", "Del", MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes)return;

                    int id = row.Id;
                    Group group = database.Groups.Find(row.Id);

                    database.Groups.Remove(group);
                    database.SaveChanges();
                    DataToGrig();
                }
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }

        public void UpdateData()
        {
            try
            {
                Group row = groupView.dataGridViewCurrentRowData as Group;
                if (row != null)
                {
                    int id = row.Id;
                    Group group = database.Groups.Find(row.Id);

                    group.Name = groupView.GroupName;
                    group.Date = groupView.Date;

                    database.SaveChanges();
                    DataToGrig();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
