using System;
using System.Collections.Generic;
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
    public partial class EmployeeWindow : Window
    {
        DataTable dataTable;
        string tableNumber;

        public EmployeeWindow(string tableNumber)
        {
            InitializeComponent();

            this.tableNumber = tableNumber;
            dataTable = Model.Select($"EXEC tableView {tableNumber}");

            GetUserData();
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
                dataTable = Model.Select($"EXEC salaryView '{date}', {tableNumber}");

                GetPaymentData();

                CheckData("madicalView", date, medicalLbl);

                CheckData("vacationView", date, vacationLbl);

                CheckData("allowancesView", date, nameAllowanceLbl, allowanceLbl);

                CheckData("awardView", date, namePrizeLbl, prizeLbl);
            }
            catch
            {
                MessageBox.Show("Данная выплата отсутствует");
            }
        }

        public void GetUserData()
        {
            tableNumberLbl.Content = tableNumber;
            nameLbl.Content = dataTable.Rows[0][0];
            postLbl.Content = dataTable.Rows[0][4];
            divisionLbl.Content = dataTable.Rows[0][7];
            companynLbl.Content = dataTable.Rows[0][8];
        }

        public void GetPaymentData()
        {
            countDaysLbl.Content = dataTable.Rows[0][12];
            countNightsLbl.Content = dataTable.Rows[0][13];
            countRVDLbl.Content = dataTable.Rows[0][14];
            addPaymentLbl.Content = dataTable.Rows[0][17];
            accruedLbl.Content = dataTable.Rows[0][18];
            withheldLbl.Content = dataTable.Rows[0][21];
            paidLbl.Content = dataTable.Rows[0][22];
        }

        public void CheckData(string nameProcedure, string date, Label label)
        {
            try
            {
                DataTable data = Model.Select($"EXEC {nameProcedure} '{date}', {tableNumber}");
                label.Content = data.Rows[0][0];
            }
            catch
            {
                label.FontStyle = FontStyles.Italic;
                label.Content = "Отсутсвует";
            }
        }

        public void CheckData(string nameProcedure, string date, Label labelFirst, Label labelSecond)
        {
            try
            {
                DataTable data = Model.Select($"EXEC {nameProcedure} '{date}', {tableNumber}");
                labelFirst.Content = data.Rows[0][0];
                labelSecond.Content = data.Rows[0][1];
            }
            catch
            {
                labelFirst.FontStyle = labelSecond.FontStyle = FontStyles.Italic;
                labelFirst.Content = "Отсутсвует";
                labelSecond.Content = "Отсутсвует";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
