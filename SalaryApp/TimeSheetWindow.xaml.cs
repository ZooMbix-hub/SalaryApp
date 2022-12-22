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
        DataTable dataTable;
        string TableNumTime;
        public Window1(string TableNumTime)
        {
            InitializeComponent();
            this.TableNumTime = TableNumTime;
            

            dataTable = Model.Select($"SELECT * FROM Employee");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string tableNumber = Convert.ToString(dataTable.Rows[i][0]);
                string name = Convert.ToString(dataTable.Rows[i][1]);
                string result = $"{tableNumber} {name}";
                tableNumberCmbBox.Items.Add(result);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string date = "";
            try
            {
                string[] words = Date.Text.ToString().Split(new char[] { '.' });
                date = string.Join(".", "01", words[1], words[2]);
            }
            catch
            {
                MessageBox.Show("Введите дату");
            }
            try
            {
                string tableNumber = tableNumberCmbBox.Text.Split(' ')[0];
                Model.Select($"EXEC timesheet_entry '{Convert.ToInt32(tableNumber)}', '{date}', '{Convert.ToInt32(numberDaysTextBox.Text)}', '{Convert.ToInt32(numberNightTextBox.Text)}', '{Convert.ToInt32(numberRVD.Text)}'");
                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow(TableNumTime);
            employeewindow.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }
    }
}
