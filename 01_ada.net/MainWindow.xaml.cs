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

namespace _01_ada.net
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = $"Server={ServerName_TBox.Text};Database={DataBaseName_TBox.Text};Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            List<String> tablesList = new List<String>();
            Dictionary<String, String> columnsDictionary = new Dictionary<String, String>();

            try
            {
                // Открываем подключение
                connection.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Connection fail. {ex}");
            }
            finally
            {
                MessageBox.Show("Свойства подключения:" +
                    $"\nСтрока подключения: {connection.ConnectionString}" +
                    $"\nБаза данных: {connection.Database}" +
                    $"\nСервер: {connection.DataSource}" +
                    $"\nВерсия сервера: {connection.ServerVersion}" +
                    $"\nСостояние: {connection.State}" +
                    $"\nWorkstationld: {connection.WorkstationId}");

            }
            DataTable table = connection.GetSchema("Tables");

            string mess = "";

            foreach (System.Data.DataRow row in table.Rows)
            {
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "TABLE_NAME")
                    {
                        mess += $"{col.ColumnName} = {row[col]}\n";
                        Tables_CBox.Items.Add( $"{row[col]}");
                    }

                }

                mess += "======================\n";
            }
            MessageBox.Show(mess);
            Tables_CBox.SelectedIndex = 0;
            connection.Close();
        }

        private void Tables_CBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string connectionString = $"Server={ServerName_TBox.Text};Database={DataBaseName_TBox.Text};Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = $"SELECT * FROM {Tables_CBox.SelectedItem}";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Table_Data.ItemsSource = dt.DefaultView;
            connection.Close();
        }
    }
}
