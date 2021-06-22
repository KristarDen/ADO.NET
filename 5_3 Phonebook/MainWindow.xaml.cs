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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Data;

namespace _5_3_Phonebook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DataSet xml_dataSet = new DataSet();
        DataTable xml_dt;
        string fileName = "";

        Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "XML files (.xml)|*.xml"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                fileName = dlg.FileName;
                xml_dataSet.ReadXml(dlg.FileName);

                xml_dt = xml_dataSet.Tables[0];

            }


            foreach (DataRow row in xml_dt.Rows)
            {
                phoneBook.Add($"{row.ItemArray[0]}", $"{row.ItemArray[1]}");
                Phones_List.Items.Add($"[{row.ItemArray[0]}, {row.ItemArray[1]}]");
            }


        }

        private void Gems_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch(Sort_Box.SelectedIndex)
            {
                case 0:
                    //phoneBook = phoneBook.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                    Phones_List.Items.Clear();

                    //SortedDictionary<string,string> sorted

                    var items = from pair in phoneBook
                                orderby pair.Key ascending
                                select pair;

                    foreach (var item in items)
                    {
                        Phones_List.Items.Add(item);
                    }
                 break;

                case 1:
                    //phoneBook = phoneBook.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                    Phones_List.Items.Clear();

                    //SortedDictionary<string,string> sorted

                    var itemss = from pair in phoneBook
                                orderby pair.Value ascending
                                select pair;

                    foreach (var item in itemss)
                    {
                        Phones_List.Items.Add(item);
                    }
                  break;
            }
            /*
            foreach (DataRow row in xml_dt.Rows)
            {
                if (String.Compare($"{row.ItemArray[1]}", $"{Gems_Box.SelectedItem}") == 0)
                {
                    string rowData = "";
                    foreach (object cell in row.ItemArray)
                    {
                        rowData += $"{cell}" + "\t";
                    }
                    Gems_List.Items.Add(rowData);
                }

            }*/




        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
