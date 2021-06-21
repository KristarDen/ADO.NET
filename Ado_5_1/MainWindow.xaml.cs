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

using System.Data;
using Microsoft.Data.SqlClient;

namespace Ado_5_1
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

        public struct Worker
        {
            public string id;
            public string firstName;
            public string lastName;
            public DateTime work_started;
            public DateTime work_ended;
        }

        public struct WorkDay
        {
            public int id;
            public int day_number;
        }

       

        public List<Worker> allWorkers = new List<Worker>();
        public List<WorkDay> allDays_Of_Work = new List<WorkDay>();

        public List<string> days_of_curr_worker = new List<string>();

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = $"Server={ServerName_TBox.Text};Database={DataBaseName_TBox.Text};Trusted_Connection=True;";

            //Получение данных о рабочих
            string sqlExpression = "SELECT * FROM Workers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    
                    while (reader.Read()) // построчно считываем данные
                    {
                        Worker newWorker = new Worker();

                        newWorker.id = reader.GetString(0);
                        newWorker.firstName = reader.GetString(1);
                        newWorker.lastName = reader.GetString(2);
                        newWorker.work_started = reader.GetDateTime(3);
                        newWorker.work_ended = reader.GetDateTime(4);
                        /*
                        MessageBox.Show(
                        $"\nid: {newWorker.id}" +
                        $"\nFirst name: {newWorker.firstName}" +
                        $"\nLast Name: {newWorker.lastName}" +
                        $"\ndate of start: {newWorker.work_started}" +
                        $"\ndate of end: {newWorker.work_ended}");*/

                        allWorkers.Add(newWorker);
                        Tables_of_Workers.Items.Add($"{newWorker.id}| {newWorker.firstName} {newWorker.lastName}");
                    }
                }


                reader.Close();
            }

            //Получение данных о расписании
            sqlExpression = "SELECT * FROM Days_of_work";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {

                    while (reader.Read()) // построчно считываем данные
                    {
                        WorkDay newDay = new WorkDay();

                        newDay.id = reader.GetInt32(0);
                        newDay.day_number = reader.GetInt32(1);



                        allDays_Of_Work.Add(newDay);
                    }
                }


                reader.Close();
            }


        }

        private void Tables_of_Workers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string buffer = Tables_of_Workers.SelectedItem.ToString();
            Dates_List.Items.Clear();
            string idStr = "";
            //int id;

            for(int i = 0; buffer[i] != '|' && buffer[i] != ' '; i++)
            {
                idStr += buffer[i];
            }
            //id = Convert.ToInt32(idStr);


            int workerIndex = 0;
            int index = 1;
            for(int i = 0; i < allWorkers.Count; i++)
            {
                string ID = "";

                for (int j = 0; buffer[j] != '|' && buffer[j] != ' '; j++)
                {
                    ID += allWorkers[i].id[j];
                }

                if (ID == idStr)
                {
                    workerIndex = index;
                    break;
                }
                index++;
            }


            DateTime dateIndex = allWorkers[workerIndex-1].work_started;
            DateTime dateOfEnd = allWorkers[workerIndex-1].work_ended;

            List<WorkDay> schedule = new List<WorkDay>();


            foreach (var item in allDays_Of_Work)
            {
                if(item.id == workerIndex)
                {
                    schedule.Add(item);
                }
            }

            int days_count = 0;
            while(dateIndex < dateOfEnd)
            {

                for (int i = 0; i < schedule.Count; i++)
                {
                    if ((int)dateIndex.DayOfWeek == schedule[i].day_number)
                    {
                        days_count++;
                        days_of_curr_worker.Add($"{days_count}\t{dateIndex.ToString()}|{dateIndex.DayOfWeek.ToString()}");
                        Dates_List.Items.Add($"{days_count}\t{dateIndex.ToString()} |{dateIndex.DayOfWeek.ToString()}");
                    }
                    
                }
                dateIndex = dateIndex.AddDays(1);
                
            }

        }
    }
}
