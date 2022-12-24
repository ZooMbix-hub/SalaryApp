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
        string tableNumber;

        public Window1(string tableNumber)
        {
            InitializeComponent();

            this.tableNumber = tableNumber;

            dataTable = Model.Select($"SELECT * FROM Employee");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string tableNumberData = Convert.ToString(dataTable.Rows[i][0]);
                string name = Convert.ToString(dataTable.Rows[i][1]);
                string result = $"{tableNumberData} {name}";
                tableNumberCmbBox.Items.Add(result);
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            string date = "";

            try
            {
                string[] words = datePicker.Text.ToString().Split(new char[] { '.' });
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
                ClearFields();
                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
        }

        private void Viewing(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow(tableNumber);
            employeewindow.Show();
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        private void ClearFields()
        {
            tableNumberCmbBox.Text = "";
            datePicker.Text = "";
            numberDaysTextBox.Text = "";
            numberNightTextBox.Text = "";
            numberRVD.Text = "";
        }
    }
}
