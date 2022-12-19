using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace SalaryApp
{
    public partial class Window1 : Window
    {
        public DataTable Select(string selectSQL) 
        {
            DataTable dataTable = new DataTable("dataBase");                                                                          
            SqlConnection sqlConnection = new SqlConnection("server=LAPTOP-08SA6AES\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=salary_db;");
            sqlConnection.Open();                                           
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         
            sqlCommand.CommandText = selectSQL;                             
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); 
            sqlDataAdapter.Fill(dataTable);                                 
            return dataTable;
        }

        public Window1()
        {
            InitializeComponent();
            DataTable dt_tableNumber = Select($"SELECT * FROM Employee");
            for (int i = 0; i < dt_tableNumber.Rows.Count; i++)
            {
                string tab = Convert.ToString(dt_tableNumber.Rows[i][0]);
                string fio = Convert.ToString(dt_tableNumber.Rows[i][1]);
                string result = tab + " " + fio;
                comboBoxTabel.Items.Add(result);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tabelNumber = comboBoxTabel.Text.Split(' ')[0];
            Select($"EXEC timesheet_entry '{Convert.ToInt32(tabelNumber)}', '{Date.Text}', '{Convert.ToInt32(numberDays.Text)}', '{Convert.ToInt32(numberNight.Text)}', '{Convert.ToInt32(numberRVD.Text)}'");
            MessageBox.Show("Данные успешно добавлены");
        }

        private void comboBoxTabel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
