using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class StatisticWindow : Window
    {
        DataTable dataTable;

        public class DataObject
        {
            public string NameCompany { get; set; }
            public string CountEmployee { get; set; }
            public string NameEmployee { get; set; }
            public string Post { get; set; }
            public string SalaryAVG { get; set; }

        }

        public StatisticWindow()
        {
            InitializeComponent();

            dataTable = Model.Select($"SELECT * FROM salaryAVG()");
            var list = new ObservableCollection<DataObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(new DataObject() { NameEmployee = Convert.ToString(dataTable.Rows[i][1]), Post = Convert.ToString(dataTable.Rows[i][2]), SalaryAVG = Convert.ToString(dataTable.Rows[i][3]) });
            }
            this.dataGrid1.ItemsSource = list;


            dataTable = Model.Select($"SELECT * FROM employeeCount()");
            var list2 = new ObservableCollection<DataObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list2.Add(new DataObject() { NameCompany = Convert.ToString(dataTable.Rows[i][0]), CountEmployee = Convert.ToString(dataTable.Rows[i][1]) });
            }
            this.dataGrid2.ItemsSource = list2;
        }
    }
}
