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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalaryApp
{
    public partial class StatisticWindow : Window
    {
        DataTable dataTable;
        string tableNumber;

        public class DataObject
        {
            public string NameCompany { get; set; }
            public string CountEmployee { get; set; }
            public string NameEmployee { get; set; }
            public string Post { get; set; }
            public string SalaryAVG { get; set; }
        }

        public StatisticWindow(string tableNumber)
        {
            InitializeComponent();

            this.tableNumber = tableNumber;

            string query = $"SELECT * FROM salaryAVG()";
            GetAllUsers(query);

            dataTable = Model.Select($"SELECT * FROM employeeCount()");
            var list2 = new ObservableCollection<DataObject>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list2.Add(new DataObject() { 
                    NameCompany = Convert.ToString(dataTable.Rows[i][0]),
                    CountEmployee = Convert.ToString(dataTable.Rows[i][1]) 
                });
            }
            this.gridEmployee.ItemsSource = list2;

            dataTable = Model.Select($"SELECT NamePost FROM salaryAVG() GROUP BY NamePost");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                filterPost.Items.Add(dataTable.Rows[i][0]);
            }
            filterPost.Items.Add("Все");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdministratorWindow adminwindow = new AdministratorWindow(tableNumber);
            adminwindow.Show();
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterPost.SelectedValue != null)
            {
                string query = $"SELECT * FROM salaryAVG() WHERE NamePost = '{filterPost.SelectedValue}'";
                GetAllUsers(query);
            }

            if (filterPost.SelectedValue.ToString() == "Все")
            {
                string query = $"SELECT * FROM salaryAVG()";
                GetAllUsers(query);
            }
        }

        private void GetAllUsers(string query)
        {
            try
            {
                DataTable data = Model.Select(query);
                var list = new ObservableCollection<DataObject>();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    list.Add(new DataObject()
                    {
                        NameEmployee = Convert.ToString(data.Rows[i][1]),
                        Post = Convert.ToString(data.Rows[i][2]),
                        SalaryAVG = Convert.ToString(data.Rows[i][3])
                    });
                }
                this.gridSalary.ItemsSource = list;
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }
    }
}
