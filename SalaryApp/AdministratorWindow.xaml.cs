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
    public partial class AdministratorWindow : Window
    {
        DataTable dataTable;
        string tableNumber;
        PersonModel error;

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
                            {
                                error = "Пустое поле";
                            }
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

        public interface IDataErrorInfo
        {
            string Error { get; }
            string this[string columnName] { get; }
        }

        public AdministratorWindow(string tableNumber)
        {
            InitializeComponent();
            error = new PersonModel();
            this.DataContext = error;

            this.tableNumber = tableNumber;
            dataTable = Model.Select($"SELECT * FROM RoleUser");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string roles = Convert.ToString(dataTable.Rows[i][1]);
                
                Role.Items.Add(roles);
            }

            dataTable = Model.Select($"SELECT * FROM Company");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string companies = Convert.ToString(dataTable.Rows[i][1]);

                Company.Items.Add(companies);
            }

            dataTable = Model.Select($"SELECT * FROM Post");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string posts = Convert.ToString(dataTable.Rows[i][1]);

                Post.Items.Add(posts);
            }

            GetTableNumber();
        }
      
        
        /// <summary>
        /// Изменения сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickChange(object sender, RoutedEventArgs e)
        {
            EditDeleteWindow EditDelete = new EditDeleteWindow(tableNumber);
            EditDelete.Show();
            Close();
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        /// <summary>
        /// Просмотр зп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickView(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeewindow = new EmployeeWindow(tableNumber);
            employeewindow.Show();
            Close();
        }

        /// <summary>
        /// Статистика данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickStatic(object sender, RoutedEventArgs e)
        {
            StatisticWindow statisticwindow = new StatisticWindow(tableNumber);
            statisticwindow.Show();
            Close();
        }

        private void Button_ClickAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                string union = IsUnion.Text == "Да" ? "1" : "0";

                //var password = Hasher.Encrypt(PasswordUser.Text);

                Model.Select($"EXEC employeeEntry '{Convert.ToInt32(TableNumberT.Text)}', '{FullName.Text}', '{Convert.ToInt32(WorkExperience.Text)}', '{Convert.ToInt32(ProfLevel.Text)}', '{union}', " +
                    $"'{Company.Text}', '{Post.Text}', '{LoginUser.Text}', '{PasswordUser.Text}', '{Role.Text}', '{DateOfBirth.Text}', '{AddressEmployee.Text}', '{Telephone.Text}', '{Education.Text}'" +
                    $", '{INN.Text}', '{PassportData.Text}', '{Requisites.Text}', '{Snils.Text}'");

                ClearFields();

                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DirectoryEditorWindow directoryEditor  = new DirectoryEditorWindow(tableNumber);
            directoryEditor.Show();
            Close();
        }
    }
}
