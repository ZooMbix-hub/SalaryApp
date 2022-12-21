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
        DataTable dataMedical;
        DataTable dataVacation;
        DataTable dataAllowances;
        DataTable dataAwardView;

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
            string[] words;
            string date = "";

            try
            {
                words = datePicker.Text.ToString().Split(new char[] { '.' });
                date = string.Join(".", "01", words[1], words[2]);
            }
            catch
            {
                MessageBox.Show("Введите дату");
            }

            try
            {
                dataTable = Model.Select($"EXEC salaryView '{date}', {tableNumber}");
                /*dataMedical = Model.Select($"EXEC madicalView '{date}', {tableNumber}");
                dataVacation = Model.Select($"EXEC vacationView '{date}', {tableNumber}");
                dataAllowances = Model.Select($"EXEC allowancesView '{date}', {tableNumber}");
                dataAwardView = Model.Select($"EXEC awardView '{date}', {tableNumber}");*/

                GetData();
            }
            catch
            {
                MessageBox.Show("Данной выплаты не существует");
            }
        }

        public void ChecDatak()
        {

        }

        public void GetUserData()
        {
            tableNumberLbl.Content = tableNumber;
            nameLbl.Content = dataTable.Rows[0][0];
            postLbl.Content = dataTable.Rows[0][4];
            divisionLbl.Content = dataTable.Rows[0][7];
            companynLbl.Content = dataTable.Rows[0][8];
        }

        public void GetData()
        {
            countDaysLbl.Content = dataTable.Rows[0][12];
            countNightsLbl.Content = dataTable.Rows[0][13];
            countRVDLbl.Content = dataTable.Rows[0][14];
            /*vacationLbl.Content = dataVacation.Rows[0][0];
            medicalLbl.Content = dataMedical.Rows[0][0];
            nameAllowanceLbl.Content = dataAllowances.Rows[0][0];
            allowanceLbl.Content = dataAwardView.Rows[0][0];*/

            /*prizeLbl.Content;
            accruedLbl.Content;
            withheldLbl.Content;
            paidLbl.Content;*/
        }
    }
}
