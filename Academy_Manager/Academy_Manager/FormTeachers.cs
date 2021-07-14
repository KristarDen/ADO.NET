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
    public partial class FormTeachers : Form, ITeacherView
    {
        private TeacherPresenter teacherPresenter;
        public FormTeachers()
        {
            InitializeComponent();
            teacherPresenter = new TeacherPresenter(this);
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            dataGrid.ReadOnly = true;
        }

        public string FirstName
        {
            get { return txtBoxFirstName.Text; }
            set { txtBoxFirstName.Text = value; }
        }
        public string LastName
        {
            get { return txtBoxLastName.Text; }
            set { txtBoxLastName.Text = value; }
        }

        public DateTime? Birthday
        {
            get { return dateTimeBirth.Value; }
            set { dateTimeBirth.Value = value.GetValueOrDefault(); }
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
                    foreach (DataGridViewColumn column in cols)
                    {
                        if (column.ValueType == typeof(String))
                            column.Width = 200;
                    }

                    cols["Id"].Visible = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            teacherPresenter.Save();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            teacherPresenter.Update();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            teacherPresenter.Delete();
        }

        private void FrmTeachers_Load(object sender, EventArgs e)
        {
            teacherPresenter.Load();
            teacherPresenter.GetGridData();
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            teacherPresenter.GetGridData();
        }

    }
}
