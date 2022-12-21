﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Data.OleDb;

namespace SalaryApp
{
    public partial class Аccountant : Window
    {
        DataTable dataTable;
        DataTable tabnum;

        public Аccountant(string LoginEmployee, string PaswordEmployee)
        {
            InitializeComponent();

            string log = LoginEmployee;
            string pas = PaswordEmployee;

            tabnum = Model.Select($"Select Employee.TableNumber FROM UserData, Employee WHERE UserData.Id = Employee.FK_UserData AND UserData.LoginUser ='{log}' AND UserData.PasswordUser ='{pas}'");
            YourTabNum.Text = Convert.ToString(tabnum.Rows[0][0]);

            // вывод данных в comboBox
            dataTable = Model.Select($"SELECT * FROM Employee");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string tableNumber = Convert.ToString(dataTable.Rows[i][0]);
                string name = Convert.ToString(dataTable.Rows[i][1]);
                string result = $"{tableNumber} {name}";
                tableNumberCmbBox.Items.Add(result);
            }

            dataTable = Model.Select($"SELECT * FROM TypeОfAward");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string nameAward = Convert.ToString(dataTable.Rows[i][1]);
                
                AwardCmbBox.Items.Add(nameAward);
            }

            dataTable = Model.Select($"SELECT * FROM TypeОfAllowances");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string nameAllowance = Convert.ToString(dataTable.Rows[i][1]);
                
                AllowanceCmbBox.Items.Add(nameAllowance);
            }

            tabnum = Model.Select($"SELECT * FROM TypeОfAllowances");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tableNumber = Convert.ToInt32(tableNumberCmbBox.Text.Split(' ')[0]);

                string startDateV = StartDateV.Text;
                string endDateV = EndDateV.Text;
                string startDateM = StartDateM.Text;
                string endDateM = EndDateM.Text;

                Model.Select($"EXEC payment_entry '{tableNumber}', '{datePicker.Text}', {Check(startDateV)}, {Check(endDateV)}, {Check(startDateM)}, {Check(endDateM)}, '{AwardCmbBox.Text}', '{AllowanceCmbBox.Text}'");
                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
           
        }

        public string Check(string value)
        {
            if (value == "")
                return "null";
            else
                return $"'{value}'";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow= new MainWindow();
            mainwindow.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string tabnumaccountant = YourTabNum.Text;
            EmployeeWindow employeewindow = new EmployeeWindow(tabnumaccountant);
            employeewindow.Show();
            Close();
        }
    }
}
