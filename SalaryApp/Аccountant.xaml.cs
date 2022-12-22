using System;
using System.Data;
using System.Windows;

namespace SalaryApp
{
    public partial class Аccountant : Window
    {
        DataTable dataTable;
        DataTable tabnum;
        string tableNumber;
        public Аccountant(string tableNumber)
        {
            InitializeComponent();

            this.tableNumber = tableNumber;

            // вывод данных в comboBox
            dataTable = Model.Select($"SELECT * FROM Employee");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string tableNumberData = Convert.ToString(dataTable.Rows[i][0]);
                string name = Convert.ToString(dataTable.Rows[i][1]);
                string result = $"{tableNumberData} {name}";
                tableNumberCmbBox.Items.Add(result);
            }

            dataTable = Model.Select($"SELECT * FROM TypeОfAward");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string nameAward = Convert.ToString(dataTable.Rows[i][1]);

                AwardCmbBox.Items.Add(nameAward);
            }

            dataTable = Model.Select($"SELECT * FROM TypeОfAllowances");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string nameAllowance = Convert.ToString(dataTable.Rows[i][1]);

                AllowanceCmbBox.Items.Add(nameAllowance);
            }

            tabnum = Model.Select($"SELECT * FROM TypeОfAllowances");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                int tableNumber = Convert.ToInt32(tableNumberCmbBox.Text.Split(' ')[0]);

                string startDateV = StartDateV.Text;
                string endDateV = EndDateV.Text;
                string startDateM = StartDateM.Text;
                string endDateM = EndDateM.Text;

                Model.Select($"EXEC payment_entry '{tableNumber}', '{date}', {Check(startDateV)}, {Check(endDateV)}, {Check(startDateM)}, {Check(endDateM)}, '{AwardCmbBox.Text}', '{AllowanceCmbBox.Text}'");
                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }

        }

        public string Check(string value)
        {
            if (value == "")
                return "null";
            else
                return $"'{value}'";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow(tableNumber);
            employeewindow.Show();
            Close();
        }
    }
}
