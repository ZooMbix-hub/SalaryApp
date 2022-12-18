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
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=LAPTOP-08SA6AES\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=salary_db;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        public Window1()
        {
            InitializeComponent();
            DataTable dt_tableNumber = Select($"SELECT * FROM Employee");

            for (int i = 0; i < dt_tableNumber.Rows.Count; i++)
            {
                comboBoxTabel.Items.Add(dt_tableNumber.Rows[i][0]);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void comboBoxTabel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
