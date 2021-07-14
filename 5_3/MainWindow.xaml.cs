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
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Collections;

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

        string fileName = "";

        string selectedName;
        string selectedPhone;

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
               
            }
            XDocument xdoc = XDocument.Load($"{fileName}");
            XElement root = xdoc.Element("phonebook");

            string name;
            string phone;

            foreach (XElement xe in root.Elements("Note"))
            {
                name = xe.Element("name").Value;
                phone = xe.Element("phone").Value;
                selectedName = name;
                selectedPhone = phone;

                Phones_List.Items.Add($"{name}|{phone}");
            }

        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            string phone = "";
            string name = "";

            XDocument xdoc = XDocument.Load($"{fileName}");
            XElement root = xdoc.Element("phonebook");

            foreach (XElement xe in root.Elements("Note"))
            {

                string Item = Phones_List.SelectedItem as string;
                var selectedItem = Item.Split('|');

                if (selectedItem[0] == xe.Element("name").Value && selectedItem[1] == xe.Element("phone").Value)
                {
                    name = xe.Element("name").Value;
                    phone = xe.Element("phone").Value;

                    selectedName = name;
                    selectedPhone = phone;
                    break;
                }
            }

            xdoc.Save($"{fileName}");

            Edit AddElemW = new Edit(name, phone);
            AddElemW.Show();
            AddElemW.Notify += Edit_Note;

        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            Edit AddElemW = new Edit("", "");
            AddElemW.Show();
            AddElemW.Notify += Add_Note;
        }

        private void Edit_Note(string[] newNote)
        {
            XDocument xdoc = XDocument.Load($"{fileName}");
            XElement root = xdoc.Element("phonebook");

            foreach (XElement xe in root.Elements("Note"))
            {


                if (selectedName == xe.Element("name").Value && selectedPhone == xe.Element("phone").Value)
                {
                    xe.Element("name").Value = newNote[0];
                    xe.Element("phone").Value = newNote[1];

                    break;
                }
            }

            xdoc.Save($"{fileName}");
            UpdateList();
        }

        private void Add_Note(string[] newNote)
        {
            XDocument xdoc = XDocument.Load($"{fileName}");
            XElement root = xdoc.Element("phonebook");

            root.Add(new XElement("Note", new XElement("name", $"{newNote[0]}"),
                    new XElement("phone", $"{newNote[1]}")
                    ));
            xdoc.Save($"{fileName}");
            UpdateList();
        }

        private void UpdateList()
        {
            Phones_List.Items.Clear();
            XDocument xdoc = XDocument.Load($"{fileName}");
            XElement root = xdoc.Element("phonebook");

            string name;
            string phone;

            foreach (XElement xe in root.Elements("Note"))
            {
                name = xe.Element("name").Value;
                phone = xe.Element("phone").Value;
                selectedName = name;
                selectedPhone = phone;

                Phones_List.Items.Add($"{name}|{phone}");
            }
        }

        private void Del_button_Click(object sender, RoutedEventArgs e)
        {
            string Item = Phones_List.SelectedItem as string;
            var selectedItem = Item.Split('|');
            Delete_Note(selectedItem);
        }

        private void Delete_Note(string[] newNote)
        {
            XDocument xdoc = XDocument.Load($"{fileName}");
            XElement root = xdoc.Element("phonebook");

            foreach (XElement xe in root.Elements("Note"))
            {


                if (newNote[0] == xe.Element("name").Value && newNote[1] == xe.Element("phone").Value)
                {
                    xe.Remove();
                    break;
                }
            }

            xdoc.Save($"{fileName}");
            UpdateList();
        }

        private void Sort_Button_Click(object sender, RoutedEventArgs e)
        {
            ArrayList q = new ArrayList();
            foreach (object o in Phones_List.Items)
            { 
                q.Add(o);
            }
             q.Sort();
            Phones_List.Items.Clear();

            foreach(object o in q)
            {
                Phones_List.Items.Add(o); 
            }
        }
    }
}
