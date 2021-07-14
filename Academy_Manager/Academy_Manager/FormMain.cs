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
    public partial class FormMain : Form, IMainView
    {
        private MainPresenter mainPresenter;

        public object DataGridViewSourse
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
                    cols["IdGroup"].Visible = false;
                    cols["IdGroupNavigation"].Visible = false;
                    cols["Marks"].Visible = false;
                }
            }
        }

        public object CmbBoxGroupViewSourse
        {
            get { return cmbBoxGroups.DataSource; }
            set 
            {
                cmbBoxGroups.DisplayMember = "Name";
                cmbBoxGroups.ValueMember = "Id";
                cmbBoxGroups.DataSource = value; 
            }
        }

        public object CmbBoxGroupViewSelectedItem 
        { 
            get 
            {
                return cmbBoxGroups.SelectedItem;
            }
        }

        public FormMain()
        {
            InitializeComponent();

            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            dataGrid.ReadOnly = true;

            mainPresenter = new MainPresenter(this);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            FormStudents frmStudents = new FormStudents();
            frmStudents.ShowDialog();
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            FormTeachers frmTeachers = new FormTeachers();
            frmTeachers.ShowDialog();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            FormGroups frmGroups = new FormGroups();
            frmGroups.ShowDialog();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            FormSubjects frmSubjects = new FormSubjects();
            frmSubjects.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            mainPresenter.LoadData();
        }

        private void cmbBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainPresenter.DataToGrig();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
