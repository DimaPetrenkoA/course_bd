using LiveCharts;
using LiveCharts.Wpf;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Separator = LiveCharts.Wpf.Separator;

namespace BDcource2020
{
    /// <summary>
    /// Логика взаимодействия для ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        DataSet FillDataSetFromDB(string sql)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connection_string);
                var select = sql;
                var dataAdapter = new NpgsqlDataAdapter(select, connection);
                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return null;
            }
        }

        string connection_string;
        public ChartWindow(string connection_string)
        {
            this.connection_string = connection_string;
            InitializeComponent();
            load_chart(2000);
            load_pie();

        }

        void load_chart(int year)
        {
            var values = new ChartValues<float>();
            for (int i = 1; i <= 12; i++)
            {
                var ds = FillDataSetFromDB($"SELECT * FROM zakazi_avg_by_month_year({i}, {year})");
                values.Add(float.Parse(ds.Tables[0].Rows[0][0].ToString()));
            }
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.Series.Add(new LineSeries()
            {
                Values = values,
                Title = "сумма: ",
            });
            cartesianChart1.AxisX.Add(new Axis
            {
                //Title = "месяц",
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false
                },
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });
        }

        void load_pie()
        {
            //sum_zakazi_by_firm
            var dataSet = FillDataSetFromDB("SELECT * FROM sum_zakazi_by_client(0)");
            int sum = 0;
            string caption = "";
            for (int i = 0; i < 5; i++)
            {
                sum = int.Parse(dataSet.Tables[0].Rows[i][1].ToString());
                caption = dataSet.Tables[0].Rows[i][0].ToString();
                pieChart1.Series.Add(new PieSeries
                {
                    Title = caption,
                    Values = new ChartValues<int> { sum },
                });
            }
            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    int year = int.Parse(tb_year.Text);
                    load_chart(year);
                }
                catch (Exception)
                {
                    MessageBox.Show("данной даты нет в записях!");
                    return;
                }
            }
        }
    }
}
