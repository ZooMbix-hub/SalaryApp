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

        public Аccountant()
        {
            InitializeComponent();
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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string tableNumber = tableNumberCmbBox.Text.Split(' ')[0];

            string startDateV = StartDateV.Text;
            string endDateV = EndDateV.Text;
            string startDateM = StartDateM.Text;
            string endDateM = EndDateM.Text;
            
            if (StartDateV.Text == "" & EndDateV.Text == "")
            {
                startDateV = null;
                endDateV = null;
            }
            if (StartDateM.SelectedDate == null & EndDateM.SelectedDate == null)
            {
                startDateM = null;
                endDateM = null;
            }
            MessageBox.Show($"EXEC payment_entry '{tableNumber}', '{datePicker.Text}', '{startDateV}', '{endDateV}', '{startDateM}', '{endDateM}', '{AwardCmbBox.Text}', '{AllowanceCmbBox.Text}'");

            Model.Select($"EXEC payment_entry '{tableNumber}', '{datePicker.Text}', '{startDateV}', '{endDateV}', '{startDateM}', '{endDateM}', '{AwardCmbBox.Text}', '{AllowanceCmbBox.Text}'");
            MessageBox.Show("Данные успешно добавлены");
        }


    }
}
