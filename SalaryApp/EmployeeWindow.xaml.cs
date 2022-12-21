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
        private string tableNumber;

        public EmployeeWindow()
        {
            InitializeComponent();
            dataTable = Model.Select("EXEC salaryView '01-06-2020', 1009");
            MessageBox.Show(dataTable.Rows[0][7].ToString());
        }

        public EmployeeWindow(string tableNumber)
        {
            this.tableNumber = tableNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
