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
            //подключение к БД

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

            // вывод данных в comboBox

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string start_dateVacation;
            string end_dateVacation;
            
            if (Vacation.IsChecked == false)
            {
                start_dateVacation = StartDateV.Text;
                end_dateVacation = StartDateV.Text;
            }
            else
            {
                start_dateVacation = null;
                end_dateVacation = null;
            }

            string start_dateMedical;
            string end_dateMedical;

            if (Medical.IsChecked == false)
            {
                start_dateMedical = StartDateV.Text;
                end_dateMedical = StartDateV.Text;
            }
            else
            {
                start_dateMedical = null;
                end_dateMedical = null;
            }

            Select($"EXEC payment_entry '{Convert.ToInt32(TableNumber.Text)}', '{Date.Text}', '{start_dateMedical}', '{end_dateMedical}', '{start_dateVacation}', '{end_dateVacation}', '{Award.Text}', '{Allowance.Text}'");
            MessageBox.Show("Данные успешно добавлены");

        }

       
    }
}
