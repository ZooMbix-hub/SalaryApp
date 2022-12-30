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
using System.Xml.Linq;
using System.Security.Principal;

namespace SalaryApp
{
    public partial class MainWindow : Window
    {
        DataTable dataTable;
        public string role;
        public string tableNumber;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //проверка логина и пароля
            try
            {
                var password = Hasher.Encrypt(passwordTxt.Password);

                dataTable = Model.Select($"EXEC autorization '{loginTxt.Text}', '{password}'");
                role = dataTable.Rows[0][0].ToString();
                tableNumber = dataTable.Rows[0][1].ToString();
            }
            catch 
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            
            // разграничение доступа
            switch (role)
            {
                case "Ответственный за табель":
                    Window1 TimeSheetWindow = new Window1(tableNumber); //поменять название
                    TimeSheetWindow.Show();
                    Close();
                    break;
                case "Сотрудник":
                    EmployeeWindow EmployeeWindow = new EmployeeWindow(tableNumber);
                    EmployeeWindow.Show();
                    Close();
                    break;
                case "Бухгалер":
                    Аccountant Аccount = new Аccountant(tableNumber);  //поменять название
                    Аccount.Show();
                    Close();
                    break;
                case "Администратор":
                    AdministratorWindow Administrator = new AdministratorWindow(tableNumber);
                    Administrator.Show();
                    Close();
                    break;
            }
        }
    }
}