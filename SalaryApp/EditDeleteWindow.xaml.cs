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
using System.Windows.Threading;
using System.Xml.Linq;


namespace SalaryApp
{
    public partial class EditDeleteWindow : Window
    {
        DataTable dataTable;
        DataTable dataTableData;
        DataTable dataTableCompany;
        DataTable dataTablePost;
        DataTable dataTableDelet;
        DataTable dataTableEdit;
        string tableNumber;

        public EditDeleteWindow(string tableNumber)
        {
            InitializeComponent();

            this.tableNumber = tableNumber;

            GetTableNumbers();

            dataTableCompany = Model.Select($"SELECT NameCompany, INN FROM Company");
            for (int i = 0; i < dataTableCompany.Rows.Count; i++)
            {
                string nameCompany = Convert.ToString(dataTableCompany.Rows[i][0]);
                string resultCompany = $"{nameCompany}";
                Company.Items.Add(resultCompany);
            }

            dataTablePost = Model.Select($"Select Post.NamePost, Subdivision.NameSub\r\nFrom Post, Subdivision\r\nWhere Post.FK_Sub = Subdivision.Id");
            for (int i = 0; i < dataTablePost.Rows.Count; i++)
            {
                string namePost = Convert.ToString(dataTablePost.Rows[i][0]);
                string resultPost = $"{namePost}";
                Post.Items.Add(resultPost);
            }
        }

        private void TableNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableNumber.SelectedValue != null)
            {
                dataTableData = Model.Select($"EXEC DataForAdmin {Convert.ToInt32(TableNumber.SelectedValue.ToString())}");
                DateOfBirth.Text = dataTableData.Rows[0][0].ToString();
                AddressEmployee.Text = dataTableData.Rows[0][1].ToString();
                Telephone.Text = dataTableData.Rows[0][2].ToString();
                Education.Text = dataTableData.Rows[0][3].ToString();
                INN.Text = dataTableData.Rows[0][4].ToString();
                PassportData.Text = dataTableData.Rows[0][5].ToString();
                Requisites.Text = dataTableData.Rows[0][6].ToString();
                Snils.Text = dataTableData.Rows[0][7].ToString();
                TableNumberT.Text = dataTableData.Rows[0][8].ToString();
                FullName.Text = dataTableData.Rows[0][9].ToString();
                WorkExperience.Text = dataTableData.Rows[0][10].ToString();
                ProfLevel.Text = dataTableData.Rows[0][11].ToString();
                IsUnion.Text = dataTableData.Rows[0][12].ToString();
                LoginUser.Text = dataTableData.Rows[0][17].ToString();
                PasswordUser.Text = dataTableData.Rows[0][18].ToString();

                for (int i = 0; i < dataTableCompany.Rows.Count; i++)
                {
                    if (Convert.ToString(dataTableCompany.Rows[i][0]) == dataTableData.Rows[0][13].ToString())
                        Company.Text = Company.Items.GetItemAt(i).ToString();
                }

                for (int i = 0; i < dataTablePost.Rows.Count; i++)
                {
                    if (Convert.ToString(dataTablePost.Rows[i][0]) == dataTableData.Rows[0][15].ToString())
                        Post.Text = Post.Items.GetItemAt(i).ToString();
                }
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataTableDelet = Model.Select($"EXEC Delet {TableNumberT.Text}, '{LoginUser.Text}', '{PasswordUser.Text}'");

            ClearFields();

            MessageBox.Show("Сотрудник удален");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableEdit = Model.Select($"EXEC Edit '{DateOfBirth.Text}', '{AddressEmployee.Text}', '{Telephone.Text}', '{Education.Text}', '{INN.Text}', " +
                    $"'{PassportData.Text}', '{Requisites.Text}', '{Snils.Text}', '{TableNumberT.Text}', '{FullName.Text}'," +
                    $"'{WorkExperience.Text}', '{ProfLevel.Text}', '{IsUnion.Text}', '{Company.Text}'," +
                    $"'{Post.Text}', '{LoginUser.Text}', '{PasswordUser.Text}'");

                ClearFields();

                MessageBox.Show("Сотрудник изменен");
            }
            catch 
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdministratorWindow adminwindow = new AdministratorWindow(tableNumber);
            adminwindow.Show();
            Close();
        }

        private void GetTableNumbers()
        {
            dataTable = Model.Select($"SELECT * FROM Employee");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                TableNumber.Items.Add(dataTable.Rows[i][0]);
            }
        }

        private void ClearFields()
        {
            TableNumber.Text = "";
            TableNumberT.Text = "";
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
            Telephone.Text = "";
            Telephone.Text = "";
            ProfLevel.Text = "";
            AddressEmployee.Text = "";
            Requisites.Text = "";
            IsUnion.Text = "";

            GetTableNumbers();
        }
    }
}
