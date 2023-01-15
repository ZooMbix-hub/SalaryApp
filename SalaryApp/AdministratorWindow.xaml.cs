using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
using System.Xml.Linq;

namespace SalaryApp
{
    public interface IDataErrorInfo
    {
        string Error { get; }
        string this[string columnName] { get; }
    }

    public class PersonModel : IDataErrorInfo
    {
        public string FullName { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "FullName":
                        if (String.IsNullOrEmpty(FullName))
                            error = "Пустое поле";
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }

    public partial class AdministratorWindow : Window
    {
        private DataTable dataTable;
        private string tableNumber;
        private PersonModel error;

        public AdministratorWindow(string tableNumber)
        {
            InitializeComponent();

            error = new PersonModel();
            this.DataContext = error;

            this.tableNumber = tableNumber;

            dataTable = Model.Select($"SELECT * FROM RoleUser");
            GetComboBox(dataTable, Role);

            dataTable = Model.Select($"SELECT * FROM Company");
            GetComboBox(dataTable, Company);

            dataTable = Model.Select($"SELECT * FROM Post");
            GetComboBox(dataTable, Post);

            GetTableNumber();
        }

        private void GetComboBox(DataTable data, ComboBox comboBox)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string value = Convert.ToString(data.Rows[i][1]);

                comboBox.Items.Add(value);
            }
        }

        private void GetTableNumber()
        {
            dataTable = Model.Select($"SELECT * FROM Employee");

            int lastStr = Convert.ToInt32(dataTable.Rows.Count - 1);
            int tabNum = Convert.ToInt32(dataTable.Rows[lastStr][0]);
            TableNumberT.Text = Convert.ToString(tabNum + 1);
        }

        private void ClearFields()
        {
            Education.Text = "";
            Company.Text = "";
            LoginUser.Text = "";
            FullName.Text = "";
            PassportData.Text = "";
            Post.Text = "";
            PasswordUser.Text = "";
            DateOfBirth.Text = "";
            INN.Text = "";
            WorkExperience.Text = "";
            Role.Text = "";
            Telephone.Text = "";
            Snils.Text = "";
            ProfLevel.Text = "";
            AddressEmployee.Text = "";
            Requisites.Text = "";
            IsUnion.Text = "";

            GetTableNumber();
        }

        private void Button_ClickChange(object sender, RoutedEventArgs e)
        {
            EditDeleteWindow EditDelete = new EditDeleteWindow(tableNumber);
            EditDelete.Show();
            Close();
        }

        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        private void Button_ClickView(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow(tableNumber);
            employeewindow.Show();
            Close();
        }

        private void Button_ClickStatic(object sender, RoutedEventArgs e)
        {
            StatisticWindow statisticwindow = new StatisticWindow(tableNumber);
            statisticwindow.Show();
            Close();
        }

        private void Button_ClickShowUsers(object sender, RoutedEventArgs e)
        {
            ShowUsersWindow showUsersWindow = new ShowUsersWindow(tableNumber);
            showUsersWindow.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DirectoryEditorWindow directoryEditor = new DirectoryEditorWindow(tableNumber);
            directoryEditor.Show();
            Close();
        }

        [Obsolete]
        private void Button_ClickAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                string union = IsUnion.Text == "Да" ? "1" : "0";

                var password = Hasher.Encrypt(PasswordUser.Text);

                Model.Select($"EXEC employeeEntry '{Convert.ToInt32(TableNumberT.Text)}', '{FullName.Text}', '{Convert.ToInt32(WorkExperience.Text)}', '{Convert.ToInt32(ProfLevel.Text)}', '{union}', " +
                    $"'{Company.Text}', '{Post.Text}', '{LoginUser.Text}', '{password}', '{Role.Text}', '{DateOfBirth.Text}', '{AddressEmployee.Text}', '{Telephone.Text}', '{Education.Text}'" +
                    $", '{INN.Text}', '{PassportData.Text}', '{Requisites.Text}', '{Snils.Text}'");

                ClearFields();

                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
        }
    }
}
