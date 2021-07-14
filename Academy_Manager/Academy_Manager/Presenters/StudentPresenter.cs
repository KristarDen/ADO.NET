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
    public class StudentPresenter
    {
        private IStudentView studentView;
        private IMarkStudentView markStudentView; 
        private AcademyContext database = new AcademyContext();

        public StudentPresenter(IStudentView view, IMarkStudentView markView)
        {
            studentView = view;
            markStudentView = markView;
        }

        public void DataToGrig() 
        {
            var students = from s in database.Students
                           where s.FirstName.Contains(studentView.Search) || s.LastName.Contains(studentView.Search)
                           orderby s.FirstName, s.LastName
                           select s;

            if (students != null && students.Count() > 0)
            {
                studentView.DataGridViewSource = students.ToList();
            }
               
            else
            {
                studentView.DataGridViewSource = null;
            }
               
        }

        private void DataToCombo() 
        {
            var groups = from g in database.Groups 
                         orderby g.Name
                         select g;

            if (groups != null && groups.Count() > 0)
            {
                studentView.CmbBoxGroupsViewSource = groups.ToList();
            }
                
            else
            {
                studentView.CmbBoxGroupsViewSource = null;
            }
               
        }

        public void DataToGrigMark()
        {
            if (studentView.DataGridViewSource == null) return;
            
            Student student = studentView.DataGridViewCurrentRowData as Student;

            if (student != null) 
            {
                var marks = from m in database.Marks
                            join s in database.Subjects on m.IdSubject equals s.Id
                            orderby s.Name
                            where m.IdStudent == student.Id
                            select new MarkView
                            { 
                                Subject = s.Name,
                                Value = m.Value, 
                                Date = m.Date,
                                IdStudent = m.IdStudent,
                                IdSubject = m.IdSubject,
                            };

                if (marks != null && marks.Count() > 0)
                {
                    markStudentView.MarkDataGridViewSource = marks.ToList();
                }
                    
                else
                {
                    markStudentView.MarkDataGridViewSource = null;
                }
                    
            }
        }

        private void DataToMarkCombo()
        {
            var subject = from sb in database.Subjects select sb;

            if (subject != null && subject.Count() > 0)
            {
                markStudentView.SubjCmbBoxViewSource = subject.ToList();
            }
                
            else
            {
                markStudentView.SubjCmbBoxViewSource = null;
            }
                
        }

        public void LoadData()
        {
            DataToCombo();
            DataToGrig();
            DataToMarkCombo();
        }

        public void GetDataFromGrid()
        {
            if (studentView.DataGridViewSource == null) return;

            Student row = studentView.DataGridViewCurrentRowData as Student;

            if(row != null)
            {
                Student student = database.Students.Find(row.Id);

                if (student != null)
                {
                    studentView.FirstName = student.FirstName;
                    studentView.LastName = student.LastName;
                    studentView.Birthday = student.BirthDate.GetValueOrDefault();
                    studentView.CmbBoxGroupsViewSelectedValue = student.IdGroup;
                }
            }
        }

        public void GetDataFromGridMark()
        {
            if (markStudentView.MarkDataGridViewSource == null)
                return;
            Mark row = markStudentView.MarkDataGridViewCurrentRowData as Mark;

            if (row != null)
            {
                var mark = database.Marks.FirstOrDefault(el => el.IdStudent == row.IdStudent && el.IdSubject == row.IdSubject);
                if (mark != null)
                {
                    markStudentView.SubjCmbBoxViewSelectedValue = mark.IdSubject;
                    markStudentView.MarkValue = mark.Value;
                    markStudentView.MarkDate = mark.Date;
                }
            }
        }

        public void Save()
        {
            try
            {
                database.Students.Add(
                new Student()
                    {
                     FirstName = studentView.FirstName,
                     LastName = studentView.LastName,
                     BirthDate = studentView.Birthday,
                     IdGroup = (int)studentView.CmbBoxGroupsViewSelectedValue,
                    }
                );

                database.SaveChanges();
                DataToGrig();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        public void Delete()
        {
            try
            {
                Student row = studentView.DataGridViewCurrentRowData as Student;

                if (row != null)
                {
                    var result = MessageBox.Show("Are You sure?", "Del", MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                        return;

                    int id = row.Id;
                    Student student = database.Students.Find(row.Id);

                    database.Students.Remove(student);
                    database.SaveChanges();

                    DataToGrig();
                }
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }

        public void Update()
        {
            try
            {
                Student row = studentView.DataGridViewCurrentRowData as Student;

                if (row != null)
                {
                    int id = row.Id;
                    Student student = database.Students.Find(row.Id);

                    student.FirstName = studentView.FirstName;
                    student.LastName = studentView.LastName;
                    student.BirthDate = studentView.Birthday;
                    student.IdGroup = (int)studentView.CmbBoxGroupsViewSelectedValue;

                    database.SaveChanges();

                    DataToGrig();
                }
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }

        public void SaveMark()
        {
            try
            {
                Student row = studentView.DataGridViewCurrentRowData as Student;

                Mark check = database.Marks.FirstOrDefault(el => el.IdStudent == row.Id && el.IdSubject == (int)markStudentView.SubjCmbBoxViewSelectedValue);
                if (check != null) 
                {
                    MessageBox.Show("Ошибка");
                    return;
                }

                database.Marks.Add(new Mark()
                {
                    IdStudent = row.Id,
                    Value = (byte)markStudentView.MarkValue,
                    Date = markStudentView.MarkDate.GetValueOrDefault(),
                    IdSubject = (int)markStudentView.SubjCmbBoxViewSelectedValue,
                });
                database.SaveChanges();
                DataToGrigMark();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed");
                DataToGrigMark();
            }
        }

        public void DeleteMark()
        {
            try
            {
                Mark row = markStudentView.MarkDataGridViewCurrentRowData as Mark;

                if (row != null)
                {
                    var result = MessageBox.Show("Are You sure?", "Del", MessageBoxButtons.YesNo);

                    if (result != DialogResult.Yes) return;
                    
                    Mark mark = database.Marks.FirstOrDefault(el => el.IdStudent == row.IdStudent && el.IdSubject == row.IdSubject);

                    database.Marks.Remove(mark);
                    database.SaveChanges();

                    DataToGrigMark();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        public void UpdateMark()
        {
            try
            {
                Mark row = markStudentView.MarkDataGridViewCurrentRowData as Mark;

                if (row != null)
                {
                    Mark mark = database.Marks.FirstOrDefault(el => el.IdStudent == row.IdStudent && el.IdSubject == row.IdSubject);

                    mark.IdStudent = row.IdStudent;
                    mark.Value = (byte)markStudentView.MarkValue;
                    mark.Date = markStudentView.MarkDate.GetValueOrDefault();
                    mark.IdSubject = (int)markStudentView.SubjCmbBoxViewSelectedValue;

                    database.SaveChanges();

                    DataToGrigMark();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
                DataToGrigMark();
            }
        }

    }
}
