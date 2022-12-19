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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalaryApp
{
    
    public partial class MainWindow : Window
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

        public MainWindow()
        {
            InitializeComponent();
        }

        public string role, tableNumber;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //проверка логина и пароля

            try
            {
                DataTable dt_user = Select($"EXEC autorization '{login.Text}', '{password.Password.ToString()}'");
                role = dt_user.Rows[0][0].ToString();
                tableNumber = dt_user.Rows[0][1].ToString();
            }
            catch 
            {
                MessageBox.Show("Неверный логин или пароль");
            }
           
            // разграничение доступа

            if (role == "Ответственный за табель")
            {
                Window1 TimeSheetWindow = new Window1(); //поменять название
                TimeSheetWindow.Show();
            }

            if (role == "Сотрудник")
            {
                
            }

            if (role == "Бухгалер")
            {
                Аccountant Аccount = new Аccountant(); 
                Аccount.Show();
            }

            if (role == "Администратор")
            {
               
            }

        }
    }
}