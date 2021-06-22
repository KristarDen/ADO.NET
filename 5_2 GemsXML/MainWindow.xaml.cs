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

namespace _5_2_GemsXML
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


                // перебор всех строк таблицы
                foreach (DataRow row in xml_dt.Rows)
                {
                    if (!Gems_Box.Items.Contains(row.ItemArray[1]))
                    { 
                        Gems_Box.Items.Add( row.ItemArray[1] );
                    }

                }

            }
            
        }

        private void Gems_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Gems_List.Items.Clear();
           // Open document



           // перебор всех строк таблицы
           foreach (DataRow row in xml_dt.Rows)
           {
                if(String.Compare($"{row.ItemArray[1]}", $"{Gems_Box.SelectedItem}") == 0)
                {
                    string rowData = "";
                    foreach (object cell in row.ItemArray)
                    {
                        rowData += $"{cell}" + "\t";
                    }
                    Gems_List.Items.Add(rowData);
                }

           }

            


        }
    }
}
