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
    public partial class Аccountant : Window
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
        public Аccountant()
        {
            InitializeComponent();
            DataTable dt_tableNumber = Select($"SELECT * FROM Employee");
            for (int i = 0; i < dt_tableNumber.Rows.Count; i++)
            {
                TableNumber.Items.Add(dt_tableNumber.Rows[i][0]);
            }

            DataTable dt_Award = Select($"SELECT * FROM TypeОfAward");
            for (int i = 0; i < dt_Award.Rows.Count; i++)
            {
                Award.Items.Add(dt_Award.Rows[i][1]);
            }

            DataTable dt_Allowance = Select($"SELECT * FROM TypeОfAllowances");
            for (int i = 0; i < dt_Allowance.Rows.Count; i++)
            {
                Allowance.Items.Add(dt_Allowance.Rows[i][1]);
            }
        }

        private void Award_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string start_dateVacation;
            string end_dateVacation;
            MessageBox.Show("Данные успешно добавлены");
            if (Vacation.IsChecked == true)
            {
                start_dateVacation = StartDateV.Text;
                end_dateVacation = StartDateV.Text;
            }
            else
            {
                start_dateVacation = null;
                end_dateVacation = null;
            }
        }
    }
}
