using Academy.Presenters;
using Academy.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
    public partial class FormSubjects : Form, ISubjectView
    {
        private SubjectPresenter subjectPresenter;
        public string NameSubject
        {
            get { return txtBoxName.Text; }
            set { txtBoxName.Text = value; }
        }

        public int Duration
        {
            get { return int.Parse(txtBoxDuration.Text); }
            set { txtBoxDuration.Text = value.ToString(); }
        }

        public object dataGridViewSource 
        {
            get { return dataGrid.DataSource; }            
            set 
            { 
                dataGrid.DataSource = value;
                if (dataGrid.DataSource != null)
                {
                    var cols = dataGrid.Columns;
                    cols["Id"].Visible = false;
                    cols["IdTeacher"].Visible = false;
                    cols["Marks"].Visible = false;

                    foreach (DataGridViewColumn column in cols)
                    {
                        if (column.ValueType == typeof(String))
                            column.Width = 200;
                    }
                }

            }
        }

        public object dataGridViewCurrentRowData 
        {
            get 
            {
                if (dataGrid.CurrentRow == null)
                    return null;
                else
                    return dataGrid.CurrentRow.DataBoundItem;
            }
        }

        public object cmbBoxTeachersViewSource 
        {
            get { return cmbBoxTeachers.DataSource; }
            set 
            {
                cmbBoxTeachers.DisplayMember = "DisplayName";
                cmbBoxTeachers.ValueMember = "Id";
                cmbBoxTeachers.DataSource = value; 
            }
        }

        public object cmbBoxTeachersViewSelectedValue 
        {
            get { return cmbBoxTeachers.SelectedValue; }
            set { cmbBoxTeachers.SelectedValue = value; }
        }

        public FormSubjects()
        {
            InitializeComponent();

            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            dataGrid.ReadOnly = true;

            subjectPresenter = new SubjectPresenter(this);
        }

        private void FrmSubjects_Load(object sender, EventArgs e)
        {
            subjectPresenter.LoadData();
            subjectPresenter.GetGridData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            subjectPresenter.Save();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            subjectPresenter.Update();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            subjectPresenter.Delete();
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            subjectPresenter.GetGridData();
        }

    }
}
