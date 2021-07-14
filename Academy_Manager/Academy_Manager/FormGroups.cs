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
    public partial class FormGroups : Form, IGroupView
    {
        private GroupPresenter groupPresenter;

        public string GroupName
        {
            get { return txtBoxName.Text; }
            set { txtBoxName.Text = value; }
        }

        public DateTime? Date
        {
            get { return dateTime.Value; }
            set { dateTime.Value = value.GetValueOrDefault(); }
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
                    cols["Students"].Visible = false;
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

        public FormGroups()
        {
            InitializeComponent();

            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            dataGrid.ReadOnly = true;

            groupPresenter = new GroupPresenter(this);
        }

        private void FrmGroups_Load(object sender, EventArgs e)
        {
            groupPresenter.LoadData();
            groupPresenter.getDataFromGrid();
        }

        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            //groupPresenter.getDataFromGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            groupPresenter.saveData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            groupPresenter.UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            groupPresenter.deleteData();
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            groupPresenter.getDataFromGrid();
        }

        private void txtBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
