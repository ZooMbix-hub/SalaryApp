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
    
    public partial class DirectoryEditorWindow : Window
    {
        DataTable dataTableComp;
        DataTable dataTablePost;
        DataTable dataTableAllowances;
        DataTable dataTableAward;
        DataTable dataTableRegion;
        DataTable dataTableSubdivision;
        DataTable dataTableCompWhere;
        DataTable dataTablePostWhere;
        DataTable dataTableAllowancesWhere;
        DataTable dataTableAwardWhere;
        DataTable dataTableEditCompany;
        DataTable dataTableEditPost;
        DataTable dataTableEditAllowances;
        DataTable dataTableEditAward;
        DataTable dataTableDeleteCompany;
        DataTable dataTableDeletePost;
        DataTable dataTableDeleteAllowances;
        DataTable dataTableDeleteAward;
        string tableNumber;

        public DirectoryEditorWindow(string tableNumber)
        {
            InitializeComponent();
            this.tableNumber = tableNumber;
            GetData();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdministratorWindow adminWindow = new AdministratorWindow(tableNumber);
            adminWindow.Show();
            Close();
        }

        private void Company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Company.SelectedValue != null)
            {
                dataTableCompWhere = Model.Select($"SELECT * FROM Company, Region WHERE NameCompany='{Company.SelectedValue.ToString()}' AND Company.FK_Region = Region.Id");
                NameCompany.Text = dataTableCompWhere.Rows[0][1].ToString();
                Telephone.Text = dataTableCompWhere.Rows[0][2].ToString();
                INN.Text = dataTableCompWhere.Rows[0][3].ToString();
                AddressCompany.Text = dataTableCompWhere.Rows[0][4].ToString();
                for (int i = 0; i < dataTableRegion.Rows.Count; i++)
                {
                    if (Convert.ToString(dataTableRegion.Rows[i][1]) == dataTableCompWhere.Rows[0][7].ToString())
                        Region.Text = Region.Items.GetItemAt(i).ToString();
                }
            }
            
            

        }

        private void Post_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Post.SelectedValue != null)
            {
                dataTablePostWhere = Model.Select($"SELECT * FROM Post, Subdivision WHERE NamePost='{Post.SelectedValue.ToString()}' AND Post.FK_Sub = Subdivision.Id");

                NamePost.Text = dataTablePostWhere.Rows[0][1].ToString();
                Salary.Text = dataTablePostWhere.Rows[0][2].ToString();
                WorkingDays.Text = dataTablePostWhere.Rows[0][3].ToString();
                for (int i = 0; i < dataTableSubdivision.Rows.Count; i++)
                {
                    if (Convert.ToString(dataTableSubdivision.Rows[i][1]) == dataTablePostWhere.Rows[0][6].ToString())
                        Subdivision.Text = Subdivision.Items.GetItemAt(i).ToString();
                }

            }
            
        }

        private void TypeОfAllowances_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeОfAllowances.SelectedValue != null)
            {
                dataTableAllowancesWhere = Model.Select($"SELECT * FROM TypeОfAllowances WHERE NameAllowances='{TypeОfAllowances.SelectedValue.ToString()}'");

                NameAllowances.Text = dataTableAllowancesWhere.Rows[0][1].ToString();
                CostAllowances.Text = dataTableAllowancesWhere.Rows[0][2].ToString();

            }

        }

        private void TypeОfAward_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeОfAward.SelectedValue != null)
            {
                dataTableAwardWhere = Model.Select($"SELECT * FROM TypeОfAward WHERE NameAward='{TypeОfAward.SelectedValue}'");

                NameAward.Text = dataTableAwardWhere.Rows[0][1].ToString();
                CostAward.Text = dataTableAwardWhere.Rows[0][2].ToString();

            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableEditCompany = Model.Select($"EXEC EditCreateCompany '{NameCompany.Text}', '{Telephone.Text}', '{INN.Text}', '{AddressCompany.Text}', " +
                    $"'{Region.Text}'");

                MessageBox.Show("Данные изменены_Добавлены");
                Company.Items.Clear();
                
                GetData();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableEditPost = Model.Select($"EXEC EditCreatePost '{NamePost.Text}', '{Salary.Text}', '{WorkingDays.Text}', '{Subdivision.Text}'");

                MessageBox.Show("Данные изменены_Добавлены");
                Post.Items.Clear();
                
                GetData();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableEditAllowances = Model.Select($"EXEC EditCreateAllowances '{NameAllowances.Text}', '{CostAllowances.Text}'");

                MessageBox.Show("Данные изменены_Добавлены");
                TypeОfAllowances.Items.Clear();
                
                GetData();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableEditAward = Model.Select($"EXEC EditCreateAward '{NameAward.Text}', '{CostAward.Text}'");

                MessageBox.Show("Данные изменены_Добавлены");
                TypeОfAward.Items.Clear();
                GetData();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            try
            {
                dataTableDeleteCompany = Model.Select($"EXEC DeleteCompany '{NameCompany.Text}'");

                MessageBox.Show("Данные удалены");
                ClearFieldsCompany();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableDeletePost = Model.Select($"EXEC DeletePost '{NamePost.Text}'");

                MessageBox.Show("Данные удалены");
                ClearFieldsPost();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableDeleteAllowances = Model.Select($"EXEC DeleteAllowances '{NameAllowances.Text}'");

                MessageBox.Show("Данные удалены");
                ClearFieldsAllowances();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                dataTableDeleteAward = Model.Select($"EXEC DeleteAward '{NameAward.Text}'");

                MessageBox.Show("Данные удалены");
                ClearFieldsAward();
            }
            catch
            {
                MessageBox.Show("Данные введены не коректно");
            }
        }


        private void GetData()
        {
            

            dataTableComp = Model.Select($"SELECT * FROM Company");
            for (int i = 0; i < dataTableComp.Rows.Count; i++)
            {
                string NameComp = Convert.ToString(dataTableComp.Rows[i][1]);
                Company.Items.Add(NameComp);
            }

            dataTablePost = Model.Select($"SELECT * FROM Post");
            for (int i = 0; i < dataTablePost.Rows.Count; i++)
            {
                string NamePost = Convert.ToString(dataTablePost.Rows[i][1]);
                Post.Items.Add(NamePost);
            }

            dataTableAllowances = Model.Select($"SELECT * FROM TypeОfAllowances");
            for (int i = 0; i < dataTableAllowances.Rows.Count; i++)
            {
                string NameAllowances = Convert.ToString(dataTableAllowances.Rows[i][1]);
                TypeОfAllowances.Items.Add(NameAllowances);
            }

            dataTableAward = Model.Select($"SELECT * FROM TypeОfAward");
            for (int i = 0; i < dataTableAward.Rows.Count; i++)
            {
                string NameAward = Convert.ToString(dataTableAward.Rows[i][1]);
                TypeОfAward.Items.Add(NameAward);
            }

            dataTableRegion = Model.Select($"SELECT * FROM Region");
            for (int i = 0; i < dataTableRegion.Rows.Count; i++)
            {
                string NameRegion = Convert.ToString(dataTableRegion.Rows[i][1]);
                Region.Items.Add(NameRegion);
            }

            dataTableSubdivision = Model.Select($"SELECT * FROM Subdivision");
            for (int i = 0; i < dataTableSubdivision.Rows.Count; i++)
            {
                string NameRegion = Convert.ToString(dataTableSubdivision.Rows[i][1]);
                Subdivision.Items.Add(NameRegion);
            }
        }


        private void ClearFieldsCompany()
        {
            NameCompany.Text = "";
            Telephone.Text = "";
            INN.Text = "";
            AddressCompany.Text = "";
            Region.Text = "";
            Company.Text = "";
            Company.Items.Clear();
            GetData();


        }
        private void ClearFieldsPost()
        {
            NamePost.Text = "";
            Salary.Text = "";
            WorkingDays.Text = "";
            Subdivision.Text = "";
            Post.Text = "";
            Post.Items.Clear();
            GetData();

        }
        private void ClearFieldsAllowances()
        {
            NameAllowances.Text = "";
            CostAllowances.Text = "";
            TypeОfAllowances.Text = "";
            TypeОfAllowances.Items.Clear();
            GetData();
        }

        private void ClearFieldsAward()
        {
            NameAward.Text = "";
            CostAward.Text = "";
            TypeОfAward.Text = "";
            TypeОfAward.Items.Clear();
            GetData();
        }

    }

}

