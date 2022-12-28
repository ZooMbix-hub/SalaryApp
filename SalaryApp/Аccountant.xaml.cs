using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SalaryApp
{
    public partial class Аccountant : Window
    {
        DataTable dataTable;
        DataTable dataTableDate;
        DataTable dataTableMedical;
        DataTable dataTableVacation;
        DataTable dataTableAward;
        DataTable dataTableAllowances;
        DataTable tabnum;
        string tableNumber;
        public class DataObject
        {
            public string Date { get; set; }
            public string startVacation { get; set; }
            public string endVacation { get; set; }
            public string startMedical { get; set; }
            public string endMedical { get; set; }
            public string award { get; set; }
            public string allowance { get; set; }
            public string DateTime { get; set; }
            public string Days { get; set; }
            public string Night { get; set; }
            public string RVD { get; set; }
        }
        
        public Аccountant(string tableNumber)
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
            // Проверка полей
            if (tableNumberCmbBox.SelectedItem == null)
                tableNumberCmbBox.BorderBrush = new SolidColorBrush(Colors.Red);
            else
                tableNumberCmbBox.BorderBrush = new SolidColorBrush(Colors.Gray);

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
                refresh(tableNumber.ToString());
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
            datePicker.Text = "";
            StartDateV.Text = "";
            EndDateV.Text = "";
            StartDateM.Text = "";
            EndDateM.Text = "";
            AwardCmbBox.Text = "";
            AllowanceCmbBox.Text = "";
        }
        private void Button_ClickChange(object sender, RoutedEventArgs e)
        {
            string tableNumber = tableNumberCmbBox.SelectedItem.ToString().Split(' ')[0];
            var celldate = dataGrid1.SelectedCells[0];
            var date = (celldate.Column.GetCellContent(celldate.Item) as TextBlock).Text;

            var cellStartVac = dataGrid1.SelectedCells[1];
            var StartVac = (cellStartVac.Column.GetCellContent(cellStartVac.Item) as TextBlock).Text;

            var cellEndVac = dataGrid1.SelectedCells[2];
            var EndVac = (cellEndVac.Column.GetCellContent(cellEndVac.Item) as TextBlock).Text;

            var cellStartMed = dataGrid1.SelectedCells[3];
            var StartMed = (cellStartMed.Column.GetCellContent(cellStartMed.Item) as TextBlock).Text;

            var cellEndMed = dataGrid1.SelectedCells[4];
            var EndMed = (cellEndMed.Column.GetCellContent(cellEndMed.Item) as TextBlock).Text;

            var cellAward = dataGrid1.SelectedCells[5];
            var Award = (cellAward.Column.GetCellContent(cellAward.Item) as TextBlock).Text;

            var cellAllowance = dataGrid1.SelectedCells[6];
            var Allowance = (cellAllowance.Column.GetCellContent(cellAllowance.Item) as TextBlock).Text;


            Model.Select($"EXEC paymentChange '{tableNumber}', '{date}', '{StartVac}', '{EndVac}', '{StartMed}', '{EndMed}', '{Award}', '{Allowance}'");
            refresh(tableNumber);

        }
        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {

            string tableNumber = tableNumberCmbBox.SelectedItem.ToString().Split(' ')[0];
            var cellInfo = dataGrid1.SelectedCells[0];
            var date = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            Model.Select($"EXEC paymentDelete '{tableNumber}', '{date}'");
            refresh(tableNumber);
        }

        

        private void tableNumberCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tableNumber = tableNumberCmbBox.SelectedItem.ToString().Split(' ')[0];
            refresh(tableNumber);
            refreshTime(tableNumber);
        }
        private void refresh(string tableNumber)
        {
            dataTableDate = Model.Select($"EXEC paymentDate '{tableNumber}'");
            dataTableMedical = Model.Select($"EXEC paymentMedical '{tableNumber}'");
            dataTableVacation = Model.Select($"EXEC paymentVacation '{tableNumber}'");
            dataTableAward = Model.Select($"EXEC paymentAward '{tableNumber}'");
            dataTableAllowances = Model.Select($"EXEC paymentAllowances '{tableNumber}'");

            
            var list = new ObservableCollection<DataObject>();
            for (int i = 0; i < dataTableDate.Rows.Count; i++)
            {
                string startVac = " ";
                string endVac = " ";
                try
                {
                    startVac = Convert.ToString(dataTableVacation.Rows[i][0]).Split(' ')[0];
                    endVac = Convert.ToString(dataTableVacation.Rows[i][1]).Split(' ')[0];
                }
                catch { }
                string startMed = " ";
                string endMed = " ";
                try
                {
                    startMed = Convert.ToString(dataTableMedical.Rows[i][0]).Split(' ')[0];
                    endMed = Convert.ToString(dataTableMedical.Rows[i][1]).Split(' ')[0];
                }
                catch { }
                string award = " ";
                
                try
                {
                    award = Convert.ToString(dataTableAward.Rows[i][0]);  
                }
                catch  { }
                string allowance = " ";

                try
                {
                    allowance = Convert.ToString(dataTableAllowances.Rows[i][0]);
                }
                catch { }
                list.Add(new DataObject()
                {
                    Date = Convert.ToString(dataTableDate.Rows[i][0]).Split(' ')[0].Split(' ')[0],

                    startVacation = startVac,
                    endVacation = endVac,

                    startMedical = startMed,
                    endMedical = endMed,

                    award = award,
                    allowance = allowance
                });
            }

            this.dataGrid1.ItemsSource = list;
        }

        private void refreshTime(string tableNumber)
        {
            dataTable = Model.Select($"SELECT * FROM TimeSheet WHERE FK_TableNumber = '{tableNumber}'");

            var list = new ObservableCollection<DataObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(new DataObject()
                {
                    DateTime = Convert.ToString(dataTable.Rows[i][2]).Split(' ')[0],
                    Days = Convert.ToString(dataTable.Rows[i][3]),
                    Night = Convert.ToString(dataTable.Rows[i][4]),
                    RVD = Convert.ToString(dataTable.Rows[i][5])
                });
            }
            this.dataGrid2.ItemsSource = list;
        }
    }
}
