using System;
using System.Collections.Generic;
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
    public partial class AdministratorWindow : Window
    {
        string TableNumberAdmin;
        public AdministratorWindow(string TableNumberAdmin)
        {
            InitializeComponent();
            this.TableNumberAdmin = TableNumberAdmin;
            TableNumAdmin.Text = TableNumberAdmin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditDeleteWindow EditDelete = new EditDeleteWindow(TableNumberAdmin);
            EditDelete.Show();
            Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();

            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow(TableNumberAdmin);
            employeewindow.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StatisticWindow statisticwindow = new StatisticWindow(TableNumberAdmin);
            statisticwindow.Show();
            Close();
        }
    }
}
