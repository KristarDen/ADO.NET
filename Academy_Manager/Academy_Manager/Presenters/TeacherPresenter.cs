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
    public class TeacherPresenter
    {
        private ITeacherView teacherView;
        private AcademyContext database = new AcademyContext();

        public TeacherPresenter(ITeacherView view)
        {
            teacherView = view;
        }

        private void DataToGrig()
        {
            var data = from thr in database.Teachers 
                       orderby thr.FirstName, thr.LastName
                       select thr;

            if (data != null && data.Count() > 0)
            {
                teacherView.dataGridViewSource = data.ToList();
            }

            else
            {
                teacherView.dataGridViewSource = null;
            }

        }

        public void Load()
        {
            DataToGrig();
        }

        public void GetGridData()
        {
            if (teacherView.dataGridViewSource == null) return;

            Teacher row = teacherView.dataGridViewCurrentRowData as Teacher;

            if(row != null) 
            {
                Teacher teacher = database.Teachers.Find(row.Id);

                if (teacher != null)
                {
                    teacherView.FirstName = teacher.FirstName;
                    teacherView.LastName = teacher.LastName;
                    teacherView.Birthday = teacher.BirthDate.GetValueOrDefault();
                }
            }
        }

        public void Save()
        {
            try
            {
                Teacher teacher = new Teacher()
                {
                    FirstName = teacherView.FirstName,
                    LastName = teacherView.LastName,
                    BirthDate = teacherView.Birthday,
                };

                database.Teachers.Add(teacher);
                database.SaveChanges();

                DataToGrig();
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }

        public void Delete()
        {
            try
            {
                Teacher row = teacherView.dataGridViewCurrentRowData as Teacher;

                if (row != null)
                {
                    var result = MessageBox.Show("Are You sure?", "Del", MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes) return;

                    int id = row.Id;
                    Teacher teacher = database.Teachers.Find(row.Id);

                    database.Teachers.Remove(teacher);
                    database.SaveChanges();

                    DataToGrig();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        public void Update()
        {
            try
            {
                Teacher row = teacherView.dataGridViewCurrentRowData as Teacher;

                if (row != null)
                {
                    int id = row.Id;
                    Teacher teacher = database.Teachers.Find(row.Id);

                    teacher.FirstName = teacherView.FirstName;
                    teacher.LastName = teacherView.LastName;
                    teacher.BirthDate = teacherView.Birthday;

                    database.SaveChanges();

                    DataToGrig();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
