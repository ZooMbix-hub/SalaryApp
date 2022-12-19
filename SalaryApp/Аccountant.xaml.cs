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
    public partial class Аccountant : Window
    {
        DataTable dataTable;

        public Аccountant()
        {
            InitializeComponent();

            // вывод данных в comboBox
            dataTable = Model.Select($"SELECT * FROM Employee");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                TableNumber.Items.Add(dataTable.Rows[i][0]);
            }

            dataTable = Model.Select($"SELECT * FROM TypeОfAward");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Award.Items.Add(dataTable.Rows[i][1]);
            }

            dataTable = Model.Select($"SELECT * FROM TypeОfAllowances");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Allowance.Items.Add(dataTable.Rows[i][1]);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string startDateVacation;
            string endDateVacation;
            
            if (Vacation.IsChecked == false)
            {
                startDateVacation = StartDateV.Text;
                endDateVacation = StartDateV.Text;
            }
            else
            {
                startDateVacation = null;
                endDateVacation = null;
            }

            string startDateMedical;
            string endDateMedical;

            if (Medical.IsChecked == false)
            {
                startDateMedical = StartDateV.Text;
                endDateMedical = StartDateV.Text;
            }
            else
            {
                startDateMedical = null;
                endDateMedical = null;
            }

            Model.Select($"EXEC payment_entry '{Convert.ToInt32(TableNumber.Text)}', '{Date.Text}', '{startDateMedical}', '{endDateMedical}', '{startDateVacation}', '{endDateVacation}', '{Award.Text}', '{Allowance.Text}'");
            MessageBox.Show("Данные успешно добавлены");
        }
    }
}
