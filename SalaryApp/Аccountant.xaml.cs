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
                int tableNumber = Convert.ToInt32(tableNumberCmbBox.Text.Split(' ')[0]);

                if (CheckRow(tableNumber.ToString(), date) == true)
                    return;

                string startDateV = StartDateV.Text;
                string endDateV = EndDateV.Text;
                string startDateM = StartDateM.Text;
                string endDateM = EndDateM.Text;

                Model.Select($"EXEC payment_entry '{tableNumber}', '{date}', {Check(startDateV)}, {Check(endDateV)}, {Check(startDateM)}, {Check(endDateM)}, '{AwardCmbBox.Text}', '{AllowanceCmbBox.Text}'");
                
                ClearFields();
                
                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
        }

        private bool CheckRow(string tableNumber, string date)
        {
            DataTable existTable = Model.Select($"SELECT * FROM Payment, TimeSheet WHERE Payment.FK_TableNumber = '{tableNumber}' AND TimeSheet.DateTimeSheet = '{date}' And Payment.FK_TableList = TimeSheet.Id");

            try
            {
                if (existTable.Rows[0] != null)
                {
                    MessageBox.Show("Данные уже существуют");
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public string Check(string value)
        {
            if (value == "")
                return "null";
            else
                return $"'{value}'";
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        private void Viewing(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow(tableNumber);
            employeewindow.Show();
            Close();
        }

        private void ClearFields()
        {
            tableNumberCmbBox.Text = "";
            datePicker.Text = "";
            StartDateV.Text = "";
            EndDateV.Text = "";
            StartDateM.Text = "";
            EndDateM.Text = "";
            AwardCmbBox.Text = "";
            AllowanceCmbBox.Text = "";
        }
    }
}
