using Academy.Models;
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
    public class SubjectPresenter
    {
        private ISubjectView subjectView;
        private AcademyContext database = new AcademyContext();

        public SubjectPresenter(ISubjectView view)
        {
            subjectView = view;
        }

        private void DataToGrig()
        {
            var data = from sub in database.Subjects 
                       join thr in database.Teachers on sub.IdTeacher equals thr.Id
                       orderby sub.Name
                       select new SubjectView 
                       { 
                           Id = sub.Id,
                           Name = sub.Name,
                           Duration = sub.Duration,
                           TeacherName = $"{thr.FirstName} {thr.LastName}",
                           IdTeacher = sub.IdTeacher,
                       };

            if (data != null && data.Count() > 0)
            {
                subjectView.dataGridViewSource = data.ToList();
            }
                
            else
            {
                subjectView.dataGridViewSource = null;
            }
        }

        private void DataToCombo()
        {
            var teachers = from thr in database.Teachers
                           orderby thr.FirstName, thr.LastName
                           select new TeacherView
                           {
                               Id = thr.Id,
                               DisplayName = $"{thr.FirstName} {thr.LastName}"
                           };

            if (teachers != null && teachers.Count() > 0)
            {
                subjectView.cmbBoxTeachersViewSource = teachers.ToList();
            }
               
            else
            {
                subjectView.cmbBoxTeachersViewSource = null;
            }
                
        }

        public void LoadData()
        {
            DataToGrig();
            DataToCombo();
        }

        public void GetGridData()
        {
            if (subjectView.dataGridViewSource == null) return;

            Subject row = subjectView.dataGridViewCurrentRowData as Subject;

            if(row != null)
            {
                Subject subject = database.Subjects.Find(row.Id);

                if (subject != null)
                {
                    subjectView.NameSubject = subject.Name;
                    subjectView.Duration = subject.Duration;
                    subjectView.cmbBoxTeachersViewSelectedValue = subject.IdTeacher;
                }
            }
        }

        public void Save()
        {
            try
            {
                Subject subject = new Subject()
                {
                    Name = subjectView.NameSubject,
                    Duration = (byte)subjectView.Duration,
                    IdTeacher = (int)subjectView.cmbBoxTeachersViewSelectedValue,
                };

                database.Subjects.Add(subject);
                database.SaveChanges();

                DataToGrig();
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        public void Delete()
        {
            try
            {
                Subject row = subjectView.dataGridViewCurrentRowData as Subject;

                if (row != null)
                {
                    var result = MessageBox.Show("Are You sure?", "Del", MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes)return;

                    int id = row.Id;
                    Subject subject = database.Subjects.Find(row.Id);

                    database.Subjects.Remove(subject);
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
                Subject row = subjectView.dataGridViewCurrentRowData as Subject;

                if (row != null)
                {
                    int id = row.Id;
                    Subject subject = database.Subjects.Find(row.Id);

                    subject.Name = subjectView.NameSubject;
                    subject.Duration = (byte)subjectView.Duration;
                    subject.IdTeacher = (int)subjectView.cmbBoxTeachersViewSelectedValue;

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
