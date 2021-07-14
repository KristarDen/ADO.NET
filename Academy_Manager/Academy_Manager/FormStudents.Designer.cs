
namespace Academy
{
    partial class FormStudents
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.txtBoxFirstName = new System.Windows.Forms.TextBox();
            this.txtBoxLastName = new System.Windows.Forms.TextBox();
            this.dateTimeBirth = new System.Windows.Forms.DateTimePicker();
            this.Name_label = new System.Windows.Forms.Label();
            this.Last_name_label = new System.Windows.Forms.Label();
            this.birth_day_label = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBoxGroups = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimeDate = new System.Windows.Forms.DateTimePicker();
            this.txtBoxValue = new System.Windows.Forms.TextBox();
            this.cmbBoxSubject = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteSubj = new System.Windows.Forms.Button();
            this.btnUpdateSubj = new System.Windows.Forms.Button();
            this.btnInsertSubj = new System.Windows.Forms.Button();
            this.dataGridMark = new System.Windows.Forms.DataGridView();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Студент = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMark)).BeginInit();
            this.Студент.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 38);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 25;
            this.dataGrid.Size = new System.Drawing.Size(402, 270);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            this.dataGrid.SelectionChanged += new System.EventHandler(this.dataGrid_SelectionChanged);
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Location = new System.Drawing.Point(6, 48);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(252, 23);
            this.txtBoxFirstName.TabIndex = 1;
            this.txtBoxFirstName.TextChanged += new System.EventHandler(this.txtBoxFirstName_TextChanged);
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Location = new System.Drawing.Point(6, 104);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(252, 23);
            this.txtBoxLastName.TabIndex = 2;
            // 
            // dateTimeBirth
            // 
            this.dateTimeBirth.CustomFormat = "dd.MM.yyyy";
            this.dateTimeBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBirth.Location = new System.Drawing.Point(6, 161);
            this.dateTimeBirth.Name = "dateTimeBirth";
            this.dateTimeBirth.Size = new System.Drawing.Size(252, 23);
            this.dateTimeBirth.TabIndex = 3;
            this.dateTimeBirth.ValueChanged += new System.EventHandler(this.dateTimeBirth_ValueChanged);
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(6, 30);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(31, 15);
            this.Name_label.TabIndex = 4;
            this.Name_label.Text = "Имя";
            // 
            // Last_name_label
            // 
            this.Last_name_label.AutoSize = true;
            this.Last_name_label.Location = new System.Drawing.Point(6, 86);
            this.Last_name_label.Name = "Last_name_label";
            this.Last_name_label.Size = new System.Drawing.Size(58, 15);
            this.Last_name_label.TabIndex = 5;
            this.Last_name_label.Text = "Фамилия";
            // 
            // birth_day_label
            // 
            this.birth_day_label.AutoSize = true;
            this.birth_day_label.Location = new System.Drawing.Point(6, 138);
            this.birth_day_label.Name = "birth_day_label";
            this.birth_day_label.Size = new System.Drawing.Size(90, 15);
            this.birth_day_label.TabIndex = 6;
            this.birth_day_label.Text = "Дата рождения";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Добавить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(87, 255);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Brown;
            this.btnDelete.ForeColor = System.Drawing.Color.Snow;
            this.btnDelete.Location = new System.Drawing.Point(168, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Группа";
            // 
            // cmbBoxGroups
            // 
            this.cmbBoxGroups.FormattingEnabled = true;
            this.cmbBoxGroups.Location = new System.Drawing.Point(6, 223);
            this.cmbBoxGroups.Name = "cmbBoxGroups";
            this.cmbBoxGroups.Size = new System.Drawing.Size(252, 23);
            this.cmbBoxGroups.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimeDate);
            this.groupBox1.Controls.Add(this.txtBoxValue);
            this.groupBox1.Controls.Add(this.cmbBoxSubject);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnDeleteSubj);
            this.groupBox1.Controls.Add(this.btnUpdateSubj);
            this.groupBox1.Controls.Add(this.btnInsertSubj);
            this.groupBox1.Controls.Add(this.dataGridMark);
            this.groupBox1.Location = new System.Drawing.Point(14, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 377);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оценки";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Дата";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Оценка";
            // 
            // dateTimeDate
            // 
            this.dateTimeDate.CustomFormat = "dd.MM.yyyy";
            this.dateTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDate.Location = new System.Drawing.Point(6, 321);
            this.dateTimeDate.Name = "dateTimeDate";
            this.dateTimeDate.Size = new System.Drawing.Size(246, 23);
            this.dateTimeDate.TabIndex = 20;
            // 
            // txtBoxValue
            // 
            this.txtBoxValue.Location = new System.Drawing.Point(6, 277);
            this.txtBoxValue.Name = "txtBoxValue";
            this.txtBoxValue.Size = new System.Drawing.Size(246, 23);
            this.txtBoxValue.TabIndex = 19;
            this.txtBoxValue.TextChanged += new System.EventHandler(this.txtBoxValue_TextChanged);
            // 
            // cmbBoxSubject
            // 
            this.cmbBoxSubject.FormattingEnabled = true;
            this.cmbBoxSubject.Location = new System.Drawing.Point(6, 233);
            this.cmbBoxSubject.Name = "cmbBoxSubject";
            this.cmbBoxSubject.Size = new System.Drawing.Size(246, 23);
            this.cmbBoxSubject.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Предмет";
            // 
            // btnDeleteSubj
            // 
            this.btnDeleteSubj.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteSubj.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeleteSubj.Location = new System.Drawing.Point(276, 303);
            this.btnDeleteSubj.Name = "btnDeleteSubj";
            this.btnDeleteSubj.Size = new System.Drawing.Size(75, 41);
            this.btnDeleteSubj.TabIndex = 16;
            this.btnDeleteSubj.Text = "Удалить";
            this.btnDeleteSubj.UseVisualStyleBackColor = false;
            this.btnDeleteSubj.Click += new System.EventHandler(this.btnDeleteSubj_Click);
            // 
            // btnUpdateSubj
            // 
            this.btnUpdateSubj.Location = new System.Drawing.Point(276, 262);
            this.btnUpdateSubj.Name = "btnUpdateSubj";
            this.btnUpdateSubj.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSubj.TabIndex = 15;
            this.btnUpdateSubj.Text = "Изменить";
            this.btnUpdateSubj.UseVisualStyleBackColor = true;
            this.btnUpdateSubj.Click += new System.EventHandler(this.btnUpdateSubj_Click);
            // 
            // btnInsertSubj
            // 
            this.btnInsertSubj.Location = new System.Drawing.Point(276, 233);
            this.btnInsertSubj.Name = "btnInsertSubj";
            this.btnInsertSubj.Size = new System.Drawing.Size(75, 23);
            this.btnInsertSubj.TabIndex = 14;
            this.btnInsertSubj.Text = "Добавить";
            this.btnInsertSubj.UseVisualStyleBackColor = true;
            this.btnInsertSubj.Click += new System.EventHandler(this.btnInsertSubj_Click);
            // 
            // dataGridMark
            // 
            this.dataGridMark.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridMark.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridMark.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMark.Location = new System.Drawing.Point(6, 22);
            this.dataGridMark.Name = "dataGridMark";
            this.dataGridMark.RowTemplate.Height = 25;
            this.dataGridMark.Size = new System.Drawing.Size(670, 179);
            this.dataGridMark.TabIndex = 13;
            this.dataGridMark.SelectionChanged += new System.EventHandler(this.dataGridMark_SelectionChanged);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(62, 9);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(85, 23);
            this.txtBoxSearch.TabIndex = 13;
            this.txtBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxSearch_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Search";
            // 
            // Студент
            // 
            this.Студент.Controls.Add(this.txtBoxFirstName);
            this.Студент.Controls.Add(this.Name_label);
            this.Студент.Controls.Add(this.Last_name_label);
            this.Студент.Controls.Add(this.txtBoxLastName);
            this.Студент.Controls.Add(this.btnDelete);
            this.Студент.Controls.Add(this.cmbBoxGroups);
            this.Студент.Controls.Add(this.btnUpdate);
            this.Студент.Controls.Add(this.birth_day_label);
            this.Студент.Controls.Add(this.btnSave);
            this.Студент.Controls.Add(this.label4);
            this.Студент.Controls.Add(this.dateTimeBirth);
            this.Студент.Location = new System.Drawing.Point(429, 24);
            this.Студент.Name = "Студент";
            this.Студент.Size = new System.Drawing.Size(261, 284);
            this.Студент.TabIndex = 15;
            this.Студент.TabStop = false;
            this.Студент.Text = "Студент";
            this.Студент.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // FormStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 717);
            this.Controls.Add(this.Студент);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormStudents";
            this.Text = "Студенты";
            this.Load += new System.EventHandler(this.FrmStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMark)).EndInit();
            this.Студент.ResumeLayout(false);
            this.Студент.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxFirstName;
        private System.Windows.Forms.TextBox txtBoxLastName;
        private System.Windows.Forms.DateTimePicker dateTimeBirth;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label Last_name_label;
        private System.Windows.Forms.Label birth_day_label;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBoxGroups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimeDate;
        private System.Windows.Forms.TextBox txtBoxValue;
        private System.Windows.Forms.ComboBox cmbBoxSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteSubj;
        private System.Windows.Forms.Button btnUpdateSubj;
        private System.Windows.Forms.Button btnInsertSubj;
        private System.Windows.Forms.DataGridView dataGridMark;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox Студент;
    }
}