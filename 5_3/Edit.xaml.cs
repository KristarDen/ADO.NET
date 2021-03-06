using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _5_3_Phonebook
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit(string name, string number) 
        {
            InitializeComponent();

            _name = name;
            _number = number;

            Name_text.Text = _name;
            Number_text.Text = _number;
        }

        private string _name;
        private string _number;

        public delegate void ResultHandler(string [] message);
        public event ResultHandler Notify;

        private void Save_bt_Click(object sender, RoutedEventArgs e)
        {
            _name = Name_text.Text;
            _number = Number_text.Text;

            string[] mess = new string[2] { $"{_name}", $"{_number}" };

            Notify?.Invoke(mess);
            this.Close();
        }

        private void Cancel_bt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
