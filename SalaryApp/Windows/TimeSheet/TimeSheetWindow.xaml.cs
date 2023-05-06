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
using System.Xml.Linq;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;

namespace SalaryApp
{
    public partial class Window1 : Window
    {
        DataTable dataTable;
        string tableNumber;

        public class DataObject
        {
            public string Date { get; set; }
            public string Days { get; set; }
            public string Night { get; set; }
            public string RVD { get; set; }
        }
      
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
            // Проверка полей
            if (tableNumberCmbBox.SelectedItem == null)
                tableNumberCmbBox.BorderBrush= new SolidColorBrush(Colors.Red);
            else
                tableNumberCmbBox.BorderBrush = new SolidColorBrush(Colors.Gray);

            string textDays = numberDaysTextBox.Text;
            bool checkDays = true;

            if (String.IsNullOrEmpty(numberDaysTextBox.Text))
                checkDays = false;

            for (int i = 0; i < textDays.Length; i++)
            {
                if (char.IsLetter(textDays[i]))
                {
                    checkDays = false;
                    break;
                }
            }

            if (checkDays == false)
                numberDaysTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            else
                numberDaysTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);

            string textNight = numberNightTextBox.Text;
            bool checkNight = true;

            if (String.IsNullOrEmpty(numberNightTextBox.Text))
                checkNight = false;

            for (int i = 0; i < textNight.Length; i++)
            {
                if (char.IsLetter(textNight[i]))
                {
                    checkNight = false;
                    break;
                }
            }
            if (checkNight == false)
                numberNightTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            else
                numberNightTextBox.BorderBrush = new SolidColorBrush(Colors.Gray);

            string textRVD = numberRVD.Text;
            bool checkRVD = true;

            if (String.IsNullOrEmpty(numberRVD.Text))
                checkRVD = false;

            for (int i = 0; i < textRVD.Length; i++)
            {
                if (char.IsLetter(textRVD[i]))
                {
                    checkRVD = false;
                    break;
                }
            }

            if (checkRVD == false)
                numberRVD.BorderBrush = new SolidColorBrush(Colors.Red);
            else
                numberRVD.BorderBrush = new SolidColorBrush(Colors.Gray);

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

                if (CheckRow(tableNumber, date) == true)
                    return;

                Model.Select($"EXEC timesheet_entry '{Convert.ToInt32(tableNumber)}', '{date}', '{Convert.ToInt32(numberDaysTextBox.Text)}', '{Convert.ToInt32(numberNightTextBox.Text)}', '{Convert.ToInt32(numberRVD.Text)}'");
                Refresh(tableNumber);
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

        private bool CheckRow(string tableNumber, string date)
        {
            DataTable existTable = Model.Select($"SELECT * FROM TimeSheet WHERE FK_TableNumber = '{tableNumber}' AND DateTimeSheet = '{date}'");
            
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

        private void ClearFields()
        {
            numberDaysTextBox.Text = "";
            numberNightTextBox.Text = "";
            numberRVD.Text = "";
        }

        private void tableNumberCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            string tableNumber = tableNumberCmbBox.SelectedItem.ToString().Split(' ')[0];
            Refresh(tableNumber);
        }

        private void Button_ClickChange(object sender, RoutedEventArgs e)
        {
            string tableNumber = tableNumberCmbBox.SelectedItem.ToString().Split(' ')[0];
            var celldate = dataGrid1.SelectedCells[0];
            var date = (celldate.Column.GetCellContent(celldate.Item) as TextBlock).Text;
            var cellDays = dataGrid1.SelectedCells[1];
            var days = (cellDays.Column.GetCellContent(cellDays.Item) as TextBlock).Text;
            var cellNight = dataGrid1.SelectedCells[2];
            var hight = (cellNight.Column.GetCellContent(cellNight.Item) as TextBlock).Text;
            var cellRVD = dataGrid1.SelectedCells[3];
            var RVD = (cellRVD.Column.GetCellContent(cellRVD.Item) as TextBlock).Text;
            Model.Select($"EXEC timeSheetDelete '{tableNumber}', '{date}', '{days}', '{hight}', '{RVD}'");
            Refresh(tableNumber);
            Model.Select($"EXEC EditTimeSheet '{tableNumber}', '{date}', '{days}', '{hight}', '{RVD}'");
            refresh(tableNumber);
        }
        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            string tableNumber = tableNumberCmbBox.SelectedItem.ToString().Split(' ')[0];
            var cellInfo = dataGrid1.SelectedCells[0];
            var date = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            Model.Select($"EXEC timeSheetDelete '{tableNumber}', '{date}'");
            Refresh(tableNumber);
        }
       
        private void Refresh(string tableNumber)
        {
            dataTable = Model.Select($"SELECT * FROM TimeSheet WHERE FK_TableNumber = '{tableNumber}'");

            var list = new ObservableCollection<DataObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(new DataObject()
                {
                    Date = Convert.ToString(dataTable.Rows[i][2]).Split(' ')[0],
                    Days = Convert.ToString(dataTable.Rows[i][3]),
                    Night = Convert.ToString(dataTable.Rows[i][4]),
                    RVD = Convert.ToString(dataTable.Rows[i][5])
                });
            }
            this.dataGrid1.ItemsSource = list;
        }
    }
}
