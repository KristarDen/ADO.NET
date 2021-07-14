using Academy.Models.db;
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
    public partial class FormStudents : Form, IStudentView, IMarkStudentView
    {
        private StudentPresenter studentPresenter;

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

        public int? MarkValue 
        {
            get { return int.Parse(txtBoxValue.Text); }
            set { txtBoxValue.Text = value.GetValueOrDefault().ToString(); }
        }
        public DateTime? MarkDate
        {
            get { return dateTimeDate.Value; }
            set { dateTimeDate.Value = value.GetValueOrDefault(); }
        }

        public object DataGridViewSource 
        {
            get { return dataGrid.DataSource;  }
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

        public object DataGridViewCurrentRowData
        {
            get 
            {
                if (dataGrid.CurrentRow == null)
                    return null;
                else
                    return dataGrid.CurrentRow.DataBoundItem;
            }
        }

        public object CmbBoxGroupsViewSource 
        {
            get { return cmbBoxGroups.DataSource; }
            set 
            { 
                cmbBoxGroups.DataSource = value;
                cmbBoxGroups.DisplayMember = "Name";
                cmbBoxGroups.ValueMember = "Id";
            }
        }

        public object CmbBoxGroupsViewSelectedValue
        {
            get { return cmbBoxGroups.SelectedValue; }
            set { cmbBoxGroups.SelectedValue = value; }
        }

        public object MarkDataGridViewSource 
        {
            get { return dataGridMark.DataSource; }
            set 
            { 
                dataGridMark.DataSource = value;
                if (dataGridMark.DataSource != null)
                {
                    var cols = dataGridMark.Columns;
                    foreach (DataGridViewColumn column in cols)
                    {
                        if (column.ValueType == typeof(String))
                            column.Width = 200;
                    }

                    cols["IdStudent"].Visible = false;
                    cols["IdSubject"].Visible = false;
                    cols["IdStudentNavigation"].Visible = false;
                    cols["IdSubjectNavigation"].Visible = false;
                }
            }
        }

        public object MarkDataGridViewCurrentRowData 
        {
            get 
            { 
                if(dataGridMark.CurrentRow == null)
                    return null;
                else
                    return dataGridMark.CurrentRow.DataBoundItem;
            }
        }
                
        public object SubjCmbBoxViewSource
        {
            get { return cmbBoxSubject.DataSource; }
            set
            {
                cmbBoxSubject.DataSource = value;
                cmbBoxSubject.DisplayMember = "Name";
                cmbBoxSubject.ValueMember = "Id";
            }
        }
        public object SubjCmbBoxViewSelectedValue
        {
            get { return cmbBoxSubject.SelectedValue; }
            set { cmbBoxSubject.SelectedValue = value; }
        }

        public string Search 
        {
            get { return txtBoxSearch.Text; }
            set { txtBoxSearch.Text = value; } 
        }

        public FormStudents()
        {
            InitializeComponent();
            
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            dataGrid.ReadOnly = true;
            
            dataGridMark.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridMark.MultiSelect = false;
            dataGridMark.ReadOnly = true;

            studentPresenter = new StudentPresenter(this, this);
        }

        private void FrmStudents_Load(object sender, EventArgs e)
        {
            studentPresenter.LoadData();
            studentPresenter.GetDataFromGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            studentPresenter.Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            studentPresenter.Delete();
        }
    

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            studentPresenter.Update();
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            studentPresenter.GetDataFromGrid();
            studentPresenter.DataToGrigMark();
        }

        private void btnInsertSubj_Click(object sender, EventArgs e)
        {
            studentPresenter.SaveMark();
        }

        private void btnUpdateSubj_Click(object sender, EventArgs e)
        {
            studentPresenter.UpdateMark();
        }

        private void btnDeleteSubj_Click(object sender, EventArgs e)
        {
            studentPresenter.DeleteMark();
        }

        private void dataGridMark_SelectionChanged(object sender, EventArgs e)
        {
            studentPresenter.GetDataFromGridMark();
        }

        private void txtBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            studentPresenter.DataToGrig();
        }

        private void dateTimeBirth_ValueChanged(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(dateTimeBirth, "The student must be over 16 years old");
        }

        private void txtBoxValue_TextChanged(object sender, EventArgs e)
        {
            ToolTip d = new ToolTip();
            d.SetToolTip(txtBoxValue, "The student's grade must be between 1 and 12 points");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
