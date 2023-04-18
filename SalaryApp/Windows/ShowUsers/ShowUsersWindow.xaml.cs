using System;
using System.Collections;
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
    public partial class ShowUsersWindow : Window
    {
        DataTable dataTable;
        string tableNumber;

        public class DataObject
        {
            public string TableNumber { get; set; }
            public string NameUser { get; set; }
            public string DateOfBirth { get; set; }
            public string Phone { get; set; }
            public string Adress { get; set; }
            public string Education { get; set; }
            public string Passport { get; set; }
            public string Inn { get; set; }
            public string Snils { get; set; }
            public string Requisites { get; set; }
            public string Company { get; set; }
            public string Post { get; set; }
            public string Experience { get; set; }
            public string ProfileLevel { get; set; }
            public string TradeUnion { get; set; }
        }

        public ShowUsersWindow(string tableNumber)
        {
            InitializeComponent();

            dataTable = Model.Select("SELECT Employee.TableNumber, Employee.FullName, PersonalData.DateOfBirth, " +
                "PersonalData.AddressEmployee, PersonalData.Telephone, PersonalData.Education, PersonalData.PassportData, " +
                "PersonalData.INN, PersonalData.Snils, PersonalData.Requisites, Company.NameCompany, Post.NamePost, Employee.WorkExperience, Employee.ProfLevel, " +
                "Employee.IsUnion FROM PersonalData, Employee, Company, Post, Subdivision, UserData WHERE Employee.FK_Post = Post.Id " +
                "AND Post.FK_Sub = Subdivision.Id AND Employee.FK_Company = Company.Id AND PersonalData.FK_TableNumber = Employee.TableNumber " +
                "AND Employee.FK_UserData = UserData.Id");

            var list = new ObservableCollection<DataObject>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(new DataObject()
                {
                    TableNumber = Convert.ToString(dataTable.Rows[i][0]),
                    NameUser = Convert.ToString(dataTable.Rows[i][1]),
                    DateOfBirth = Convert.ToString(dataTable.Rows[i][2]),
                    Phone = Convert.ToString(dataTable.Rows[i][3]),
                    Adress = Convert.ToString(dataTable.Rows[i][4]),
                    Education = Convert.ToString(dataTable.Rows[i][5]),
                    Passport = Convert.ToString(dataTable.Rows[i][6]),
                    Inn = Convert.ToString(dataTable.Rows[i][7]),
                    Snils = Convert.ToString(dataTable.Rows[i][8]),
                    Requisites = Convert.ToString(dataTable.Rows[i][9]),
                    Company = Convert.ToString(dataTable.Rows[i][10]),
                    Post = Convert.ToString(dataTable.Rows[i][11]),
                    Experience = Convert.ToString(dataTable.Rows[i][12]),
                    ProfileLevel = Convert.ToString(dataTable.Rows[i][13]),
                    TradeUnion = Convert.ToString(dataTable.Rows[i][14])
                });
            }

            this.gridUsers.ItemsSource = list;
            this.tableNumber = tableNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdministratorWindow administratorWindow = new AdministratorWindow(tableNumber);
            administratorWindow.Show();
            Close();
        }
    }
}
