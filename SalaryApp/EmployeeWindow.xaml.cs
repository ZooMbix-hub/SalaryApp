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

        public EmployeeWindow()
        {
            InitializeComponent();
            dataTable = Model.Select("Select * FROM Employee");
        }
    }
}
